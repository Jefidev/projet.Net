using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicLayer.DTO;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public static class BLL
    {
        public static PersonneDTO Connexion(string m, string pwd)
        {
            Personne p = DAL.SelectPersonneByMail(m);

            if (p == null || !pwd.Equals(p.Password))
                return null;
            else
            {
                return new PersonneDTO
                {
                    Mail = p.Mail,
                    Password = p.Password,
                    Nom = p.Nom,
                    Prenom = p.Prenom,
                    Type = p.Type
                };
            }
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

        /*public static List<InterventionDTO> SelectAllInterventions()
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
        }*/

        public static List<InterventionDTO> SelectAllInterventionsOrderByDate()
        {
            List<Intervention> listDAL = DAL.SelectAllInterventionsOrderByDate();

            if (listDAL == null)
                return null;
            else
            {
                List<InterventionDTO> listBLL = new List<InterventionDTO>();

                foreach (Intervention i in listDAL)
                {
                    InterventionDTO iDTO = new InterventionDTO();
                    iDTO.IdIntervention = i.IdIntervention;
                    iDTO.Commentaire = i.Commentaire;
                    iDTO.DateIntervention = i.DateIntervention;
                    iDTO.Defaut = i.Defaut;
                    iDTO.Etat = i.Etat;
                    iDTO.Personne = i.Personne;
                    listBLL.Add(iDTO);
                }

                return listBLL;
            }
        }

        public static InterventionDTO SelectInterventionByDefaut(int d)
        {
            Intervention i = DAL.SelectInterventionByDefaut(d);

            if (i == null)
                return null;
            else
            {
                return new InterventionDTO
                {
                    IdIntervention = i.IdIntervention,
                    Etat = i.Etat,
                    Commentaire = i.Commentaire,
                    DateIntervention = i.DateIntervention,
                    Defaut = i.Defaut,
                    Personne = i.Personne
                };
            }
        }

        #endregion


        #region Gestion des Personnes

        /*public static List<PersonneDTO> SelectAllPersonnes()
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
        }*/

        #endregion
    }
}
