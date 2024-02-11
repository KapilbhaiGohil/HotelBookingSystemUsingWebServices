using HotelClient.ReservationService;
using HotelClient.RoomService;
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
    public partial class ManageBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void findReservation_Click(object sender, EventArgs e)
        {
            try
            {
                int BookingId = Convert.ToInt32(bookingid.Text.Trim());
                string mail = email.Text.Trim();
                ReservationFull Reservation = new ReservationServiceClient().FindReservationByIdAndEmail(BookingId, mail);
                RoomService.RoomData[] RoomsInfo = new RoomServiceClient().getRoomsByReservationId(Reservation.Id);
                TimeSpan totalDaysSpan = Reservation.checkout - Reservation.checkin;
                int totalDays = (int)totalDaysSpan.TotalDays;
                FinalStorageData dt = new FinalStorageData();
                dt.checkin = Reservation.checkin.Date;
                dt.checkout =   Reservation.checkout.Date;
                dt.price = Reservation.amount;
                dt.totaldays = totalDays;
                ReservationService.RoomData[] RoomsInfo2 =  new ReservationService.RoomData[RoomsInfo.Length];
                int i = 0;
                foreach (var item in RoomsInfo)
                {
                    ReservationService.RoomData temp = new ReservationService.RoomData();
                    temp.price = item.price;
                    temp.children = item.children;
                    temp.adults = item.adults;
                    temp.heading = item.heading;
                    RoomsInfo2[i++] = temp;
                }
                dt.rooms = RoomsInfo2;
                dt.firstname = Reservation.firstname;
                dt.lastname = Reservation.lastname;
                dt.email = Reservation.email;
                dt.number = Reservation.phone;
                dt.specialrequest = Reservation.specialRequest;
                JavaScriptSerializer js = new JavaScriptSerializer();
                Session["reservationInfo"] = js.Serialize(dt);
                Session["bookingId"] = Reservation.Id;
                bookingid.Text = "";
                email.Text = "";
                Response.Redirect("~/Pages/BookingConfirmation.aspx");
            }
            catch (Exception ex)
            {
                string script = "showMsgManageBooking('" + ex.Message+"')";
                ClientScript.RegisterStartupScript(this.GetType(), "msgScript", script,true);
            }
        }
    }
}