using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessLogicLayer;


namespace WindowsCommunicationFoundation
{
    public class ServiceWCFSmartCity : IServiceWCFSmartCity
    {
        public bool Connexion(string m, string pwd)
        {
            return BLL.Connexion(m, pwd);
        }


        #region Gestion des personnes

        /*public List<PersonneWCF> GetAllPersonnes()
        {
            return BLL.SelectAllPersonnes().Select
            (
                p => new PersonneWCF
                {
                    Mail = p.Mail,
                    Password = p.Password,
                    Nom = p.Nom,
                    Prenom = p.Prenom,
                    Type = p.Type
                }
            ).ToList();
        }

        public PersonneWCF GetPersonneByMail(string m)
        {
            return BLL.SelectPersonneByMail(m).Select
            (
                p => new PersonneWCF
                {
                    Mail = p.Mail,
                    Password = p.Password,
                    Nom = p.Nom,
                    Prenom = p.Prenom,
                    Type = p.Type
                }
            ).ToList();
        }*/

        #endregion
    }
}
