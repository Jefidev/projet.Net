using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL
    {
        private static DataContextDALDataContext instanceDC = null;

        public static DataContextDALDataContext Instance
        {
            get
            {
                if (instanceDC == null)
                    instanceDC = new DataContextDALDataContext();

                return instanceDC;
            }
        }

        public static List<DEFAUT> SelectAllDefauts()
        {
            return Instance.DEFAUTs.ToList();
        }

        public static List<INTERVENTION> SelectAllDefauts()
        {
            return Instance.INTERVENTIONs.ToList();
        }

        public static List<PERSONNE> SelectAllDefauts()
        {
            return Instance.PERSONNEs.ToList();
        }
    }
}
