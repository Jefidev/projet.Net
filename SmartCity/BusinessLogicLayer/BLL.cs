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
        #region Connexion

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

        #endregion


        #region Gestion des défauts

        public static List<DefautDTO> SelectAllDefauts()
        {
            List<Defaut> listDAL = DAL.SelectAllDefauts();

            if (listDAL == null)
                return null;
            else
            {
                List<DefautDTO> listBLL = new List<DefautDTO>();

                foreach (Defaut i in listDAL)
                {
                    DefautDTO dDTO = new DefautDTO();
                    dDTO.IdDefaut = i.IdDefaut;
                    dDTO.Photo = i.Photo;
                    dDTO.Description = i.Description;
                    dDTO.Position = i.Position;
                    listBLL.Add(dDTO);
                }

                return listBLL;
            }
        }

        #endregion


        #region Gestion des interventions

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

        #endregion
    }
}
