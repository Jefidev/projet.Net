using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace BusinessLogicLayer.DTO
{
    public class DIJointureDTO
    {
        public int IdDefaut { get; set; }
        public Binary Photo { get; set; }
        public String Etat { get; set; }
        public String Description { get; set; }
        public String Commentaire { get; set; }
    }
}
