using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WindowsCommunicationFoundation
{
    [ServiceContract]
    public interface IServiceWCFSmartCity
    {
        [OperationContract]
        PersonneWCF Connexion(string m, string pwd);

        /*[OperationContract]
        List<PersonneWCF> GetAllPersonnes();

        [OperationContract]
        PersonneWCF GetPersonneByMail(string m);*/
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
