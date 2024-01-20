using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel_Application_445.ServicesRef;
using System.Linq;

namespace Hotel_Application_445
{
    public partial class HotelManage : System.Web.UI.Page
    {
        Service1Client service1Client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonString = service1Client.getAllRoomBookings();

            // Deserialize JSON string to dynamic object
            dynamic hotelAvailability = JsonConvert.DeserializeObject(jsonString);

            // Check if hotelAvailability is not null and has the RoomSelections property
            if (hotelAvailability != null && hotelAvailability.RoomSelections != null)
            {
                // Check if RoomSelections is not an empty string
                if (!string.IsNullOrEmpty(hotelAvailability.RoomSelections.ToString()))
                {
                    // Deserialize RoomSelections string to JObject
                    JObject roomSelections = JsonConvert.DeserializeObject<JObject>(hotelAvailability.RoomSelections.ToString());

                    // Check if "RoomSelections" property exists and is not null
                    if (roomSelections != null)
                    {
                        // Iterate over the values of the RoomSelections object
                        foreach (var roomType in roomSelections.Values())
                        {
                            // Create a Label for each property
                            Label typeLabel = new Label();
                            typeLabel.Text = $"Type: {roomType["RoomType"]}<br />";
                            form1.Controls.Add(typeLabel);

                            // Create a Label for displaying and updating the quantity
                            Label quantityLabel = new Label();
                            quantityLabel.ID = $"lblQuantity_{roomType["RoomType"]}";
                            quantityLabel.Text = $"Quantity: {roomType["Quantity"]}<br />";
                            form1.Controls.Add(quantityLabel);

                            // Create Button for storing information
                            Button addButton = new Button();
                            addButton.ID = $"btnAdd_{roomType["RoomType"]}";
                            addButton.Text = "Delete";
                            addButton.Click += btnAdd_Click;
                            form1.Controls.Add(addButton);

                            // Add a line break between room types
                            form1.Controls.Add(new LiteralControl("<br /><hr /><br />"));
                        }
                    }
                }
            }

            // Create "Back" button
            Button backButton = new Button();
            backButton.ID = "btnBack";
            backButton.Text = "Back";
            backButton.Click += btnBack_Click;
            form1.Controls.Add(backButton);
        }

        // Button click event handler
        // Button click event handler
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Identify the button that was clicked
            Button clickedButton = (Button)sender;

            // Extract the room type from the button ID
            string roomType = clickedButton.ID.Replace("btnAdd_", "");

            // Add logic to delete the entry from the database using the room type
            // For demonstration purposes, let's display a message
            Response.Write($"Entry for room type {roomType} deleted!");

            // Add your logic to delete the entry from the database based on room type
            // Replace the following line with your actual method to delete from the database
            service1Client.DeleteRoomSelection(roomType);

            // Remove corresponding UI elements
            RemoveUIElements(roomType);
        }

        private void RemoveUIElements(string roomType)
        {
            // Find and remove the Label for the room type
            Control typeLabel = form1.FindControl($"TypeLabel_{roomType}");
            if (typeLabel != null)
            {
                form1.Controls.Remove(typeLabel);
            }

            // Find and remove the Label for the quantity
            Control quantityLabel = form1.FindControl($"lblQuantity_{roomType}");
            if (quantityLabel != null)
            {
                form1.Controls.Remove(quantityLabel);
            }

            // Find and remove the Button for deleting
            Control deleteButton = form1.FindControl($"btnAdd_{roomType}");
            if (deleteButton != null)
            {
                form1.Controls.Remove(deleteButton);
            }

            // Add a line break between room types
            form1.Controls.Add(new LiteralControl("<br /><hr /><br />"));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Redirect to the home page or any other page after clicking "Back"
            Response.Redirect("Default.aspx");
        }
    }
}
