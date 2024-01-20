using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Hotel_Application_445
{
    public partial class IsStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can add code here that needs to be executed when the page loads.
        }

        protected void btnCheckStaff_Click(object sender, EventArgs e)
        {
            // Code to check username and password
            TextBox usernameTextBox = (TextBox)FindControl("username");
            TextBox passwordTextBox = (TextBox)FindControl("password");

            if (usernameTextBox != null && passwordTextBox != null)
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;

                // Perform your authentication logic here
                if (IsValidStaff(username, password))
                {
                    // Successful login
                    Response.Write("Login successful. You are a staff member.");
                }
                else
                {
                    // Failed login
                    Response.Write("Invalid username or password. Please try again.");
                }
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        private bool IsValidStaff(string username, string password)
        {
            // Your authentication logic goes here
            // For simplicity, let's assume a hard-coded username and password
            return username == "staff" && password == "password";
        }

        protected void btnNewStaff_Click(object sender, EventArgs e)
        {

        }
    }
}
