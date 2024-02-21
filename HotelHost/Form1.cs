using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HotelHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ServiceHost sh = null;
        ServiceHost sh2 = null;
        ServiceHost sh3 = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="Stop")
            {
                sh.Close();
                sh2.Close();
                sh3.Close();
                button1.Text = "Start";
                label1.Text = "Services are not Running";
            }
            else
            {
                string baseAddress = "http://localhost/HotelBookingServices/";
                Uri httpUri1 = new Uri(baseAddress+"RoomService");
                Uri httpUri2 = new Uri(baseAddress + "ReservationService");
                Uri httpUri3 = new Uri(baseAddress + "UserService");


                sh = new ServiceHost(typeof(HotelService.RoomService), httpUri1);
                sh2 = new ServiceHost(typeof(HotelService.ReservationService), httpUri2);
                sh3 = new ServiceHost(typeof(HotelService.UserService), httpUri3);

                BasicHttpBinding binding1 = new BasicHttpBinding();
                BasicHttpBinding binding2 = new BasicHttpBinding();
                BasicHttpBinding binding3 = new BasicHttpBinding();

                ServiceMetadataBehavior mBehcave1 = new ServiceMetadataBehavior();
                ServiceMetadataBehavior mBehcave2 = new ServiceMetadataBehavior();
                ServiceMetadataBehavior mBehcave3 = new ServiceMetadataBehavior();
                mBehcave1.HttpGetEnabled = true;
                mBehcave2.HttpGetEnabled = true;
                mBehcave3.HttpGetEnabled = true;
                sh.Description.Behaviors.Add(mBehcave1);
                sh2.Description.Behaviors.Add(mBehcave2);
                sh3.Description.Behaviors.Add(mBehcave3);

                sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                sh2.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                sh3.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

                sh.AddServiceEndpoint(typeof(HotelService.IRoomService), binding1, httpUri1);
                sh2.AddServiceEndpoint(typeof(HotelService.IReservationService), binding2, httpUri2);
                sh3.AddServiceEndpoint(typeof(HotelService.IUserService), binding3, httpUri3);

                sh.Open();
                sh2.Open();
                sh3.Open();

                label1.Text = "Services are Running";
                button1.Text = "Stop";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
