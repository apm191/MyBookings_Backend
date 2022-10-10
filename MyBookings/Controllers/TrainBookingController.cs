using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainBookingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<TrainBooking> trains = new List<TrainBooking>();
        public TrainBooking train;
        public TrainBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public IEnumerable<TrainBooking> Get(int uid)
        {
            string query = $"exec spGetTrain {uid}";
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
                            trains.Add(new TrainBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetInt32(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetString(12), myReader.GetString(13),myReader.GetInt32(14),myReader.GetString(15), myReader.GetString(16), myReader.GetString(17), myReader.GetString(18)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return trains;
        }


        [HttpGet("{bookid}")]

        public TrainBooking GetUser(int bookid)
        {
            string query = $"exec spGetParticularTrain {bookid}";
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
                            train = new TrainBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetInt32(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetString(12), myReader.GetString(13), myReader.GetInt32(14), myReader.GetString(15), myReader.GetString(16), myReader.GetString(17), myReader.GetString(18));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return train;
        }

        [HttpPost("{id}")]

        public void Post(int id)
        {
            string query = $"execute spUpdateTrainStatus {id}";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");

            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
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
