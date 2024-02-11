using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HotelService
{
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        List<Room> GetRooms();
        [OperationContract]
        List<RoomData> getRoomsByReservationId(int resId);
        [OperationContract]
        List<Room> getAvailabeRooms(int noOfRooms, int minCapasity, List<int> ConflictedResIds);
        [OperationContract]
        List<int> getAllEachRoomsByReservationId(int rid);
        [OperationContract]
        List<int> getAllRoomsByRoomTypeId(int roomTypeId);
        [OperationContract]
        int getFreeRoomIdByRoomHeading(string heading);
    }
    public class RoomService : IRoomService
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HotelBookingConnection"].ConnectionString;
        public List<Room> GetRooms()
        {
            List<Room> list = new List<Room>();
            string query = "SELECT * FROM room";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string id = rdr["ID"].ToString();
                string type = rdr["type"].ToString();
                string desc = rdr["desc"].ToString();
                string area = rdr["area"].ToString();
                string capasity = rdr["capasity"].ToString();
                string price = rdr["price"].ToString();
                string bedtype = rdr["bedtype"].ToString();
                list.Add(new Room(Int32.Parse(id), type, desc, area, Int32.Parse(capasity), Int32.Parse(price), bedtype));
            }

            con.Close();
            cmd.Dispose();
            return list;
        }
        public int getFreeRoomIdByRoomHeading(string heading)
        {
            int id = -1;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select id from room where type = @type";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@roomtypeid", heading);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                id = Convert.ToInt32(rdr["id"]);
            }
            rdr.Close();
            cmd.Dispose();
            con.Close();
            return id;
        }
        public List<int> getAllRoomsByRoomTypeId(int roomTypeId)
        {
            List<int> ans = new List<int>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from eachroom where  roomtypeid = @roomtypeid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@roomtypeid", roomTypeId);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ans.Add(Convert.ToInt32(rdr["roomtypeid"]));
            }
            rdr.Close();
            cmd.Dispose();
            con.Close();
            return ans;
        }
        public List<int> getAllEachRoomsByReservationId(int rid)
        {
            List<int> ans = new List<int>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select eachroomid form reservationeachroom where reservationid = @rid";
            SqlCommand cmd = new SqlCommand(@query, con);
            cmd.Parameters.AddWithValue("@rid", rid);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ans.Add((int)rdr["eachroomid"]);
            }
            cmd.Dispose();
            con.Close();
            return ans;
        }
        public List<Room> getAvailabeRooms(int noOfRooms, int minCapasity, List<int> ConflictedResIds)
        {
            List<Room> ans = new List<Room>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = @"select * from room where id in (
                                select roomtypeid from eachroom where id not in (
                                       select id from eachroom where id in(
                                            select eachroomid from reservationeachroom where reservationid in ({0}))
                                )group by roomtypeid  having count(*) >= @noOfRooms
                           ) and capasity >= @minCapasity;";

            string conflictedRoomsParam = ConflictedResIds.Count > 0 ? string.Join(",", ConflictedResIds) : "NULL";
            query = string.Format(query, conflictedRoomsParam);
            SqlCommand cmd = new SqlCommand(@query, con);
            cmd.Parameters.AddWithValue("@minCapasity", minCapasity);
            cmd.Parameters.AddWithValue("@noOfRooms", noOfRooms);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string id = rdr["ID"].ToString();
                string type = rdr["type"].ToString();
                string desc = rdr["desc"].ToString();
                string area = rdr["area"].ToString();
                string capasity = rdr["capasity"].ToString();
                string price = rdr["price"].ToString();
                string bedtype = rdr["bedtype"].ToString();
                ans.Add(new Room(Int32.Parse(id), type, desc, area, Int32.Parse(capasity), Int32.Parse(price), bedtype));
            }
            cmd.Dispose();
            con.Close();
            return ans;
        }
        public List<RoomData> getRoomsByReservationId(int resId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = @"SELECT
                            re.Adult,
                            re.Children,
                            re.Price,
                            ro.Type
                        FROM
                            reservationeachroom re
                        JOIN
                            eachroom er ON re.eachroomid = er.id
                        JOIN
                            room ro ON er.RoomTypeId = ro.id
                        WHERE
                            re.reservationid = @resId;
";
            SqlCommand cmd = new SqlCommand(@query, con);
            List<RoomData> res = new List<RoomData>();
            try
            {
                cmd.Parameters.AddWithValue("@resId", resId);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    res.Add(new RoomData(rdr["Type"].ToString(), rdr["Price"].ToString(), rdr["Adult"].ToString(), rdr["Children"].ToString()));
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }


        }

    }
    [DataContract]
    public class Room
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Desc { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public int Capasity { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string Bedtype { get; set; }


        public Room(int iD, string type, string desc, string area, int capasity, int price, string bedtype)
        {
            ID = iD;
            Type = type;
            Desc = desc;
            Area = area;
            Capasity = capasity;
            Price = price;
            Bedtype = bedtype;
        }
    }
    public class eachroom
    {
        public int ID { get; set; }
        public int RoomTypeId { get; set; }
    }
    [DataContract]
    public class RoomData
    {
        [DataMember]
        public string heading;
        [DataMember]
        public string price;
        [DataMember]
        public string adults;
        [DataMember]
        public string children;
        public RoomData(string heading, string price, string adults, string children)
        {
            this.heading = heading;
            this.price = price;
            this.adults = adults;
            this.children = children;
        }
        public RoomData() { }
    }
}
