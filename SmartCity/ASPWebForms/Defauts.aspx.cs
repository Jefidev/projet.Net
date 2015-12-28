using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Text;
using System.Data.Linq;

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
                string tab;

                string[] parts = d.Position.Split(',');
                string lat = parts[0];
                string lng = parts[1];
                string id = d.IdDefaut.ToString();
                string descr = HttpUtility.JavaScriptStringEncode(d.Description);

                //Recuperation des defauts
                string interventions = "";
                List<BusinessLogicLayer.DTO.InterventionDTO> listInterventions = BusinessLogicLayer.BLL.SelectInterventionsByDefautOrderByDate(d.IdDefaut);

                foreach (BusinessLogicLayer.DTO.InterventionDTO item in listInterventions)
                {
                    interventions += item + "|";
                }
                interventions = HttpUtility.JavaScriptStringEncode(interventions);


                Binary photo = d.Photo;

                tab = "contentArray.push('" + lat + "#" + lng + "#" + id + "#" + descr + "#" + interventions;

                if (photo != null)
                    tab += "#" + Convert.ToBase64String(photo.ToArray());
                
                sb.Append(tab + "');");
            }

            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "ContentArrayScript", sb.ToString());
        }
    }
}