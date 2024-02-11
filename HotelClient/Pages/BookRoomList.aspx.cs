using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelClient.Pages
{
    public partial class BookRoomList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["jsrooms"] == null)
            {
                Response.Redirect("~/Pages/Home.aspx");
            }
        }

        protected void complexDataForBookingData_Click(object sender, EventArgs e)
        {
            Session["finalBookingData"] = hiddenInputForBookingData.Value;
            Response.Redirect("~/Pages/BookingForm.aspx");
        }
    }
}