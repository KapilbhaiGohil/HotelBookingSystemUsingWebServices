using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HotelService
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        string cancelReservation(int resId);
        [OperationContract]
        ReservationFull FindReservationByIdAndEmail(int id, string email);
        [OperationContract]
        int BookRoom(FinalStorageData dt);
        [OperationContract]
        List<int> getAllReservationConflicts(DateTime checkin, DateTime checkout);
        [OperationContract]
        List<Reservation> GetALlReservationIds();
    }
    public class ReservationService : IReservationService
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HotelBookingConnection"].ConnectionString;
        public List<Reservation> GetALlReservationIds()
        {
            List<Reservation> reservationIds = new List<Reservation>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select id,checkin,checkout from reservation";
            SqlCommand cmd = new SqlCommand(@query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = (int)rdr["id"];
                DateTime checkin = DateTime.Parse(rdr["checkin"].ToString());
                DateTime checkout = DateTime.Parse(rdr["checkout"].ToString());
                reservationIds.Add(new Reservation().ReservationInitialize(id, checkin, checkout));
            }
            con.Close();
            cmd.Dispose();
            return reservationIds;
        }
        public List<int> getAllReservationConflicts(DateTime checkin, DateTime checkout)
        {
            List<int> conflictedResIds = new List<int>();
            List<Reservation> allres = new ReservationService().GetALlReservationIds();
            foreach (Reservation reservation in allres)
            {
                if (reservation.checkin <= checkout && reservation.checkout >= checkin)
                {
                    conflictedResIds.Add(reservation.Id);
                }
            }
            return conflictedResIds;
        }
        public int BookRoom(FinalStorageData dt)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            try
            {
                List<int> ConfliectResIds = new ReservationService().getAllReservationConflicts(dt.checkin, dt.checkout);
                string insertQuery = "INSERT INTO reservation (checkin, checkout, amount, firstname, lastname, email, phone, specialRequest,date) " +
                    "VALUES (@checkin, @checkout, @amount, @firstname, @lastname, @email, @phone, @specialRequest, @date);SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(insertQuery, con, transaction);
                command.Parameters.AddWithValue("@checkin", dt.checkin);
                command.Parameters.AddWithValue("@checkout", dt.checkout);
                command.Parameters.AddWithValue("@amount", dt.price);
                command.Parameters.AddWithValue("@firstname", dt.firstname);
                command.Parameters.AddWithValue("@lastname", dt.lastname);
                command.Parameters.AddWithValue("@email", dt.email);
                command.Parameters.AddWithValue("@phone", dt.number);
                command.Parameters.AddWithValue("@specialRequest", dt.specialrequest);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                int reservationId = Convert.ToInt32(command.ExecuteScalar());
                List<int> AddedIds = new List<int>();
                string getEachRoomIdQeryCopy = @"select top(1) id from eachroom where RoomTypeId = 
                        (
	                        select id from room where type = @roomType
                        ) and id in (select id from eachroom where id not in(
	                        select eachroomid from reservationeachroom where reservationid in ({0})
                        )) and id not in ({1});";
                foreach (RoomData room in dt.rooms)
                {
                    string conflictedRoomsParam = ConfliectResIds.Count > 0 ? string.Join(",", ConfliectResIds) : "NULL";
                    string alreadyAddedIds = AddedIds.Count > 0 ? string.Join(",", AddedIds) : "-1";
                    string getEachRoomIdQery = string.Format(getEachRoomIdQeryCopy, conflictedRoomsParam, alreadyAddedIds);
                    SqlCommand geteachroomidcmd = new SqlCommand(getEachRoomIdQery, con, transaction);
                    geteachroomidcmd.Parameters.AddWithValue("@roomType", room.heading);
                    int eachRoomId = Convert.ToInt32(geteachroomidcmd.ExecuteScalar());
                    string insertIntoReservationRoom = "INSERT INTO reservationeachroom (reservationid, eachroomid, adult, children, price) " +
                      "VALUES (@ReservationId, @EachRoomId, @Adult, @Children, @Price);SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(insertIntoReservationRoom, con, transaction);
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd.Parameters.AddWithValue("@EachRoomId", eachRoomId);
                    cmd.Parameters.AddWithValue("@Adult", room.adults);
                    cmd.Parameters.AddWithValue("@Children", room.children);
                    cmd.Parameters.AddWithValue("@Price", room.price);
                    int newid = Convert.ToInt32(cmd.ExecuteScalar());
                    AddedIds.Add(eachRoomId);

                }
                transaction.Commit();
                return reservationId;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return 0;
            }
            finally
            {
                con.Close();
                transaction.Dispose();
            }
        }
        private void DeleteReservationsPastCheckout()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                // Step 1: Retrieve reservation IDs where checkout < today
                string retrieveQuery = "SELECT id FROM reservation WHERE checkout < @today";
                SqlCommand retrieveCmd = new SqlCommand(retrieveQuery, con, tran);
                retrieveCmd.Parameters.AddWithValue("@today", DateTime.Today);
                SqlDataReader retrieveReader = retrieveCmd.ExecuteReader();

                List<int> reservationIds = new List<int>();
                while (retrieveReader.Read())
                {
                    reservationIds.Add(retrieveReader.GetInt32(0));
                }
                retrieveReader.Close(); // Close the reader after use

                // Step 2: Delete entries from reservationeachroom table
                string deleteEachRoomQuery = "DELETE FROM reservationeachroom WHERE reservationid = @resId";
                SqlCommand deleteEachRoomCmd = new SqlCommand(deleteEachRoomQuery, con, tran);
                foreach (int resId in reservationIds)
                {
                    deleteEachRoomCmd.Parameters.Clear();
                    deleteEachRoomCmd.Parameters.AddWithValue("@resId", resId);
                    deleteEachRoomCmd.ExecuteNonQuery();
                }

                // Step 3: Delete entries from reservation table
                string deleteReservationQuery = "DELETE FROM reservation WHERE id = @resId";
                SqlCommand deleteReservationCmd = new SqlCommand(deleteReservationQuery, con, tran);
                foreach (int resId in reservationIds)
                {
                    deleteReservationCmd.Parameters.Clear();
                    deleteReservationCmd.Parameters.AddWithValue("@resId", resId);
                    deleteReservationCmd.ExecuteNonQuery();
                }

                // Commit transaction if everything succeeded
                tran.Commit();
            }
            catch (Exception ex)
            {
                // Rollback transaction if an error occurred
                tran.Rollback();
                throw ex; // Rethrow the exception to handle it at higher level
            }
            finally
            {
                con.Close();
            }
        }

        public ReservationFull FindReservationByIdAndEmail(int id, string email)
        {
            DeleteReservationsPastCheckout();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from reservation where id = @id and email = @email;";
            SqlCommand cmd = new SqlCommand(query, con);
            ReservationFull reservationsList = null;
            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    reservationsList = new ReservationFull().ReservationFullInitialize(
                        Convert.ToInt32(rdr["id"]),
                        DateTime.Parse(rdr["checkin"].ToString()),
                        DateTime.Parse(rdr["checkout"].ToString()),
                        Convert.ToInt32(rdr["amount"]),
                        rdr["firstname"].ToString(),
                        rdr["lastname"].ToString(),
                        rdr["email"].ToString(),
                        rdr["phone"].ToString(),
                        rdr["specialrequest"].ToString(),
                        DateTime.Parse(rdr["date"].ToString())
                        );
                }
                return reservationsList;
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
        public string cancelReservation(int resId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            string validate = "select checkin from reservation where id = @resId";
            SqlCommand validateCmd = new SqlCommand(validate, con);
            validateCmd.Parameters.AddWithValue("@resId", resId);
            validateCmd.Transaction = tran;

            try
            {
                using (SqlDataReader rdr = validateCmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        DateTime checkinDate = rdr.GetDateTime(0);
                        DateTime today = DateTime.Today;
                        DateTime minAllowded = today.AddDays(1);
                        if (checkinDate < minAllowded)
                        {
                            return "You are not allowed to cancel your booking.";
                        }
                    }
                    else
                    {
                        return "No booking found with the given ID.";
                    }
                }

                string query1 = "delete from reservationeachroom where reservationid = @resId";
                SqlCommand cmd1 = new SqlCommand(query1, con, tran);
                cmd1.Parameters.AddWithValue("@resId", resId);
                int rowsAffected1 = cmd1.ExecuteNonQuery();

                string query2 = "delete from reservation where id = @resId";
                SqlCommand cmd2 = new SqlCommand(query2, con, tran);
                cmd2.Parameters.AddWithValue("@resId", resId);
                int rowsAffected2 = cmd2.ExecuteNonQuery();

                if (rowsAffected1 > 0 && rowsAffected2 > 0)
                {
                    tran.Commit();
                    return "Cancellation successful.";
                }
                else
                {
                    tran.Rollback();
                    return "No booking found or error occurred.";
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return "Internal server error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }
    [DataContract]
    public class Reservation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime checkin { get; set; }
        [DataMember]
        public DateTime checkout { get; set; }
        public Reservation ReservationInitialize(int id, DateTime checkin, DateTime checkout)
        {
            this.Id = id;
            this.checkin = checkin;
            this.checkout = checkout;
            return this;
        }
    }
    [DataContract]
    public class ReservationFull
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime checkin { get; set; }
        [DataMember]
        public DateTime checkout { get; set; }
        [DataMember]
        public int amount { get; set; }
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string specialRequest { get; set; }
        [DataMember]
        public DateTime date { get; set; }
    
        public ReservationFull ReservationFullInitialize(int id, DateTime checkin, DateTime checkout, int amount, string firstname, string lastname, string email, string phone, string specialRequest, DateTime date)
        {
            Id = id;
            this.checkin = checkin;
            this.checkout = checkout;
            this.amount = amount;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phone = phone;
            this.specialRequest = specialRequest;
            this.date = date;
            return this;
        }
    }
    public class FinalStorageData
    {
        public DateTime checkin;
        public DateTime checkout;
        public long price;
        public int totaldays;
        public List<RoomData> rooms;
        public string firstname;
        public string lastname;
        public string email;
        public string number;
        public string specialrequest;
        public FinalStorageData FinalStorageDataInitialize(DateTime checkin, DateTime checkout, long price, int totaldays, List<RoomData> rooms, string firstname, string lastname, string email, string number, string specialrequest)
        {
            this.checkin = checkin;
            this.checkout = checkout;
            this.price = price;
            this.totaldays = totaldays;
            this.rooms = rooms;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.number = number;
            this.specialrequest = specialrequest;
            return this;
        }
        public FinalStorageData() { }
    }
}