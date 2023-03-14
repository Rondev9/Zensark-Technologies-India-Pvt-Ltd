using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Excerciese___04_03_2023___Zensark_website
{
    public partial class Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int UserId = 0;
            string Role = "";
            using (SqlConnection con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["Connection"])))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_zensark_validate_user", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", LoginForm.UserName);
                cmd.Parameters.AddWithValue("@Password", LoginForm.Password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserId = Convert.ToInt32(reader["UserId"]);
                    Role = Convert.ToString(reader["Role"]);
                }
            }
            switch (UserId)
            {
                case -1:
                    LoginForm.FailureText = "Invalid Username or Password!";
                    break;
                default:
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, LoginForm.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), LoginForm.RememberMeSet, Role, FormsAuthentication.FormsCookiePath);
                    string hashed = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookies = new HttpCookie(FormsAuthentication.FormsCookieName, hashed);
                    if (ticket.IsPersistent)
                    {
                        cookies.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookies);
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(LoginForm.UserName, LoginForm.RememberMeSet));
                    break;
            }
        }
    }
}