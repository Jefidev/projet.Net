using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;


namespace BusinessLogicLayer.DTO
{
    public class DefautDTO
    {
        public int IdDefaut {get; set; }
        public Binary Photo {get; set; }
        public string Description {get; set; }
        public string Position { get; set; }
        public DateTime DateDefaut { get; set; }

        public override string ToString()
        {
            return IdDefaut + " ==> Position : " + Position + " -- Description : " + Description;
        }
    }
}
