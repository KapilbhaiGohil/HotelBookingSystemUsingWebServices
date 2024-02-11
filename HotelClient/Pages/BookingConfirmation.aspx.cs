using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Html2pdf;
using iText.IO.Source;
using HotelClient.ReservationService;

namespace HotelClient.Pages
{
    public class Message
    {
        public string info;
        public Status status;
        public Message(string info, Status status)
        {
            this.info = info;
            this.status = status;
        }
    }
    public enum Status{
        successful,
        Error
    }
    public partial class BookingConfirmation : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write(Session["reservationInfo"]);
            //Response.Write(HttpContext.Current.Server.MapPath("/Pages/"));
            Session["jsrooms"] = null;
        }
        protected void print_Click(object sender, EventArgs e)
        {
            using(MemoryStream pdfstream = new MemoryStream()) {
                ConverterProperties properties = new ConverterProperties();
                properties.SetBaseUri(HttpContext.Current.Server.MapPath("/Pages/"));
                string htmlContent = hiddenInnerHtml.Value;
                HtmlConverter.ConvertToPdf(htmlContent, pdfstream,properties);
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline;filename=bill.pdf");
                Response.BinaryWrite(pdfstream.ToArray());
                Response.Flush();
                Response.End();
            }
        }

        protected void cancelBook_Click(object sender, EventArgs e)
        {
            if (Session["bookingId"] == null)
            {
                Response.Redirect("~/Pages/Home.aspx");
            }
            int bookingId = (int)Session["bookingId"];
            bool res = new ReservationServiceClient().cancelReservation(bookingId);
            if (res)
            {
                Session["msg"] = new Message("Your Booking SuccessFully Cancelled",Status.successful);
                Response.Write("success");
            }
            else
            {
                Session["msg"] = new Message("Might Be Some Internal Server Error Or Booking Already Cancelled ", Status.Error);
                Response.Write("error");
            }
           Response.Redirect("~/Pages/Home.aspx");
        }
    }
}