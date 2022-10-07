using Nhom01.DAL;
using Nhom01.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SalesManage.Forms
{
    public partial class Bill : Form
    {
        private double pricess { get; set; }
        string[] mNumText = "Không;Một;Hai;Ba;Bốn;Năm;Sáu;Bảy;Tám;Chín".Split(';');
        private int idban { get; set; }
        public Bill()
        {
            InitializeComponent();
            LoadRoom();
            LoadCategory();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc chắn thanh toán hóa đơn này không?", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                InHoaDon();
                using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                {
                    
                    ban b = (from x in db.bans
                             where x.Soban.Equals(idban)
                             select x).SingleOrDefault();
                    ct_hd nv = db.ct_hds.Where(p => p.soban.Equals(idban)).FirstOrDefault();
                    
                    db.ExecuteCommand($"DELETE CT_HD WHERE SOBAN = {idban}");
                    b.Tinhtrang = "Trống";
                    db.SubmitChanges();
                }
            }
            
            ShowBill(idban);
            LoadRoom();
        }
        void LoadRoom()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                List<RoomDTO> roomlist = RoomDAL.Instance.LoadRoom();
                foreach (RoomDTO item in roomlist)
                {
                    Button btn = new Button() { Width = RoomDAL.TableHeight, Height = RoomDAL.TableHeight };
                    btn.Click += btn_Click;
                    btn.Tag = item;
                    btn.Text = "Bàn " + item.Number_room + Environment.NewLine + item.Type_room;
                    switch (item.Type_room)
                    {
                        case "Trống":
                            btn.BackColor = Color.Blue;
                            btn.ForeColor = Color.White;
                            break;
                        default:
                            btn.BackColor = Color.Yellow;
                            btn.ForeColor = Color.Red;
                            break;
                    }
                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as RoomDTO).Number_room;
            LIstBill.Tag = (sender as Button).Tag;
            idban = tableID;
            ShowBill(tableID);
        }
        SqlConnection conn = new SqlConnection(DataP.Instance.connectSTR);
        void LoadCategory()
        {
            conn.Open();
            string sql = "SELECT tendouong as ten FROM douong";
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            comboBox1.DataSource = dt.Tables[0];
            comboBox1.DisplayMember = "ten";
        }
        void ShowBill(int id)
        {
            
            ConnectionLINQDataContext db = new ConnectionLINQDataContext();
            LIstBill.Items.Clear();
            var listBillInfo = (from cthds in db.ct_hds
                                join x in db.hoadons on cthds.MaHoaDon equals x.ID
                                join y in db.douongs on cthds.MaSP equals y.ID
                                join z in db.bans on cthds.soban equals z.Soban
                                where cthds.soban.Equals(id)
                                select new
                                {
                                    tensp = y.tendouong,
                                    gia = y.giatien,
                                    ngaytao = cthds.ngayban,
                                    soban = cthds.soban,
                                    soluong = cthds.SoLuong
                                });
                               
            double total = 0;
            foreach (var item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.tensp.ToString());
                lsvItem.SubItems.Add(item.ngaytao.ToString());
                lsvItem.SubItems.Add(item.soban.ToString());
                lsvItem.SubItems.Add(item.soluong.ToString());
                lsvItem.SubItems.Add(item.gia.ToString());
                total += Convert.ToDouble(item.gia) * item.soluong;
                LIstBill.Items.Add(lsvItem);
            }
            CultureInfo culrure = new CultureInfo("vi-VN");
            label2.Text = total.ToString("c", culrure);
        }
        private void Bill_Load(object sender, EventArgs e)
        {
            
        }
        private void InHoaDon()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        public string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }
        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
            {
                //lấy thông tin từ bảng cấu hình
                var tencuahang = "CAFE VÔ THƯỜNG";
                var diachi = "Diễn hồng - Diễn châu - Nghệ An";
                var phone = "035.447.7192";

            //lấy hóa đơn dựa vào idhoadon
            var hd = db.hoadons.SingleOrDefault(x => x.soban == idban);

            //lấy bề rộng của giấy in
            var w = printDocument1.DefaultPageSettings.PaperSize.Width;
            #region header
            //vẽ header của bill
            //1. tên cửa hàng (quán cafe)
            e.Graphics.DrawString(
                            tencuahang.ToUpper(),
                            new Font("Courier New", 12, FontStyle.Bold),
                            Brushes.Black, new Point(100, 20)
                            );

            //mã hóa đơn
            e.Graphics.DrawString(
                String.Format("HD{0}", hd.ID),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(w / 2 + 265, 20)
                );

            //2. địa chỉ và số điện thoại
            e.Graphics.DrawString(
                string.Format("{0} - {1}", diachi, phone),
                new Font("Courier New", 8, FontStyle.Bold),
                Brushes.Black,
                new Point(20, 45)
                );

            //ngày giờ xuất hóa đơn
            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(w / 2 + 200, 45)
                );



            //định dạng bút vẽ
            Pen blackPen = new Pen(Color.Black, 1);

            //tọa độ theo chiều dọc
            var y = 70;

            //định nghĩa 2 điểm để vẽ đường thẳng
            //cách lề trái 10, lề phải 10
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            //kẻ đường thẳng thứ nhất
            e.Graphics.DrawLine(blackPen, p1, p2);
            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);
            #endregion

            #region body
            y += 10;
            e.Graphics.DrawString("STT", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Sản phẩm/dịch vụ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("Số lượng", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            ////lấy dữ liệu hóa đơn dựa vào idhoadon
            var result = from x in db.ct_hds
                         join xx in db.douongs on x.MaSP equals xx.ID
                         join xxx in db.hoadons on x.MaHoaDon equals xxx.ID
                         join xxxx in db.bans on x.soban equals xxxx.Soban
                         where x.soban.Equals(idban)
                         select new
                         {
                             mahd = x.MaHoaDon,
                             tensp = xx.tendouong,
                             soluong = x.SoLuong,
                             giatien = xx.giatien,
                         };
                ////lặp các phần tử của mảng
                ////mỗi phần tử tương ứng 1 hàng trên bill
                int i = 1;
            y += 20;
            double sum = 0;
            foreach (var l in result)
            {
                sum += (l.soluong * l.giatien);
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(l.tensp, new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.soluong), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 30, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.giatien), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", (l.giatien * l.soluong)), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
                y += 20;
            }
            #endregion

            #region footer
            y += 40;
            //set lại tọa độ cho 2 điểm để vẽ đường thẳng thứ 3
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);

            //tổng tiền thanh toán
            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền: {0:N0} VNĐ", sum), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            //đọc số thành chữ
            y += 30;
            e.Graphics.DrawString(string.Format("Thành chữ: {0}", ChuyenSoSangChuoi(sum)), new Font("Courier New", 8, FontStyle.Italic), Brushes.Black, new Point(10, y));

            y += 40;
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách!", new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            #endregion
        }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                try
                {
                    using (ConnectionLINQDataContext db = new ConnectionLINQDataContext())
                    {
                        thongke thonkes = new thongke();

                        string cat = comboBox1.Text;
                        int sl = Convert.ToInt32(numericUpDown1.Value);
                        var slht = (from catx in db.douongs
                                    where catx.tendouong.Equals(cat)
                                    select catx.Soluong).FirstOrDefault();
                        ct_hd xs = new ct_hd();
                        if (sl > slht)
                        {
                            MessageBox.Show("Số lượng trong kho không đủ!");
                        }
                        else
                        {
                            douong douongs =
                           (from dou in db.douongs
                            where dou.ID.Equals(xs.MaSP)
                            select dou).FirstOrDefault();
                            thonkes.TenSanPham = cat;
                            thonkes.Soluong = sl;
                            var sss = slht - sl;
                            douong sasa = db.douongs.Where(p => p.tendouong.Equals(cat)).SingleOrDefault();
                            sasa.Soluong = sss;
                            db.SubmitChanges();
                            var Table = db.bans.Select(p => p);
                            var IDbill = from x in db.douongs
                                         where x.tendouong.Equals(cat)
                                         select x.ID;
                            foreach (var item in Table)
                            {
                                var ListBill = db.ct_hds.Where(p => p.soban.Equals(item.Soban));
                            }
                            var mas = from xa in db.hoadons
                                      select (xa);
                            bool flag = true;
                            foreach (var item in mas)
                            {
                                if (item.soban == idban)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                hoadon s = new hoadon();
                                s.soban = idban;
                                db.hoadons.InsertOnSubmit(s);
                                db.SubmitChanges();
                            }

                            var mahd = (from sa in db.hoadons
                                        where sa.soban == idban
                                        select sa.ID).FirstOrDefault();

                            xs.MaHoaDon = Convert.ToInt32(mahd);
                            var masp = (from sas in db.douongs
                                        where sas.tendouong.Equals(cat)
                                        select sas.ID).FirstOrDefault();
                            var mspcthd = (db.ct_hds.Select(p => p));
                            bool ss = true;
                            foreach (var item in mspcthd)
                            {
                                if (item.MaSP == masp && item.soban == idban)
                                {
                                    ss = false;
                                    ct_hd CurrentSl = (from s in db.ct_hds
                                                       where s.MaSP.Equals(masp)
                                                       select s).SingleOrDefault();
                                    CurrentSl.SoLuong += Convert.ToInt32(numericUpDown1.Value);

                                }
                            }
                            var giaban = (from gia in db.douongs
                                          where gia.tendouong.Equals(cat)
                                          select gia.giatien).FirstOrDefault();
                            if (ss)
                            {
                                xs.MaSP = masp;
                                xs.ngayban = DateTime.Now;
                                xs.soban = idban;

                                xs.DonGia = giaban;
                                xs.SoLuong += Convert.ToInt32(numericUpDown1.Value);
                                xs.ThanhTien = (xs.DonGia * xs.SoLuong);
                                ban b = (from x in db.bans
                                         where x.Soban.Equals(idban)
                                         select x).SingleOrDefault();
                                b.Tinhtrang = "Có người";
                                db.ct_hds.InsertOnSubmit(xs);
                            }
                            thonkes.doanhthu = sl * giaban;
                            thonkes.ngaylap = DateTime.Now;
                            db.thongkes.InsertOnSubmit(thonkes);

                            db.SubmitChanges();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn bàn!");
                }
            }
            else
            {
                MessageBox.Show("Số lượng món phải lớn hơn 0");
            }
          
            ShowBill(idban);
            LoadRoom();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}