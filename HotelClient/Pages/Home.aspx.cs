using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using HotelClient.Pages;
using HotelClient.RoomService;

/*using Message = HotelClient.Pages.Message;*/

namespace HotelClient
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msg"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(),"msg", "showMsg(" + new JavaScriptSerializer().Serialize(Session["msg"])+")", true);
                Session["msg"] = null;

            }
            RoomServiceClient roomService = new RoomServiceClient();
            Room[] rooms = roomService.GetRooms();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string obj = javaScriptSerializer.Serialize(rooms);
            Session["RefactorRooms"] = obj;
            Session["checkin"] = null;
            Session["checkout"] = null;
            Session["jsrooms"] = null;
            Session["reservationInfo"] = null;
            Session["bookingId"] = null;
        }
    }
}