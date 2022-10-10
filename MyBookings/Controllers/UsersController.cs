using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<Users> users = new List<Users>();
        public Users user;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            string query = "execute spGetUsers";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");

            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            users.Add(new Users(myReader.GetInt32(0), myReader.GetString(1), myReader.GetString(2), myReader.GetInt64(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }

            return users;
        }


        [HttpGet("{uid}")]
        public Users GetUser(int uid)
        {
            string query = $"execute spGetParticularUser {uid}";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");

            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            user = new Users(myReader.GetInt32(0), myReader.GetString(1), myReader.GetString(2), myReader.GetInt64(3), myReader.GetString(4),myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }   
            }

            return user;
        }

        [HttpPost]
        public void Post(Users user)
        {
            string query = $"execute spUpdateUser @UserID,@UserName,@Birthday,@Gender,@MartialStatus";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");

            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@UserID", user.UserID);
                    myCommand.Parameters.AddWithValue("UserName", user.UserName);
                    myCommand.Parameters.AddWithValue("Birthday", user.Birthday);
                    myCommand.Parameters.AddWithValue("Gender", user.Gender);
                    myCommand.Parameters.AddWithValue("MartialStatus", user.MartialStatus);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConnection.Close();
                }
            }

            return;
        }


        [HttpPut]
        public void Put(Users urs)
        {
            string query = $"execute spUpdateImage @UserID,@ImageName";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");

            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@UserID", urs.UserID);
                    myCommand.Parameters.AddWithValue("@ImageName", urs.ImageName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConnection.Close();
                }
            }

            return;
        }
    }
}
