using System;
using System.Web.Security;
using System.Web.UI;

namespace Hotel_Application_445
{
    public partial class StaffDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can perform any initialization or data retrieval here on page load
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void AddNewStaff_Click(object sender, EventArgs e)
        {
            // Handle logic for the "Add New Staff" button click
            // For example, redirect to a page for adding new staff
            Response.Redirect("~/AddNewStaff.aspx");
        }
        protected void AddStaffRoom_Click(object sender, EventArgs e) 
        {

            Response.Redirect("~/createNewRooms.aspx");
        }
    }
}
