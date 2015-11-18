using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace TestDAL
{
    class Program
    {
        private static List<Defaut> listDefauts;
        private static List<Intervention> listInterventions;
        private static List<Personne> listPersonnes;

        static void Main(string[] args)
        {
            Affiche();


            /* AJOUT */

            /*DAL.AddDefaut(null, "Route abimée", null);
            DAL.AddPersonne("AAA@gmail.com", "AAA", "AAAName", "AAAFirstname", "CITOYEN");
            DAL.AddIntervention("OUVERT", "Problème ouvert", new DateTime(2015, 11, 20), 2, "oceane.seel@hotmail.com");
            Affiche();*/


            Console.ReadLine();
        }

        private static void Affiche()
        {
            listDefauts = DAL.SelectAllDefauts();
            listInterventions = DAL.SelectAllInterventions();
            listPersonnes = DAL.SelectAllPersonnes();

            Console.WriteLine("DEFAUTS :\n");
            foreach (var d in listDefauts)
            {
                Console.WriteLine(d.IdDefaut + " - " + d.Description + " - " + d.Photo + " - " + d.Position);
            }

            Console.WriteLine("\n\nPERSONNES :\n");
            foreach (var p in listPersonnes)
            {
                Console.WriteLine(p.Mail + " - " + p.Password + " - " + p.Nom + " - " + p.Prenom + " - " + p.Type);
            }

            Console.WriteLine("\n\nINTERVENTIONS :\n");
            foreach (var i in listInterventions)
            {
                Console.WriteLine(i.IdIntervention + " - " + i.Etat + " - " + i.DateIntervention + " - " + i.Commentaire + " - " + i.Defaut + " - " + i.Personne);
            }

            Console.WriteLine("\n\n");
        }
    }
}
