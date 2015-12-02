using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public static class BLL
    {
        public static bool Connexion(string m, string pwd)
        {
            Personne p = DAL.SelectPersonneByMail(m);

            if (p == null || !pwd.Equals(p.Password))
                return false;
            else
                return true;
        }


        #region Gestion des défauts

        public static List<DefautDTO> SelectAllDefauts()
        {
            return DAL.SelectAllDefauts().Select
            (
                d => new DefautDTO
                {
                    IdDefaut = d.IdDefaut,
                    Photo = d.Photo,
                    Description = d.Description,
                    Position = d.Position
                }
            ).ToList();
        }

        #endregion


        #region Gestion des interventions

        public static List<InterventionDTO> SelectAllInterventions()
        {
            return DAL.SelectAllInterventions().Select
            (
                i => new InterventionDTO
                {
                    IdIntervention = i.IdIntervention,
                    Etat = i.Etat,
                    Commentaire = i.Commentaire,
                    DateIntervention = i.DateIntervention,
                    Defaut = i.Defaut,
                    Personne = i.Personne
                }
            ).ToList();
        }

        #endregion


        #region Gestion des Personnes

        public static List<PersonneDTO> SelectAllPersonnes()
        {
            return DAL.SelectAllPersonnes().Select
            (
                p => new PersonneDTO
                {
                    Mail = p.Mail,
                    Password = p.Password,
                    Nom = p.Nom,
                    Prenom = p.Prenom,
                    Type = p.Type
                }
            ).ToList();
        }

        public static PersonneDTO SelectPersonneByMail(string m)
        {
            var p = DAL.SelectPersonneByMail(m);

            if (p == null)
                return null;

            return new PersonneDTO
            {
                Mail = p.Mail,
                Password = p.Password,
                Nom = p.Nom,
                Prenom = p.Prenom,
                Type = p.Type
            };
        }

        #endregion
    }
}
