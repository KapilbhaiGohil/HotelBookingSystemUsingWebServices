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
    public interface IUserService
    {
        [OperationContract]
        User ValidateUser(string email, string pass);
        [OperationContract]
        bool AddUser(User u);
    }
    public class UserService : IUserService
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HotelBookingConnection"].ConnectionString;
        public User ValidateUser(string email, string pass)
        {
            User user = null;
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select * from [user] where email=@email and password = @pass";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                user = new User((int)rdr["id"], rdr["name"].ToString(), rdr["email"].ToString(), rdr["password"].ToString(), rdr["phone"].ToString());
            }
            con.Close();
            cmd.Dispose();
            return user;
        }
        public bool AddUser(User u)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO [user] (name, email, password, phone) VALUES (@name, @email, @password, @phone)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", u.Name);
                        cmd.Parameters.AddWithValue("@email", u.Email);
                        cmd.Parameters.AddWithValue("@password", u.Password);
                        cmd.Parameters.AddWithValue("@phone", u.Phone);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
    [DataContract]
    public class User 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Phone { get; set; }
        public User(int id, string name, string email, string password, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
        public User(string name, string email, string password, string phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}
