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


        #region Jointure défauts-interventions

        public static List<DIJointureDTO> SelectDefautsInterventions()
        {
            List<Defaut> listDAL = DAL.SelectAllDefauts();

            if (listDAL == null)
                return null;
            else
            {
                var ilist = listDAL.
                    Select(d => d.Interventions.OrderByDescending(i => i.DateIntervention).
                        FirstOrDefault());

                List<DIJointureDTO> listDTO = new List<DIJointureDTO>();
                foreach (var item in ilist)
                {
                    if (item != null)
                    {
                        listDTO.Add(new DIJointureDTO
                        {
                            IdDefaut = item.IdDefaut,
                            Photo = item.Defaut.Photo,
                            Etat = item.Etat,
                            Description = item.Defaut.Description,
                            Commentaire = item.Commentaire
                        });
                    }
                }
                return listDTO;
            }
        }

        public static List<DIJointureDTO> SelectDefautsInterventionsByMail(string m)
        {
            List<Defaut> listDAL = DAL.SelectAllDefauts();

            if (listDAL == null)
                return null;
            else
            {
                var ilist = listDAL.
                    Select(d => d.Interventions.OrderByDescending(i => i.DateIntervention)
                        .Where(i => (i.Mail != null) && (i.Mail.Equals(m))).FirstOrDefault());

                List<DIJointureDTO> listDTO = new List<DIJointureDTO>();
                foreach (var item in ilist)
                {
                    if (item != null)
                    {
                        listDTO.Add(new DIJointureDTO
                        {
                            IdDefaut = item.IdDefaut,
                            Photo = item.Defaut.Photo,
                            Etat = item.Etat,
                            Description = item.Defaut.Description,
                            Commentaire = item.Commentaire
                        });
                    }
                }
                return listDTO;
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

                foreach (Defaut d in listDAL)
                {
                    DefautDTO dDTO = new DefautDTO();
                    dDTO.IdDefaut = d.IdDefaut;
                    dDTO.Photo = d.Photo;
                    dDTO.Description = d.Description;
                    dDTO.Position = d.Position;
                    dDTO.DateDefaut = d.DateDefaut;
                    listBLL.Add(dDTO);
                }

                return listBLL;
            }
        }

        public static DefautDTO SelectDefautById(int id)
        {
            Defaut d = DAL.SelectDefautById(id);

            if (d == null)
                return null;
            else
            {
                return new DefautDTO
                {
                    IdDefaut = d.IdDefaut,
                    Photo = d.Photo,
                    Description = d.Description,
                    Position = d.Position,
                    DateDefaut = d.DateDefaut
                };
            }
        }

        #endregion


        #region Gestion des interventions

        public static List<InterventionDTO> SelectInterventionsByDefautOrderByDate(int d)
        {
            List<Intervention> listDAL = DAL.SelectInterventionsByDefautOrderByDate(d);

            if (listDAL == null)
                return null;
            else
            {
                List<InterventionDTO> listBLL = new List<InterventionDTO>();

                foreach (Intervention i in listDAL)
                {
                    InterventionDTO iDTO = new InterventionDTO();
                    iDTO.IdIntervention = i.IdIntervention;
                    iDTO.Etat = i.Etat;
                    iDTO.Commentaire = i.Commentaire;
                    iDTO.DateIntervention = i.DateIntervention;
                    iDTO.Defaut = i.IdDefaut;
                    iDTO.Personne = i.Mail;
                    listBLL.Add(iDTO);
                }

                return listBLL;
            }
        }

        public static InterventionDTO SelectLastInterventionByDefaut(int d)
        {
            Intervention i = DAL.SelectLastInterventionByDefaut(d);

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
                    Defaut = i.IdDefaut,
                    Personne = i.Mail
                };
            }
        }

        public static void AddIntervention(string e, string c, DateTime d, int def, string p)
        {
            DAL.AddIntervention(e, c, d, def, p);
        }

        #endregion


        #region Gestion des personnes

        public static List<PersonneDTO> SelectAllOuvriers()
        {
            List<Personne> listDAL = DAL.SelectAllOuvriers();

            if (listDAL == null)
                return null;
            else
            {
                List<PersonneDTO> listBLL = new List<PersonneDTO>();

                foreach (Personne p in listDAL)
                {
                    PersonneDTO pDTO = new PersonneDTO();
                    pDTO.Mail = p.Mail;
                    pDTO.Password = p.Password;
                    pDTO.Nom = p.Nom;
                    pDTO.Prenom = p.Prenom;
                    pDTO.Type = p.Type;
                    listBLL.Add(pDTO);
                }

                return listBLL;
            }
        }

        #endregion
    }
}
