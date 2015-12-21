using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace ASPWebForms
{
    public partial class Defauts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BusinessLogicLayer.DTO.DefautDTO> list = BusinessLogicLayer.BLL.SelectAllDefauts();

            if (list == null)
                return;

            foreach (BusinessLogicLayer.DTO.DefautDTO d in list)
            {
            }
        }

        public void GetDefauts()
        {

        }
    }
}