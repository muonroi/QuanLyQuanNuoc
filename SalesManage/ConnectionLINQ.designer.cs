﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesManage
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QuanLyQuanCaFe")]
	public partial class ConnectionLINQDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertban(ban instance);
    partial void Updateban(ban instance);
    partial void Deleteban(ban instance);
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void InsertCATRUC(CATRUC instance);
    partial void UpdateCATRUC(CATRUC instance);
    partial void DeleteCATRUC(CATRUC instance);
    partial void Insertct_hd(ct_hd instance);
    partial void Updatect_hd(ct_hd instance);
    partial void Deletect_hd(ct_hd instance);
    partial void Insertdouong(douong instance);
    partial void Updatedouong(douong instance);
    partial void Deletedouong(douong instance);
    partial void Inserthoadon(hoadon instance);
    partial void Updatehoadon(hoadon instance);
    partial void Deletehoadon(hoadon instance);
    partial void Insertnhanvien(nhanvien instance);
    partial void Updatenhanvien(nhanvien instance);
    partial void Deletenhanvien(nhanvien instance);
    partial void Insertthongke(thongke instance);
    partial void Updatethongke(thongke instance);
    partial void Deletethongke(thongke instance);
    #endregion
		
		public ConnectionLINQDataContext() : 
				base(global::SalesManage.Properties.Settings.Default.QuanLyQuanCaFeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionLINQDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionLINQDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionLINQDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConnectionLINQDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ban> bans
		{
			get
			{
				return this.GetTable<ban>();
			}
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<CATRUC> CATRUCs
		{
			get
			{
				return this.GetTable<CATRUC>();
			}
		}
		
		public System.Data.Linq.Table<ct_hd> ct_hds
		{
			get
			{
				return this.GetTable<ct_hd>();
			}
		}
		
		public System.Data.Linq.Table<douong> douongs
		{
			get
			{
				return this.GetTable<douong>();
			}
		}
		
		public System.Data.Linq.Table<hoadon> hoadons
		{
			get
			{
				return this.GetTable<hoadon>();
			}
		}
		
		public System.Data.Linq.Table<nhanvien> nhanviens
		{
			get
			{
				return this.GetTable<nhanvien>();
			}
		}
		
		public System.Data.Linq.Table<thongke> thongkes
		{
			get
			{
				return this.GetTable<thongke>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ban")]
	public partial class ban : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Soban;
		
		private string _Tinhtrang;
		
		private EntitySet<ct_hd> _ct_hds;
		
		private EntitySet<hoadon> _hoadons;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSobanChanging(int value);
    partial void OnSobanChanged();
    partial void OnTinhtrangChanging(string value);
    partial void OnTinhtrangChanged();
    #endregion
		
		public ban()
		{
			this._ct_hds = new EntitySet<ct_hd>(new Action<ct_hd>(this.attach_ct_hds), new Action<ct_hd>(this.detach_ct_hds));
			this._hoadons = new EntitySet<hoadon>(new Action<hoadon>(this.attach_hoadons), new Action<hoadon>(this.detach_hoadons));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Soban", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Soban
		{
			get
			{
				return this._Soban;
			}
			set
			{
				if ((this._Soban != value))
				{
					this.OnSobanChanging(value);
					this.SendPropertyChanging();
					this._Soban = value;
					this.SendPropertyChanged("Soban");
					this.OnSobanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tinhtrang", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Tinhtrang
		{
			get
			{
				return this._Tinhtrang;
			}
			set
			{
				if ((this._Tinhtrang != value))
				{
					this.OnTinhtrangChanging(value);
					this.SendPropertyChanging();
					this._Tinhtrang = value;
					this.SendPropertyChanged("Tinhtrang");
					this.OnTinhtrangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ban_ct_hd", Storage="_ct_hds", ThisKey="Soban", OtherKey="soban")]
		public EntitySet<ct_hd> ct_hds
		{
			get
			{
				return this._ct_hds;
			}
			set
			{
				this._ct_hds.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ban_hoadon", Storage="_hoadons", ThisKey="Soban", OtherKey="soban")]
		public EntitySet<hoadon> hoadons
		{
			get
			{
				return this._hoadons;
			}
			set
			{
				this._hoadons.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ct_hds(ct_hd entity)
		{
			this.SendPropertyChanging();
			entity.ban = this;
		}
		
		private void detach_ct_hds(ct_hd entity)
		{
			this.SendPropertyChanging();
			entity.ban = null;
		}
		
		private void attach_hoadons(hoadon entity)
		{
			this.SendPropertyChanging();
			entity.ban = this;
		}
		
		private void detach_hoadons(hoadon entity)
		{
			this.SendPropertyChanging();
			entity.ban = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.users")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Name;
		
		private string _UserName;
		
		private string _Password;
		
		private System.Nullable<int> _priority;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnpriorityChanging(System.Nullable<int> value);
    partial void OnpriorityChanged();
    #endregion
		
		public user()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_priority", DbType="Int")]
		public System.Nullable<int> priority
		{
			get
			{
				return this._priority;
			}
			set
			{
				if ((this._priority != value))
				{
					this.OnpriorityChanging(value);
					this.SendPropertyChanging();
					this._priority = value;
					this.SendPropertyChanged("priority");
					this.OnpriorityChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CATRUC")]
	public partial class CATRUC : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _ca;
		
		private System.Nullable<System.DateTime> _ngaytruc;
		
		private System.Nullable<int> _IDnhanvien;
		
		private EntityRef<nhanvien> _nhanvien;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OncaChanging(string value);
    partial void OncaChanged();
    partial void OnngaytrucChanging(System.Nullable<System.DateTime> value);
    partial void OnngaytrucChanged();
    partial void OnIDnhanvienChanging(System.Nullable<int> value);
    partial void OnIDnhanvienChanged();
    #endregion
		
		public CATRUC()
		{
			this._nhanvien = default(EntityRef<nhanvien>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ca", DbType="NVarChar(20)")]
		public string ca
		{
			get
			{
				return this._ca;
			}
			set
			{
				if ((this._ca != value))
				{
					this.OncaChanging(value);
					this.SendPropertyChanging();
					this._ca = value;
					this.SendPropertyChanged("ca");
					this.OncaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaytruc", DbType="DateTime")]
		public System.Nullable<System.DateTime> ngaytruc
		{
			get
			{
				return this._ngaytruc;
			}
			set
			{
				if ((this._ngaytruc != value))
				{
					this.OnngaytrucChanging(value);
					this.SendPropertyChanging();
					this._ngaytruc = value;
					this.SendPropertyChanged("ngaytruc");
					this.OnngaytrucChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDnhanvien", DbType="Int")]
		public System.Nullable<int> IDnhanvien
		{
			get
			{
				return this._IDnhanvien;
			}
			set
			{
				if ((this._IDnhanvien != value))
				{
					if (this._nhanvien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDnhanvienChanging(value);
					this.SendPropertyChanging();
					this._IDnhanvien = value;
					this.SendPropertyChanged("IDnhanvien");
					this.OnIDnhanvienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="nhanvien_CATRUC", Storage="_nhanvien", ThisKey="IDnhanvien", OtherKey="MANV", IsForeignKey=true)]
		public nhanvien nhanvien
		{
			get
			{
				return this._nhanvien.Entity;
			}
			set
			{
				nhanvien previousValue = this._nhanvien.Entity;
				if (((previousValue != value) 
							|| (this._nhanvien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._nhanvien.Entity = null;
						previousValue.CATRUCs.Remove(this);
					}
					this._nhanvien.Entity = value;
					if ((value != null))
					{
						value.CATRUCs.Add(this);
						this._IDnhanvien = value.MANV;
					}
					else
					{
						this._IDnhanvien = default(Nullable<int>);
					}
					this.SendPropertyChanged("nhanvien");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ct_hd")]
	public partial class ct_hd : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _MaHoaDon;
		
		private int _MaSP;
		
		private System.DateTime _ngayban;
		
		private int _soban;
		
		private int _SoLuong;
		
		private double _DonGia;
		
		private double _ThanhTien;
		
		private EntityRef<ban> _ban;
		
		private EntityRef<douong> _douong;
		
		private EntityRef<hoadon> _hoadon;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnMaHoaDonChanging(int value);
    partial void OnMaHoaDonChanged();
    partial void OnMaSPChanging(int value);
    partial void OnMaSPChanged();
    partial void OnngaybanChanging(System.DateTime value);
    partial void OnngaybanChanged();
    partial void OnsobanChanging(int value);
    partial void OnsobanChanged();
    partial void OnSoLuongChanging(int value);
    partial void OnSoLuongChanged();
    partial void OnDonGiaChanging(double value);
    partial void OnDonGiaChanged();
    partial void OnThanhTienChanging(double value);
    partial void OnThanhTienChanged();
    #endregion
		
		public ct_hd()
		{
			this._ban = default(EntityRef<ban>);
			this._douong = default(EntityRef<douong>);
			this._hoadon = default(EntityRef<hoadon>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHoaDon", DbType="Int NOT NULL")]
		public int MaHoaDon
		{
			get
			{
				return this._MaHoaDon;
			}
			set
			{
				if ((this._MaHoaDon != value))
				{
					if (this._hoadon.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaHoaDonChanging(value);
					this.SendPropertyChanging();
					this._MaHoaDon = value;
					this.SendPropertyChanged("MaHoaDon");
					this.OnMaHoaDonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaSP", DbType="Int NOT NULL")]
		public int MaSP
		{
			get
			{
				return this._MaSP;
			}
			set
			{
				if ((this._MaSP != value))
				{
					if (this._douong.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaSPChanging(value);
					this.SendPropertyChanging();
					this._MaSP = value;
					this.SendPropertyChanged("MaSP");
					this.OnMaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayban", DbType="Date NOT NULL")]
		public System.DateTime ngayban
		{
			get
			{
				return this._ngayban;
			}
			set
			{
				if ((this._ngayban != value))
				{
					this.OnngaybanChanging(value);
					this.SendPropertyChanging();
					this._ngayban = value;
					this.SendPropertyChanged("ngayban");
					this.OnngaybanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soban", DbType="Int NOT NULL")]
		public int soban
		{
			get
			{
				return this._soban;
			}
			set
			{
				if ((this._soban != value))
				{
					if (this._ban.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnsobanChanging(value);
					this.SendPropertyChanging();
					this._soban = value;
					this.SendPropertyChanged("soban");
					this.OnsobanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int NOT NULL")]
		public int SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonGia", DbType="Float NOT NULL")]
		public double DonGia
		{
			get
			{
				return this._DonGia;
			}
			set
			{
				if ((this._DonGia != value))
				{
					this.OnDonGiaChanging(value);
					this.SendPropertyChanging();
					this._DonGia = value;
					this.SendPropertyChanged("DonGia");
					this.OnDonGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThanhTien", DbType="Float NOT NULL")]
		public double ThanhTien
		{
			get
			{
				return this._ThanhTien;
			}
			set
			{
				if ((this._ThanhTien != value))
				{
					this.OnThanhTienChanging(value);
					this.SendPropertyChanging();
					this._ThanhTien = value;
					this.SendPropertyChanged("ThanhTien");
					this.OnThanhTienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ban_ct_hd", Storage="_ban", ThisKey="soban", OtherKey="Soban", IsForeignKey=true)]
		public ban ban
		{
			get
			{
				return this._ban.Entity;
			}
			set
			{
				ban previousValue = this._ban.Entity;
				if (((previousValue != value) 
							|| (this._ban.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ban.Entity = null;
						previousValue.ct_hds.Remove(this);
					}
					this._ban.Entity = value;
					if ((value != null))
					{
						value.ct_hds.Add(this);
						this._soban = value.Soban;
					}
					else
					{
						this._soban = default(int);
					}
					this.SendPropertyChanged("ban");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="douong_ct_hd", Storage="_douong", ThisKey="MaSP", OtherKey="ID", IsForeignKey=true)]
		public douong douong
		{
			get
			{
				return this._douong.Entity;
			}
			set
			{
				douong previousValue = this._douong.Entity;
				if (((previousValue != value) 
							|| (this._douong.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._douong.Entity = null;
						previousValue.ct_hds.Remove(this);
					}
					this._douong.Entity = value;
					if ((value != null))
					{
						value.ct_hds.Add(this);
						this._MaSP = value.ID;
					}
					else
					{
						this._MaSP = default(int);
					}
					this.SendPropertyChanged("douong");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="hoadon_ct_hd", Storage="_hoadon", ThisKey="MaHoaDon", OtherKey="ID", IsForeignKey=true)]
		public hoadon hoadon
		{
			get
			{
				return this._hoadon.Entity;
			}
			set
			{
				hoadon previousValue = this._hoadon.Entity;
				if (((previousValue != value) 
							|| (this._hoadon.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._hoadon.Entity = null;
						previousValue.ct_hds.Remove(this);
					}
					this._hoadon.Entity = value;
					if ((value != null))
					{
						value.ct_hds.Add(this);
						this._MaHoaDon = value.ID;
					}
					else
					{
						this._MaHoaDon = default(int);
					}
					this.SendPropertyChanged("hoadon");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.douong")]
	public partial class douong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _tendouong;
		
		private string _ghichu;
		
		private int _Soluong;
		
		private double _giatien;
		
		private EntitySet<ct_hd> _ct_hds;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OntendouongChanging(string value);
    partial void OntendouongChanged();
    partial void OnghichuChanging(string value);
    partial void OnghichuChanged();
    partial void OnSoluongChanging(int value);
    partial void OnSoluongChanged();
    partial void OngiatienChanging(double value);
    partial void OngiatienChanged();
    #endregion
		
		public douong()
		{
			this._ct_hds = new EntitySet<ct_hd>(new Action<ct_hd>(this.attach_ct_hds), new Action<ct_hd>(this.detach_ct_hds));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tendouong", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string tendouong
		{
			get
			{
				return this._tendouong;
			}
			set
			{
				if ((this._tendouong != value))
				{
					this.OntendouongChanging(value);
					this.SendPropertyChanging();
					this._tendouong = value;
					this.SendPropertyChanged("tendouong");
					this.OntendouongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ghichu", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string ghichu
		{
			get
			{
				return this._ghichu;
			}
			set
			{
				if ((this._ghichu != value))
				{
					this.OnghichuChanging(value);
					this.SendPropertyChanging();
					this._ghichu = value;
					this.SendPropertyChanged("ghichu");
					this.OnghichuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Soluong", DbType="Int NOT NULL")]
		public int Soluong
		{
			get
			{
				return this._Soluong;
			}
			set
			{
				if ((this._Soluong != value))
				{
					this.OnSoluongChanging(value);
					this.SendPropertyChanging();
					this._Soluong = value;
					this.SendPropertyChanged("Soluong");
					this.OnSoluongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_giatien", DbType="Float NOT NULL")]
		public double giatien
		{
			get
			{
				return this._giatien;
			}
			set
			{
				if ((this._giatien != value))
				{
					this.OngiatienChanging(value);
					this.SendPropertyChanging();
					this._giatien = value;
					this.SendPropertyChanged("giatien");
					this.OngiatienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="douong_ct_hd", Storage="_ct_hds", ThisKey="ID", OtherKey="MaSP")]
		public EntitySet<ct_hd> ct_hds
		{
			get
			{
				return this._ct_hds;
			}
			set
			{
				this._ct_hds.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ct_hds(ct_hd entity)
		{
			this.SendPropertyChanging();
			entity.douong = this;
		}
		
		private void detach_ct_hds(ct_hd entity)
		{
			this.SendPropertyChanging();
			entity.douong = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.hoadon")]
	public partial class hoadon : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _soban;
		
		private EntitySet<ct_hd> _ct_hds;
		
		private EntityRef<ban> _ban;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnsobanChanging(int value);
    partial void OnsobanChanged();
    #endregion
		
		public hoadon()
		{
			this._ct_hds = new EntitySet<ct_hd>(new Action<ct_hd>(this.attach_ct_hds), new Action<ct_hd>(this.detach_ct_hds));
			this._ban = default(EntityRef<ban>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soban", DbType="Int NOT NULL")]
		public int soban
		{
			get
			{
				return this._soban;
			}
			set
			{
				if ((this._soban != value))
				{
					if (this._ban.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnsobanChanging(value);
					this.SendPropertyChanging();
					this._soban = value;
					this.SendPropertyChanged("soban");
					this.OnsobanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="hoadon_ct_hd", Storage="_ct_hds", ThisKey="ID", OtherKey="MaHoaDon")]
		public EntitySet<ct_hd> ct_hds
		{
			get
			{
				return this._ct_hds;
			}
			set
			{
				this._ct_hds.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ban_hoadon", Storage="_ban", ThisKey="soban", OtherKey="Soban", IsForeignKey=true)]
		public ban ban
		{
			get
			{
				return this._ban.Entity;
			}
			set
			{
				ban previousValue = this._ban.Entity;
				if (((previousValue != value) 
							|| (this._ban.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ban.Entity = null;
						previousValue.hoadons.Remove(this);
					}
					this._ban.Entity = value;
					if ((value != null))
					{
						value.hoadons.Add(this);
						this._soban = value.Soban;
					}
					else
					{
						this._soban = default(int);
					}
					this.SendPropertyChanged("ban");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ct_hds(ct_hd entity)
		{
			this.SendPropertyChanging();
			entity.hoadon = this;
		}
		
		private void detach_ct_hds(ct_hd entity)
		{
			this.SendPropertyChanging();
			entity.hoadon = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.nhanvien")]
	public partial class nhanvien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MANV;
		
		private string _TENHANVIEN;
		
		private string _GIOITINH;
		
		private string _DIENTHOAI;
		
		private EntitySet<CATRUC> _CATRUCs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMANVChanging(int value);
    partial void OnMANVChanged();
    partial void OnTENHANVIENChanging(string value);
    partial void OnTENHANVIENChanged();
    partial void OnGIOITINHChanging(string value);
    partial void OnGIOITINHChanged();
    partial void OnDIENTHOAIChanging(string value);
    partial void OnDIENTHOAIChanged();
    #endregion
		
		public nhanvien()
		{
			this._CATRUCs = new EntitySet<CATRUC>(new Action<CATRUC>(this.attach_CATRUCs), new Action<CATRUC>(this.detach_CATRUCs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MANV", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MANV
		{
			get
			{
				return this._MANV;
			}
			set
			{
				if ((this._MANV != value))
				{
					this.OnMANVChanging(value);
					this.SendPropertyChanging();
					this._MANV = value;
					this.SendPropertyChanged("MANV");
					this.OnMANVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENHANVIEN", DbType="NVarChar(50)")]
		public string TENHANVIEN
		{
			get
			{
				return this._TENHANVIEN;
			}
			set
			{
				if ((this._TENHANVIEN != value))
				{
					this.OnTENHANVIENChanging(value);
					this.SendPropertyChanging();
					this._TENHANVIEN = value;
					this.SendPropertyChanged("TENHANVIEN");
					this.OnTENHANVIENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIOITINH", DbType="NVarChar(10)")]
		public string GIOITINH
		{
			get
			{
				return this._GIOITINH;
			}
			set
			{
				if ((this._GIOITINH != value))
				{
					this.OnGIOITINHChanging(value);
					this.SendPropertyChanging();
					this._GIOITINH = value;
					this.SendPropertyChanged("GIOITINH");
					this.OnGIOITINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIENTHOAI", DbType="NVarChar(12)")]
		public string DIENTHOAI
		{
			get
			{
				return this._DIENTHOAI;
			}
			set
			{
				if ((this._DIENTHOAI != value))
				{
					this.OnDIENTHOAIChanging(value);
					this.SendPropertyChanging();
					this._DIENTHOAI = value;
					this.SendPropertyChanged("DIENTHOAI");
					this.OnDIENTHOAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="nhanvien_CATRUC", Storage="_CATRUCs", ThisKey="MANV", OtherKey="IDnhanvien")]
		public EntitySet<CATRUC> CATRUCs
		{
			get
			{
				return this._CATRUCs;
			}
			set
			{
				this._CATRUCs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CATRUCs(CATRUC entity)
		{
			this.SendPropertyChanging();
			entity.nhanvien = this;
		}
		
		private void detach_CATRUCs(CATRUC entity)
		{
			this.SendPropertyChanging();
			entity.nhanvien = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.thongke")]
	public partial class thongke : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _TenSanPham;
		
		private System.Nullable<int> _Soluong;
		
		private System.Nullable<System.DateTime> _ngaylap;
		
		private System.Nullable<double> _doanhthu;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnTenSanPhamChanging(string value);
    partial void OnTenSanPhamChanged();
    partial void OnSoluongChanging(System.Nullable<int> value);
    partial void OnSoluongChanged();
    partial void OnngaylapChanging(System.Nullable<System.DateTime> value);
    partial void OnngaylapChanged();
    partial void OndoanhthuChanging(System.Nullable<double> value);
    partial void OndoanhthuChanged();
    #endregion
		
		public thongke()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenSanPham", DbType="NVarChar(30)")]
		public string TenSanPham
		{
			get
			{
				return this._TenSanPham;
			}
			set
			{
				if ((this._TenSanPham != value))
				{
					this.OnTenSanPhamChanging(value);
					this.SendPropertyChanging();
					this._TenSanPham = value;
					this.SendPropertyChanged("TenSanPham");
					this.OnTenSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Soluong", DbType="Int")]
		public System.Nullable<int> Soluong
		{
			get
			{
				return this._Soluong;
			}
			set
			{
				if ((this._Soluong != value))
				{
					this.OnSoluongChanging(value);
					this.SendPropertyChanging();
					this._Soluong = value;
					this.SendPropertyChanged("Soluong");
					this.OnSoluongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaylap", DbType="Date")]
		public System.Nullable<System.DateTime> ngaylap
		{
			get
			{
				return this._ngaylap;
			}
			set
			{
				if ((this._ngaylap != value))
				{
					this.OnngaylapChanging(value);
					this.SendPropertyChanging();
					this._ngaylap = value;
					this.SendPropertyChanged("ngaylap");
					this.OnngaylapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_doanhthu", DbType="Float")]
		public System.Nullable<double> doanhthu
		{
			get
			{
				return this._doanhthu;
			}
			set
			{
				if ((this._doanhthu != value))
				{
					this.OndoanhthuChanging(value);
					this.SendPropertyChanging();
					this._doanhthu = value;
					this.SendPropertyChanged("doanhthu");
					this.OndoanhthuChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591