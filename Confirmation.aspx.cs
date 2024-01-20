using System;
using Hotel_Application_445.ServicesRef;
using Newtonsoft.Json.Linq;

namespace Hotel_Application_445
{
    public partial class ConfirmationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client service1Client = new Service1Client();

            // Get the JSON string from the database or any source
            string jsonString = service1Client.getAllRoomBookings();

            // Deserialize JSON string to dynamic object
            dynamic roomSelections = JObject.Parse(jsonString)["RoomSelections"]["RoomSelection"];

            // Check if it's an array or a single object
            if (roomSelections is JArray)
            {
                // If it's an array, handle each item
                foreach (var roomSelection in roomSelections)
                {
                    DisplayConfirmation(roomSelection);
                }
            }
            else
            {
                // If it's a single object, directly display confirmation
                DisplayConfirmation(roomSelections);
            }
        }

        private void DisplayConfirmation(dynamic roomSelection)
        {
            // Display confirmation information
            litConfirmation.Text += $"<label><span>Room Type:</span> {roomSelection.RoomType}</label>";
            litConfirmation.Text += $"<label><span>Quantity:</span> {roomSelection.Quantity}</label>";
            // Add any other information you want to display
            litConfirmation.Text += "<br />";
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Redirect to the home page or any other page after confirmation
            Response.Redirect("Default.aspx");
        }
    }
}
