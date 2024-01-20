using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel_Application_445.ServicesRef;

namespace Hotel_Application_445
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            Service1Client service1Client = new Service1Client();

            string type = txtRoomType.Value.Trim();
            string quantityStr = txtRoomQuantity.Value.Trim();
            string desc = txtRoomDescription.Value.Trim();
            string costStr = txtRoomCost.Value.Trim();

            int quantity;
            float cost;

            if (int.TryParse(quantityStr, out quantity) && float.TryParse(costStr, out cost))
            {
                if(!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(desc))
                {

                    service1Client.AddNewRooms(type, quantity, desc, cost);
                    Response.Write("New Room added successfully");
                }
                else
                {
                    Response.Write("Please enter the room name and room description");
                }
            }
            else
            {
                Response.Write("Please enter quantity as int and cost as float.");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}