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
        #region Gestion des défauts

        public static List<DefautDTO> SelectAllDefauts()
        {
            Console.WriteLine("BLL ==> Je passe dans SelectAllPersonneDiminuee");
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
            Console.WriteLine("BLL ==> Je passe dans SelectAllPersonneDiminuee");
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
            Console.WriteLine("BLL ==> Je passe dans SelectAllPersonneDiminuee");
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

        public static PersonneDTO SelectPersonne(string m)
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
