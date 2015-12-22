using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer.DTO
{
    public class InterventionDTO
    {
        public int IdIntervention { get; set; }
        public string Etat {get; set; }
        public string Commentaire {get; set; }
        public DateTime DateIntervention { get; set; }
        public int IdDefaut { get; set; }
        public string Mail { get; set; }

        public override string ToString()
        {
            return "(" + DateIntervention + ") " + Etat + " => " + Commentaire + " / " + Mail;
        }
    }
}
