using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class PersonneDTO
    {
        public string Mail {get; set; }
        public string Password {get; set; }
        public string Nom {get; set; }
        public string Prenom { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Mail + " -- " + Nom + " " + Prenom + " -- " + Type;
        }
    }
}
