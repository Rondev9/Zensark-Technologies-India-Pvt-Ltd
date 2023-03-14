using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Excerciese___04_03_2023___Zensark_website
{
    public partial class Zensark_Technologies : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ddlSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlSolutions.SelectedValue;
            if (selectedValue != null)
            {
                switch (selectedValue)
                {
                    case "1":
                        Response.Redirect("~/Application Development.aspx");
                        break;
                    case "2":
                        Response.Redirect("~/D365 Support and Maintenance.aspx");
                        break;
                    case "3":
                        Response.Redirect("~/Digital Commerce.aspx");
                        break;
                    case "4":
                        Response.Redirect("~/Product Engineering.aspx");
                        break;
                        //default: Response.Redirect("~/Home.aspx");
                        //    break;
                }
            }
        }
    }
}