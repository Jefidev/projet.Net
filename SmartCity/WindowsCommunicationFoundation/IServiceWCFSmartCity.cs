using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessLogicLayer;
using System.Collections.ObjectModel;
using System.Data.Linq;


namespace WindowsCommunicationFoundation
{
    [ServiceContract]
    public interface IServiceWCFSmartCity
    {
        [OperationContract]
        PersonneWCF Connexion(string m, string pwd);

        [OperationContract]
        List<DefautWCF> GetAllDefauts();

        [OperationContract]
        DefautWCF GetDefautById(int id);

        [OperationContract]
        List<InterventionWCF> GetInterventionsByDefautOrderByDate(int d);

        [OperationContract]
        InterventionWCF GetLastInterventionByDefaut(int d);

        [OperationContract]
        void AddIntervention(string e, string c, DateTime d, int def, string p);

        [OperationContract]
        List<PersonneWCF> GetAllOuvriers();

        [OperationContract]
        string sayHello();
    }


    [DataContract]
    public class DefautWCF
    {
        int idDefaut;
        Binary photo;
        string description;
        string position;
        DateTime dateDefaut;

        [DataMember]
        public int IdDefaut
        {
            get { return idDefaut; }
            set { idDefaut = value; }
        }

        [DataMember]
        public Binary Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        [DataMember]
        public DateTime DateDefaut
        {
            get { return dateDefaut; }
            set { dateDefaut = value; }
        }
    }


    [DataContract]
    public class InterventionWCF
    {
        int idIntervention;
        string etat;
        string commentaire;
        DateTime dateIntervention;
        int idDefaut;
        string mail;

        [DataMember]
        public int IdIntervention
        {
            get { return idIntervention; }
            set { idIntervention = value; }
        }

        [DataMember]
        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        [DataMember]
        public string Commentaire
        {
            get { return commentaire; }
            set { commentaire = value; }
        }

        [DataMember]
        public DateTime DateIntervention
        {
            get { return dateIntervention; }
            set { dateIntervention = value; }
        }

        [DataMember]
        public int IdDefaut
        {
            get { return idDefaut; }
            set { idDefaut = value; }
        }

        [DataMember]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }


    [DataContract]
    public class PersonneWCF
    {
        string mail;
        string password;
        string nom;
        string prenom;
        string type;

        [DataMember]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [DataMember]
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
