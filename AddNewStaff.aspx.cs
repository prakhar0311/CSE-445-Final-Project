using Hotel_Application_445.ServicesRef;
using System;
using System.Web.Security;
using System.Web.UI;

namespace Hotel_Application_445
{
    public partial class AddNewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Code for page load event
        }

        protected void btnNewStaff_click(object sender, EventArgs e)
        {
            Service1Client service1 = new Service1Client();
            string username = txtUsername.Text.Trim();
            string result = service1.PromoteToStaff(username);

            Response.Write(result);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
