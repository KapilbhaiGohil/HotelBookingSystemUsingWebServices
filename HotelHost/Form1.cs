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
                Uri tcpuri = new Uri("net.tcp://localhost:8000/TcpBinding");
                Uri tcpuri2 = new Uri("net.tcp://localhost:8001/TcpBinding");
                Uri tcpuri3 = new Uri("net.tcp://localhost:8002/TcpBinding");

                sh = new ServiceHost(typeof(HotelService.RoomService), tcpuri);
                sh2 = new ServiceHost(typeof(HotelService.ReservationService), tcpuri2);
                sh3 = new ServiceHost(typeof(HotelService.UserService), tcpuri3);

                NetTcpBinding tcpb = new NetTcpBinding();
                NetTcpBinding tcpb2 = new NetTcpBinding();
                NetTcpBinding tcpb3 = new NetTcpBinding();

                ServiceMetadataBehavior mBehcave = new ServiceMetadataBehavior();
                ServiceMetadataBehavior mBehcave2 = new ServiceMetadataBehavior();
                ServiceMetadataBehavior mBehcave3 = new ServiceMetadataBehavior();

                sh.Description.Behaviors.Add(mBehcave);
                sh2.Description.Behaviors.Add(mBehcave2);
                sh3.Description.Behaviors.Add(mBehcave3);

                sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                sh2.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                sh3.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                
                sh.AddServiceEndpoint(typeof(HotelService.IRoomService), tcpb, tcpuri);
                sh2.AddServiceEndpoint(typeof(HotelService.IReservationService), tcpb2, tcpuri2);
                sh3.AddServiceEndpoint(typeof(HotelService.IUserService), tcpb3, tcpuri3);

                sh.Open();
                sh2.Open();
                sh3.Open();

                label1.Text = "Services are Running";
                button1.Text = "Stop";
            }
        }
    }
}
