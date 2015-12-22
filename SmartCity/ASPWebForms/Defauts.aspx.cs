using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Text;

namespace ASPWebForms
{
    public partial class Defauts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BusinessLogicLayer.DTO.DefautDTO> list = BusinessLogicLayer.BLL.SelectAllDefauts();

            if (list == null)
                return;

            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("var contentArray = new Array;");

            foreach (BusinessLogicLayer.DTO.DefautDTO d in list)
            {
                string[] parts = d.Position.Split(',');

                string id = d.IdDefaut.ToString();
                string lat = parts[0];
                string lng = parts[1];

                sb.Append("contentArray.push('" + id + "#" + lat + "#" + lng + "');");
            }

            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "ContentArrayScript", sb.ToString());
        }
    }
}