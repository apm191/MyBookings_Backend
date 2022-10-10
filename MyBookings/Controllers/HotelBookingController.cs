using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<HotelBooking> hotels = new List<HotelBooking>();
        public HotelBooking hotel;

        public HotelBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public IEnumerable<HotelBooking> Get(int uid)
        {
            string query = $"exec spGetHotels {uid}";
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
                            hotels.Add(new HotelBooking(myReader.GetInt32(0), myReader.GetInt32(1),myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return hotels;
        }

        [HttpGet("{bookid}")]

        public HotelBooking GetUser(int bookid)
        {
            string query = $"execute spGetParticularHotel {bookid}";

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
                            hotel = new HotelBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }

            return hotel;
        }


        [HttpPost("{id}")]

        public void Post(int id)
        {
            string query = $"execute spUpdateHotelStatus {id}";

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
