using HotelClient.RoomService;
using HotelClient.ReservationService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelClient.Pages
{
    public class MembersInfo
    {
        public int children { get; set; }
        public int adult { get; set; }
    }
    public class BookingData
    {
        public List<MembersInfo> Rooms { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
    public partial class HeaderAndFooter : System.Web.UI.MasterPage
    {
        RoomServiceClient RoomServiceClient =  new RoomServiceClient();
        ReservationServiceClient ReservationServiceClient = new ReservationServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Pages/Home.aspx");
        }
        protected void complexData_Click(object sender, EventArgs e)
        {
            string jsondata = hiddenInput.Value;
            BookingData b = JsonConvert.DeserializeObject<BookingData>(jsondata);

            int[] conflictedResIds = ReservationServiceClient.getAllReservationConflicts(b.from,b.to);
            Room[] rooms = RoomServiceClient.getAvailabeRooms(b.Rooms.Count,b.Rooms.Max(room=>room.adult),conflictedResIds);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string jsrooms = javaScriptSerializer.Serialize(rooms);
            Session["jsrooms"] = jsrooms;
            Session["requiredRooms"] = jsondata;
            Session["checkin"] = b.from.Date.ToString("yyyy-MM-dd");
            Session["checkout"] = b.to.Date.ToString("yyyy-MM-dd");
            Session["roomsSize"] = b.Rooms.Count;
            Session["gauest"] = b.Rooms.Sum(room => room.adult);
            Session["child"] = b.Rooms.Sum(room => room.children);
            Response.Redirect("~/Pages/BookRoomList.aspx");
            
        }
    }
}