using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;


namespace DataAccessLayer
{
    public static class DAL
    {
        private static DataContextDALDataContext instanceDC = null;

        public static DataContextDALDataContext InstanceDC
        {
            get { return instanceDC ?? (instanceDC = new DataContextDALDataContext()); }
        }


        #region SELECT

        public static List<Defaut> SelectAllDefauts()
        {
            return InstanceDC.Defauts.OrderByDescending(d => d.DateDefaut).ThenByDescending(d => d.IdDefaut).ToList();
        }
        
        public static Defaut SelectDefautById(int id)
        {
            return InstanceDC.Defauts.Where(d => d.IdDefaut == id).SingleOrDefault();
        }

        public static List<Intervention> SelectInterventionsByDefautOrderByDate(int d)
        {
            return InstanceDC.Interventions.Where(i => i.Defaut == d).OrderByDescending(i => i.DateIntervention).ThenByDescending(i => i.IdIntervention).ToList();
        }

        public static Intervention SelectLastInterventionByDefaut(int d)
        {
            List<Intervention> list = InstanceDC.Interventions.Where(i => i.Defaut == d).OrderByDescending(i => i.DateIntervention).ThenByDescending(i => i.IdIntervention).ToList();
            return list[0];
        }

        public static Personne SelectPersonneByMail(string m)
        {
            return InstanceDC.Personnes.Where(p => p.Mail.Equals(m)).SingleOrDefault();
        }

        public static List<Personne> SelectAllOuvriers()
        {
            return InstanceDC.Personnes.Where(p => p.Type.Equals("OUVRIER")).ToList();
        }

        #endregion


        #region INSERT

        public static void AddIntervention(string e, string c, DateTime d, int def, string p)
        {
            Intervention i = new Intervention
            {
                Etat = e,
                Commentaire = c,
                DateIntervention = d,
                Defaut = def,
                Personne = p
            };

            InstanceDC.Interventions.InsertOnSubmit(i);
            InstanceDC.SubmitChanges();
        }

        #endregion
        

        /* A REVOIR QUAND ON FERA DES INSERT/UPDATE/DELETE */
        /*
        #region INSERT
            public static void AddDefaut(Binary ph, string descr, string po)
            {
                Defaut d = new Defaut
                {
                    Photo = ph,
                    Description = descr,
                    Position = po
                };

                InstanceDC.Defauts.InsertOnSubmit(d);
                InstanceDC.SubmitChanges();
            }

            public static void AddIntervention(string e, string c, DateTime d, int def, string p)
            {
                Intervention i = new Intervention
                {
                    Etat = e,
                    Commentaire = c,
                    DateIntervention = d,
                    Defaut = def,
                    Personne = p
                };

                InstanceDC.Interventions.InsertOnSubmit(i);
                InstanceDC.SubmitChanges();
            }

            public static void AddPersonne(string m, string pwd, string n, string pr, string t)
            {
                Personne p = new Personne
                {
                    Mail = m,
                    Password = pwd,
                    Nom = n,
                    Prenom = pr,
                    Type = t
                };

                InstanceDC.Personnes.InsertOnSubmit(p);
                InstanceDC.SubmitChanges();
            }
        #endregion


        #region UPDATE
            public static void UpdateDefaut(int id, Binary ph, string descr, string po)
            {
                Defaut d = InstanceDC.Defauts.Single(ud => ud.IdDefaut.Equals(id));
                d.Photo = ph;
                d.Description = descr;
                d.Position = po;
                InstanceDC.SubmitChanges();
            }

            public static void UpdateIntervention(int id, string e, string c, DateTime d, int def, string p)
            {
                Intervention i = InstanceDC.Interventions.Single(ui => ui.IdIntervention.Equals(id));
                i.Etat = e;
                i.Commentaire = c;
                i.DateIntervention = d;
                i.Defaut = def;
                InstanceDC.SubmitChanges();
            }

            public static void UpdatePersonne(string m, string pwd, string n, string pr, string t)
            {
                Personne p = InstanceDC.Personnes.Single(up => up.Mail.Equals(m));
                p.Password = pwd;
                p.Nom = n;
                p.Prenom = pr;
                p.Type = t;
                InstanceDC.SubmitChanges();
            }
        #endregion


        #region DELETE
            public static void DeleteDefaut(int id)
            {
                Defaut d = InstanceDC.Defauts.Single(dd => dd.IdDefaut.Equals(id));
                InstanceDC.Defauts.DeleteOnSubmit(d);
                InstanceDC.SubmitChanges();
            }

            public static void DeleteIntervention(int id)
            {
                Intervention i = InstanceDC.Interventions.Single(di=> di.IdIntervention.Equals(id));
                InstanceDC.Interventions.DeleteOnSubmit(i);
                InstanceDC.SubmitChanges();
            }

            public static void DeletePersonne(string m)
            {
                Personne p = InstanceDC.Personnes.Single(dp => dp.Mail.Equals(m));
                InstanceDC.Personnes.DeleteOnSubmit(p);
                InstanceDC.SubmitChanges();
            }
        #endregion
         */
    }
}
