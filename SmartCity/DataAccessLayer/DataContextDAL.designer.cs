﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SmartCity")]
	public partial class DataContextDALDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDefaut(Defaut instance);
    partial void UpdateDefaut(Defaut instance);
    partial void DeleteDefaut(Defaut instance);
    partial void InsertPersonne(Personne instance);
    partial void UpdatePersonne(Personne instance);
    partial void DeletePersonne(Personne instance);
    partial void InsertIntervention(Intervention instance);
    partial void UpdateIntervention(Intervention instance);
    partial void DeleteIntervention(Intervention instance);
    #endregion
		
		public DataContextDALDataContext() : 
				base(global::DataAccessLayer.Properties.Settings.Default.SmartCityConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDALDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDALDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDALDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContextDALDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Defaut> Defauts
		{
			get
			{
				return this.GetTable<Defaut>();
			}
		}
		
		public System.Data.Linq.Table<Personne> Personnes
		{
			get
			{
				return this.GetTable<Personne>();
			}
		}
		
		public System.Data.Linq.Table<Intervention> Interventions
		{
			get
			{
				return this.GetTable<Intervention>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Defauts")]
	public partial class Defaut : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdDefaut;
		
		private System.Data.Linq.Binary _Photo;
		
		private string _Description;
		
		private string _Position;
		
		private EntitySet<Intervention> _Interventions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdDefautChanging(int value);
    partial void OnIdDefautChanged();
    partial void OnPhotoChanging(System.Data.Linq.Binary value);
    partial void OnPhotoChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnPositionChanging(string value);
    partial void OnPositionChanged();
    #endregion
		
		public Defaut()
		{
			this._Interventions = new EntitySet<Intervention>(new Action<Intervention>(this.attach_Interventions), new Action<Intervention>(this.detach_Interventions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdDefaut", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdDefaut
		{
			get
			{
				return this._IdDefaut;
			}
			set
			{
				if ((this._IdDefaut != value))
				{
					this.OnIdDefautChanging(value);
					this.SendPropertyChanging();
					this._IdDefaut = value;
					this.SendPropertyChanged("IdDefaut");
					this.OnIdDefautChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Photo", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Photo
		{
			get
			{
				return this._Photo;
			}
			set
			{
				if ((this._Photo != value))
				{
					this.OnPhotoChanging(value);
					this.SendPropertyChanging();
					this._Photo = value;
					this.SendPropertyChanged("Photo");
					this.OnPhotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(500)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Position", DbType="VarChar(40)")]
		public string Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				if ((this._Position != value))
				{
					this.OnPositionChanging(value);
					this.SendPropertyChanging();
					this._Position = value;
					this.SendPropertyChanged("Position");
					this.OnPositionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Defaut_Intervention", Storage="_Interventions", ThisKey="IdDefaut", OtherKey="Defaut")]
		public EntitySet<Intervention> Interventions
		{
			get
			{
				return this._Interventions;
			}
			set
			{
				this._Interventions.Assign(value);
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
		
		private void attach_Interventions(Intervention entity)
		{
			this.SendPropertyChanging();
			entity.Defaut1 = this;
		}
		
		private void detach_Interventions(Intervention entity)
		{
			this.SendPropertyChanging();
			entity.Defaut1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Personnes")]
	public partial class Personne : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Mail;
		
		private string _Password;
		
		private string _Nom;
		
		private string _Prenom;
		
		private string _Type;
		
		private EntitySet<Intervention> _Interventions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMailChanging(string value);
    partial void OnMailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnNomChanging(string value);
    partial void OnNomChanged();
    partial void OnPrenomChanging(string value);
    partial void OnPrenomChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    #endregion
		
		public Personne()
		{
			this._Interventions = new EntitySet<Intervention>(new Action<Intervention>(this.attach_Interventions), new Action<Intervention>(this.detach_Interventions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mail", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Mail
		{
			get
			{
				return this._Mail;
			}
			set
			{
				if ((this._Mail != value))
				{
					this.OnMailChanging(value);
					this.SendPropertyChanging();
					this._Mail = value;
					this.SendPropertyChanged("Mail");
					this.OnMailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(20)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nom", DbType="VarChar(30)")]
		public string Nom
		{
			get
			{
				return this._Nom;
			}
			set
			{
				if ((this._Nom != value))
				{
					this.OnNomChanging(value);
					this.SendPropertyChanging();
					this._Nom = value;
					this.SendPropertyChanged("Nom");
					this.OnNomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Prenom", DbType="VarChar(30)")]
		public string Prenom
		{
			get
			{
				return this._Prenom;
			}
			set
			{
				if ((this._Prenom != value))
				{
					this.OnPrenomChanging(value);
					this.SendPropertyChanging();
					this._Prenom = value;
					this.SendPropertyChanged("Prenom");
					this.OnPrenomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(10)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Personne_Intervention", Storage="_Interventions", ThisKey="Mail", OtherKey="Personne")]
		public EntitySet<Intervention> Interventions
		{
			get
			{
				return this._Interventions;
			}
			set
			{
				this._Interventions.Assign(value);
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
		
		private void attach_Interventions(Intervention entity)
		{
			this.SendPropertyChanging();
			entity.Personne1 = this;
		}
		
		private void detach_Interventions(Intervention entity)
		{
			this.SendPropertyChanging();
			entity.Personne1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Interventions")]
	public partial class Intervention : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdIntervention;
		
		private string _Etat;
		
		private string _Commentaire;
		
		private System.DateTime _DateIntervention;
		
		private int _Defaut;
		
		private string _Personne;
		
		private EntityRef<Defaut> _Defaut1;
		
		private EntityRef<Personne> _Personne1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdInterventionChanging(int value);
    partial void OnIdInterventionChanged();
    partial void OnEtatChanging(string value);
    partial void OnEtatChanged();
    partial void OnCommentaireChanging(string value);
    partial void OnCommentaireChanged();
    partial void OnDateInterventionChanging(System.DateTime value);
    partial void OnDateInterventionChanged();
    partial void OnDefautChanging(int value);
    partial void OnDefautChanged();
    partial void OnPersonneChanging(string value);
    partial void OnPersonneChanged();
    #endregion
		
		public Intervention()
		{
			this._Defaut1 = default(EntityRef<Defaut>);
			this._Personne1 = default(EntityRef<Personne>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdIntervention", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdIntervention
		{
			get
			{
				return this._IdIntervention;
			}
			set
			{
				if ((this._IdIntervention != value))
				{
					this.OnIdInterventionChanging(value);
					this.SendPropertyChanging();
					this._IdIntervention = value;
					this.SendPropertyChanged("IdIntervention");
					this.OnIdInterventionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Etat", DbType="VarChar(20)")]
		public string Etat
		{
			get
			{
				return this._Etat;
			}
			set
			{
				if ((this._Etat != value))
				{
					this.OnEtatChanging(value);
					this.SendPropertyChanging();
					this._Etat = value;
					this.SendPropertyChanged("Etat");
					this.OnEtatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Commentaire", DbType="VarChar(500)")]
		public string Commentaire
		{
			get
			{
				return this._Commentaire;
			}
			set
			{
				if ((this._Commentaire != value))
				{
					this.OnCommentaireChanging(value);
					this.SendPropertyChanging();
					this._Commentaire = value;
					this.SendPropertyChanged("Commentaire");
					this.OnCommentaireChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateIntervention", DbType="Date")]
		public System.DateTime DateIntervention
		{
			get
			{
				return this._DateIntervention;
			}
			set
			{
				if ((this._DateIntervention != value))
				{
					this.OnDateInterventionChanging(value);
					this.SendPropertyChanging();
					this._DateIntervention = value;
					this.SendPropertyChanged("DateIntervention");
					this.OnDateInterventionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Defaut", DbType="Int")]
		public int Defaut
		{
			get
			{
				return this._Defaut;
			}
			set
			{
				if ((this._Defaut != value))
				{
					if (this._Defaut1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDefautChanging(value);
					this.SendPropertyChanging();
					this._Defaut = value;
					this.SendPropertyChanged("Defaut");
					this.OnDefautChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Personne", DbType="VarChar(50)")]
		public string Personne
		{
			get
			{
				return this._Personne;
			}
			set
			{
				if ((this._Personne != value))
				{
					if (this._Personne1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPersonneChanging(value);
					this.SendPropertyChanging();
					this._Personne = value;
					this.SendPropertyChanged("Personne");
					this.OnPersonneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Defaut_Intervention", Storage="_Defaut1", ThisKey="Defaut", OtherKey="IdDefaut", IsForeignKey=true)]
		public Defaut Defaut1
		{
			get
			{
				return this._Defaut1.Entity;
			}
			set
			{
				Defaut previousValue = this._Defaut1.Entity;
				if (((previousValue != value) 
							|| (this._Defaut1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Defaut1.Entity = null;
						previousValue.Interventions.Remove(this);
					}
					this._Defaut1.Entity = value;
					if ((value != null))
					{
						value.Interventions.Add(this);
						this._Defaut = value.IdDefaut;
					}
					else
					{
						this._Defaut = default(int);
					}
					this.SendPropertyChanged("Defaut1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Personne_Intervention", Storage="_Personne1", ThisKey="Personne", OtherKey="Mail", IsForeignKey=true)]
		public Personne Personne1
		{
			get
			{
				return this._Personne1.Entity;
			}
			set
			{
				Personne previousValue = this._Personne1.Entity;
				if (((previousValue != value) 
							|| (this._Personne1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Personne1.Entity = null;
						previousValue.Interventions.Remove(this);
					}
					this._Personne1.Entity = value;
					if ((value != null))
					{
						value.Interventions.Add(this);
						this._Personne = value.Mail;
					}
					else
					{
						this._Personne = default(string);
					}
					this.SendPropertyChanged("Personne1");
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
