using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Hotel_Application_445.ServicesRef;

namespace Hotel_Application_445
{
    public partial class listAvailableRooms : System.Web.UI.Page
    {
        Service1Client service1Client = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonString = service1Client.getAllAvailable();

            // Deserialize JSON string to dynamic object
            dynamic hotelAvailability = JsonConvert.DeserializeObject(jsonString);

            // Access the RoomType array
            JArray roomTypes = hotelAvailability.HotelAvailability.RoomType;

            // Create rows for each room type
            foreach (var roomType in roomTypes)
            {
                // Create a Label for each property
                Label typeLabel = new Label();
                typeLabel.Text = $"Type: {roomType["Type"]}<br />";
                form1.Controls.Add(typeLabel);

                // Create a Label for displaying and updating the quantity
                Label quantityLabel = new Label();
                quantityLabel.ID = $"lblQuantity_{roomType["Type"]}";
                quantityLabel.Text = $"Quantity: {roomType["Quantity"]}<br />";
                form1.Controls.Add(quantityLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = $"Description: {roomType["Description"]}<br />";
                form1.Controls.Add(descriptionLabel);

                Label costLabel = new Label();
                costLabel.Text = $"Cost: {roomType["Cost"]}<br />";
                form1.Controls.Add(costLabel);

                // Create TextBox for entering the number of rooms
                TextBox quantityTextBox = new TextBox();
                quantityTextBox.ID = $"txtQuantity_{roomType["Type"]}";
                quantityTextBox.Attributes["placeholder"] = "Enter quantity";
                form1.Controls.Add(quantityTextBox);

                // Create Button for storing information
                Button addButton = new Button();
                addButton.ID = $"btnAdd_{roomType["Type"]}";
                addButton.Text = "Add";
                addButton.Click += btnAdd_Click;
                form1.Controls.Add(addButton);

                // Add a line break between room types
                form1.Controls.Add(new LiteralControl("<br /><hr /><br />"));
            }

            // Create "Back" button
            Button backButton = new Button();
            backButton.ID = "btnBack";
            backButton.Text = "Back";
            backButton.Click += btnBack_Click;
            form1.Controls.Add(backButton);

            // Create "Confirmation" button
            Button confirmationButton = new Button();
            confirmationButton.ID = "btnConfirmation";
            confirmationButton.Text = "Confirmation";
            confirmationButton.Click += btnConfirmation_Click;
            form1.Controls.Add(confirmationButton);
        }


        // Button click event handler
        // Button click event handler
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Identify the button that was clicked
            Button clickedButton = (Button)sender;

            // Extract the room type from the button ID
            string roomType = clickedButton.ID.Replace("btnAdd_", "");

            // Find the corresponding TextBox by ID
            TextBox quantityTextBox = (TextBox)form1.FindControl($"txtQuantity_{roomType}");

            if (quantityTextBox != null)
            {
                // Get the entered quantity
                string quantityString = quantityTextBox.Text;

                // Check if the entered quantity is a valid integer
                if (int.TryParse(quantityString, out int quantity))
                {
                    // Access the dynamic object from JSON
                    dynamic hotelAvailability = JsonConvert.DeserializeObject(service1Client.getAllAvailable());
                    JArray roomTypes = hotelAvailability.HotelAvailability.RoomType;

                    // Find the selected room type
                    var selectedRoomType = roomTypes.FirstOrDefault(rt => rt["Type"].ToString() == roomType);

                    if (selectedRoomType != null)
                    {
                        int availableQuantity = (int)selectedRoomType["Quantity"];

                        // Check if the entered quantity is less than or equal to the available rooms
                        if (quantity > 0 && quantity <= availableQuantity)
                        {
                            // You can now process and store the information as needed
                            // For demonstration, we'll just display it in a label
                            Label resultLabel = new Label();
                            resultLabel.Text = $"You want to book {quantity} rooms of type {roomType}.";
                            form1.Controls.Add(resultLabel);

                            // Now, you can add the quantity to the database
                            service1Client.AddRoomSelection(roomType, quantity);

                            availableQuantity = availableQuantity - quantity;
                            service1Client.ModifyRoomQuantity(roomType, availableQuantity);

                            // Update the displayed quantity in the UI
                            Label quantityLabelToUpdate = (Label)form1.FindControl($"lblQuantity_{roomType}");
                            if (quantityLabelToUpdate != null)
                            {
                                quantityLabelToUpdate.Text = $"Quantity: {availableQuantity}<br />";
                            }
                        }
                        else
                        {
                            // Display an error message if the quantity is invalid
                            Label errorLabel = new Label();
                            errorLabel.Text = "Invalid quantity. Please enter a valid number of rooms.";
                            form1.Controls.Add(errorLabel);
                        }
                    }
                }
                else
                {
                    // Display an error message if the entered quantity is not a valid integer
                    Label errorLabel = new Label();
                    errorLabel.Text = "Invalid quantity. Please enter a valid number.";
                    form1.Controls.Add(errorLabel);
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Redirect to the home page or any other page after clicking "Back"
            Response.Redirect("Default.aspx");
        }

        protected void btnConfirmation_Click(object sender, EventArgs e)
        {
            // Redirect to the confirmation page after clicking "Confirmation"
            Response.Redirect("Confirmation.aspx");
        }

    }
}