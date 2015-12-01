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
        public string Connexion(string m, string pwd)
        {
            foreach(PersonneWCF p in GetAllPersonnes())
            {
                if (p.Mail == m)
                {
                    if (p.Password == pwd)
                        return p.Mail;
                    else
                        return null;
                }
            }

            return null;
        }


        #region Gestion des personnes

        public List<PersonneWCF> GetAllPersonnes()
        {
            Console.WriteLine("Service ==> Je passe dans GetAllPersonnes");
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

        #endregion
    }
}
