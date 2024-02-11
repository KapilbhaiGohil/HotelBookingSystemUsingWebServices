using HotelClient.UserService;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelClient.Pages
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msg"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "showMsg(" + new JavaScriptSerializer().Serialize(Session["msg"]) + ")", true);
                Session["msg"] = null;

            }
        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            string mail = email.Text;
            string password = pass.Text;
            User valid = new UserServiceClient().ValidateUser(mail, password);
            if (valid == null)
            {
                string errormsg = "Invalid Credential Received Pls Try Again With Correct Credential";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowError", "showMsg(" + new JavaScriptSerializer().Serialize(new Message(errormsg, Status.Error))+ ")", true);
         
            }
            else
            {
                Session["user"] = valid;
                Session["msg"] = new Message("Successful Login",Status.successful);
                Response.Redirect("~/Pages/Home.aspx");
            }
        }
        
    }
}