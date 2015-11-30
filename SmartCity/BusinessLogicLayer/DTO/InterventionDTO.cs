using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    class InterventionDTO
    {
        public int IdIntervention { get; set; }
        public string Etat {get; set; }
        public string Commentaire {get; set; }
        public DateTime DateIntervention { get; set; }
        public int Defaut { get; set; }
        public string Personne { get; set; }

        public override string ToString()
        {
            return IdIntervention + " ==> " + "Etat : " + Etat + " -- Date : " + DateIntervention + " -- Commentaire : " + Commentaire;
        }
    }
}
