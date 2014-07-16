﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReestrModel
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ReestrStore")]
	public partial class ReestrContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDocSender(DocSender instance);
    partial void UpdateDocSender(DocSender instance);
    partial void DeleteDocSender(DocSender instance);
    partial void InsertDocName(DocName instance);
    partial void UpdateDocName(DocName instance);
    partial void DeleteDocName(DocName instance);
    partial void Insertaspnet_User(aspnet_User instance);
    partial void Updateaspnet_User(aspnet_User instance);
    partial void Deleteaspnet_User(aspnet_User instance);
    partial void InsertDocument(Document instance);
    partial void UpdateDocument(Document instance);
    partial void DeleteDocument(Document instance);
    #endregion
		
		public ReestrContextDataContext() : 
				base(global::ReestrModel.Properties.Settings.Default.ReestrStoreConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ReestrContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReestrContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReestrContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReestrContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DocSender> DocSenders
		{
			get
			{
				return this.GetTable<DocSender>();
			}
		}
		
		public System.Data.Linq.Table<DocName> DocNames
		{
			get
			{
				return this.GetTable<DocName>();
			}
		}
		
		public System.Data.Linq.Table<aspnet_User> aspnet_Users
		{
			get
			{
				return this.GetTable<aspnet_User>();
			}
		}
		
		public System.Data.Linq.Table<Document> Documents
		{
			get
			{
				return this.GetTable<Document>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DocSenders")]
	public partial class DocSender : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DocSenderId;
		
		private string _SenderName;
		
		private EntitySet<Document> _Documents;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDocSenderIdChanging(int value);
    partial void OnDocSenderIdChanged();
    partial void OnSenderNameChanging(string value);
    partial void OnSenderNameChanged();
    #endregion
		
		public DocSender()
		{
			this._Documents = new EntitySet<Document>(new Action<Document>(this.attach_Documents), new Action<Document>(this.detach_Documents));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocSenderId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DocSenderId
		{
			get
			{
				return this._DocSenderId;
			}
			set
			{
				if ((this._DocSenderId != value))
				{
					this.OnDocSenderIdChanging(value);
					this.SendPropertyChanging();
					this._DocSenderId = value;
					this.SendPropertyChanged("DocSenderId");
					this.OnDocSenderIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SenderName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string SenderName
		{
			get
			{
				return this._SenderName;
			}
			set
			{
				if ((this._SenderName != value))
				{
					this.OnSenderNameChanging(value);
					this.SendPropertyChanging();
					this._SenderName = value;
					this.SendPropertyChanged("SenderName");
					this.OnSenderNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DocSender_Document", Storage="_Documents", ThisKey="DocSenderId", OtherKey="DocSenderId")]
		public EntitySet<Document> Documents
		{
			get
			{
				return this._Documents;
			}
			set
			{
				this._Documents.Assign(value);
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
		
		private void attach_Documents(Document entity)
		{
			this.SendPropertyChanging();
			entity.DocSender = this;
		}
		
		private void detach_Documents(Document entity)
		{
			this.SendPropertyChanging();
			entity.DocSender = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DocNames")]
	public partial class DocName : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DocNameId;
		
		private string _Name;
		
		private int _TermExecutionDays;
		
		private EntitySet<Document> _Documents;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDocNameIdChanging(int value);
    partial void OnDocNameIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTermExecutionDaysChanging(int value);
    partial void OnTermExecutionDaysChanged();
    #endregion
		
		public DocName()
		{
			this._Documents = new EntitySet<Document>(new Action<Document>(this.attach_Documents), new Action<Document>(this.detach_Documents));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocNameId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DocNameId
		{
			get
			{
				return this._DocNameId;
			}
			set
			{
				if ((this._DocNameId != value))
				{
					this.OnDocNameIdChanging(value);
					this.SendPropertyChanging();
					this._DocNameId = value;
					this.SendPropertyChanged("DocNameId");
					this.OnDocNameIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TermExecutionDays", DbType="Int NOT NULL")]
		public int TermExecutionDays
		{
			get
			{
				return this._TermExecutionDays;
			}
			set
			{
				if ((this._TermExecutionDays != value))
				{
					this.OnTermExecutionDaysChanging(value);
					this.SendPropertyChanging();
					this._TermExecutionDays = value;
					this.SendPropertyChanged("TermExecutionDays");
					this.OnTermExecutionDaysChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DocName_Document", Storage="_Documents", ThisKey="DocNameId", OtherKey="DocNameId")]
		public EntitySet<Document> Documents
		{
			get
			{
				return this._Documents;
			}
			set
			{
				this._Documents.Assign(value);
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
		
		private void attach_Documents(Document entity)
		{
			this.SendPropertyChanging();
			entity.DocName = this;
		}
		
		private void detach_Documents(Document entity)
		{
			this.SendPropertyChanging();
			entity.DocName = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.aspnet_Users")]
	public partial class aspnet_User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ApplicationId;
		
		private System.Guid _UserId;
		
		private string _UserName;
		
		private string _LoweredUserName;
		
		private string _MobileAlias;
		
		private bool _IsAnonymous;
		
		private System.DateTime _LastActivityDate;
		
		private EntitySet<Document> _Documents;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIdChanging(System.Guid value);
    partial void OnApplicationIdChanged();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnLoweredUserNameChanging(string value);
    partial void OnLoweredUserNameChanged();
    partial void OnMobileAliasChanging(string value);
    partial void OnMobileAliasChanged();
    partial void OnIsAnonymousChanging(bool value);
    partial void OnIsAnonymousChanged();
    partial void OnLastActivityDateChanging(System.DateTime value);
    partial void OnLastActivityDateChanged();
    #endregion
		
		public aspnet_User()
		{
			this._Documents = new EntitySet<Document>(new Action<Document>(this.attach_Documents), new Action<Document>(this.detach_Documents));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoweredUserName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string LoweredUserName
		{
			get
			{
				return this._LoweredUserName;
			}
			set
			{
				if ((this._LoweredUserName != value))
				{
					this.OnLoweredUserNameChanging(value);
					this.SendPropertyChanging();
					this._LoweredUserName = value;
					this.SendPropertyChanged("LoweredUserName");
					this.OnLoweredUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MobileAlias", DbType="NVarChar(16)")]
		public string MobileAlias
		{
			get
			{
				return this._MobileAlias;
			}
			set
			{
				if ((this._MobileAlias != value))
				{
					this.OnMobileAliasChanging(value);
					this.SendPropertyChanging();
					this._MobileAlias = value;
					this.SendPropertyChanged("MobileAlias");
					this.OnMobileAliasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAnonymous", DbType="Bit NOT NULL")]
		public bool IsAnonymous
		{
			get
			{
				return this._IsAnonymous;
			}
			set
			{
				if ((this._IsAnonymous != value))
				{
					this.OnIsAnonymousChanging(value);
					this.SendPropertyChanging();
					this._IsAnonymous = value;
					this.SendPropertyChanged("IsAnonymous");
					this.OnIsAnonymousChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastActivityDate", DbType="DateTime NOT NULL")]
		public System.DateTime LastActivityDate
		{
			get
			{
				return this._LastActivityDate;
			}
			set
			{
				if ((this._LastActivityDate != value))
				{
					this.OnLastActivityDateChanging(value);
					this.SendPropertyChanging();
					this._LastActivityDate = value;
					this.SendPropertyChanged("LastActivityDate");
					this.OnLastActivityDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="aspnet_User_Document", Storage="_Documents", ThisKey="UserId", OtherKey="CreatorUserId")]
		public EntitySet<Document> Documents
		{
			get
			{
				return this._Documents;
			}
			set
			{
				this._Documents.Assign(value);
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
		
		private void attach_Documents(Document entity)
		{
			this.SendPropertyChanging();
			entity.aspnet_User = this;
		}
		
		private void detach_Documents(Document entity)
		{
			this.SendPropertyChanging();
			entity.aspnet_User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Documents")]
	public partial class Document : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DocumentId;
		
		private System.Nullable<System.DateTime> _Created;
		
		private int _DocSenderId;
		
		private System.Nullable<int> _DocNameId;
		
		private int _DocNumber;
		
		private System.DateTime _DateAdmission;
		
		private System.Guid _CreatorUserId;
		
		private string _Comments;
		
		private string _Name;
		
		private System.Nullable<int> _TermExecution;
		
		private EntityRef<aspnet_User> _aspnet_User;
		
		private EntityRef<DocName> _DocName;
		
		private EntityRef<DocSender> _DocSender;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDocumentIdChanging(int value);
    partial void OnDocumentIdChanged();
    partial void OnCreatedChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedChanged();
    partial void OnDocSenderIdChanging(int value);
    partial void OnDocSenderIdChanged();
    partial void OnDocNameIdChanging(System.Nullable<int> value);
    partial void OnDocNameIdChanged();
    partial void OnDocNumberChanging(int value);
    partial void OnDocNumberChanged();
    partial void OnDateAdmissionChanging(System.DateTime value);
    partial void OnDateAdmissionChanged();
    partial void OnCreatorUserIdChanging(System.Guid value);
    partial void OnCreatorUserIdChanged();
    partial void OnCommentsChanging(string value);
    partial void OnCommentsChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTermExecutionChanging(System.Nullable<int> value);
    partial void OnTermExecutionChanged();
    #endregion
		
		public Document()
		{
			this._aspnet_User = default(EntityRef<aspnet_User>);
			this._DocName = default(EntityRef<DocName>);
			this._DocSender = default(EntityRef<DocSender>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocumentId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DocumentId
		{
			get
			{
				return this._DocumentId;
			}
			set
			{
				if ((this._DocumentId != value))
				{
					this.OnDocumentIdChanging(value);
					this.SendPropertyChanging();
					this._DocumentId = value;
					this.SendPropertyChanged("DocumentId");
					this.OnDocumentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime")]
		public System.Nullable<System.DateTime> Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocSenderId", DbType="Int NOT NULL")]
		public int DocSenderId
		{
			get
			{
				return this._DocSenderId;
			}
			set
			{
				if ((this._DocSenderId != value))
				{
					if (this._DocSender.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDocSenderIdChanging(value);
					this.SendPropertyChanging();
					this._DocSenderId = value;
					this.SendPropertyChanged("DocSenderId");
					this.OnDocSenderIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocNameId", DbType="Int")]
		public System.Nullable<int> DocNameId
		{
			get
			{
				return this._DocNameId;
			}
			set
			{
				if ((this._DocNameId != value))
				{
					if (this._DocName.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDocNameIdChanging(value);
					this.SendPropertyChanging();
					this._DocNameId = value;
					this.SendPropertyChanged("DocNameId");
					this.OnDocNameIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DocNumber", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int DocNumber
		{
			get
			{
				return this._DocNumber;
			}
			set
			{
				if ((this._DocNumber != value))
				{
					this.OnDocNumberChanging(value);
					this.SendPropertyChanging();
					this._DocNumber = value;
					this.SendPropertyChanged("DocNumber");
					this.OnDocNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateAdmission", DbType="DateTime NOT NULL")]
		public System.DateTime DateAdmission
		{
			get
			{
				return this._DateAdmission;
			}
			set
			{
				if ((this._DateAdmission != value))
				{
					this.OnDateAdmissionChanging(value);
					this.SendPropertyChanging();
					this._DateAdmission = value;
					this.SendPropertyChanged("DateAdmission");
					this.OnDateAdmissionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatorUserId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid CreatorUserId
		{
			get
			{
				return this._CreatorUserId;
			}
			set
			{
				if ((this._CreatorUserId != value))
				{
					if (this._aspnet_User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCreatorUserIdChanging(value);
					this.SendPropertyChanging();
					this._CreatorUserId = value;
					this.SendPropertyChanged("CreatorUserId");
					this.OnCreatorUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comments", DbType="NVarChar(1000)")]
		public string Comments
		{
			get
			{
				return this._Comments;
			}
			set
			{
				if ((this._Comments != value))
				{
					this.OnCommentsChanging(value);
					this.SendPropertyChanging();
					this._Comments = value;
					this.SendPropertyChanged("Comments");
					this.OnCommentsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TermExecution", DbType="Int")]
		public System.Nullable<int> TermExecution
		{
			get
			{
				return this._TermExecution;
			}
			set
			{
				if ((this._TermExecution != value))
				{
					this.OnTermExecutionChanging(value);
					this.SendPropertyChanging();
					this._TermExecution = value;
					this.SendPropertyChanged("TermExecution");
					this.OnTermExecutionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="aspnet_User_Document", Storage="_aspnet_User", ThisKey="CreatorUserId", OtherKey="UserId", IsForeignKey=true)]
		public aspnet_User aspnet_User
		{
			get
			{
				return this._aspnet_User.Entity;
			}
			set
			{
				aspnet_User previousValue = this._aspnet_User.Entity;
				if (((previousValue != value) 
							|| (this._aspnet_User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._aspnet_User.Entity = null;
						previousValue.Documents.Remove(this);
					}
					this._aspnet_User.Entity = value;
					if ((value != null))
					{
						value.Documents.Add(this);
						this._CreatorUserId = value.UserId;
					}
					else
					{
						this._CreatorUserId = default(System.Guid);
					}
					this.SendPropertyChanged("aspnet_User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DocName_Document", Storage="_DocName", ThisKey="DocNameId", OtherKey="DocNameId", IsForeignKey=true)]
		public DocName DocName
		{
			get
			{
				return this._DocName.Entity;
			}
			set
			{
				DocName previousValue = this._DocName.Entity;
				if (((previousValue != value) 
							|| (this._DocName.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DocName.Entity = null;
						previousValue.Documents.Remove(this);
					}
					this._DocName.Entity = value;
					if ((value != null))
					{
						value.Documents.Add(this);
						this._DocNameId = value.DocNameId;
					}
					else
					{
						this._DocNameId = default(Nullable<int>);
					}
					this.SendPropertyChanged("DocName");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DocSender_Document", Storage="_DocSender", ThisKey="DocSenderId", OtherKey="DocSenderId", IsForeignKey=true)]
		public DocSender DocSender
		{
			get
			{
				return this._DocSender.Entity;
			}
			set
			{
				DocSender previousValue = this._DocSender.Entity;
				if (((previousValue != value) 
							|| (this._DocSender.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DocSender.Entity = null;
						previousValue.Documents.Remove(this);
					}
					this._DocSender.Entity = value;
					if ((value != null))
					{
						value.Documents.Add(this);
						this._DocSenderId = value.DocSenderId;
					}
					else
					{
						this._DocSenderId = default(int);
					}
					this.SendPropertyChanged("DocSender");
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
