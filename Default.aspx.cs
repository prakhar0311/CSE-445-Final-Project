using System;
using System.Web.Security;
using System.Web.UI;

namespace WebApplication_HotelDashboard
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // You can add code that should run when the page is loaded here.
        }

        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/listAvailableRooms.aspx");
            // This method is triggered when the "Add Room" button is clicked.

            // Get the values from the form controls


            // Add your logic to save the room information to a database or perform any other desired action
            // For simplicity, let's just display a message for now

        }
        protected void btnManageReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageReservation.aspx");
            // This method is triggered when the "Manage Reservation" button is clicked.
            // Add your logic for managing reservations here.
            Response.Write("Manage Reservation button clicked!");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnStaff_Click(object sender, EventArgs e) 
        {
            Response.Redirect("~/IsStaff.aspx");
        }
    }
}
