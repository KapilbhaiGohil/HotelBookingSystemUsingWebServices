using HotelClient.ReservationService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelClient.Pages
{

    public partial class BookingForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["jsrooms"] == null)
            {
                Response.Redirect("~/Pages/Home.aspx");
            }
        }

        protected void finalBookButton_Click(object sender, EventArgs e)
        {
            FinalStorageData dt = JsonConvert.DeserializeObject<FinalStorageData>(hiddenField.Value);
            int res = new ReservationServiceClient().BookRoom(dt);
            if(res!=0) {
                Session["reservationInfo"] = hiddenField.Value;
                Session["bookingId"] = res;
                Session["msg"] = new Message("Thank you for choosing us.", Status.successful);
                Response.Redirect("~/Pages/BookingConfirmation.aspx"); 
            }
            else { }
        }
    }
}