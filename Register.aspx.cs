using Hotel_Application_445.ServicesRef;
using System;

namespace YourNamespace
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Initialization logic for the page
            // This method is called before the Page_Load event
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Service1Client service1 = new Service1Client();
            string storePassword = service1.HashPassword(password);


            if(service1.register(username, storePassword))
            {
                Response.Write("User added successfully");
            }
            else
            {
                Response.Write("User already exists");
            }
        }

        private bool IsValidInput()
        {
            // Add validation logic here
            // For example, check if username and password are not empty

            return !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }
    }
}
