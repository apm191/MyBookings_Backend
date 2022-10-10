using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBookingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<CarBooking> cars = new List<CarBooking>();
        public CarBooking car;

        public CarBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public IEnumerable<CarBooking> Get(int uid)
        {
            string query = $"exec spGetCar {uid}";
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
                            cars.Add(new CarBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetInt32(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10),myReader.GetInt32(11), myReader.GetString(12), myReader.GetString(13)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return cars;
        }


        [HttpGet("{bookid}")]

        public CarBooking GetUser(int bookid)
        {
            string query = $"exec spGetParticularCar {bookid}";
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
                            car = new CarBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetInt32(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetInt32(11), myReader.GetString(12), myReader.GetString(13));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return car;
        }


        [HttpPost("{id}")]

        public void Post(int id)
        {
            string query = $"execute spUpdateCarStatus {id}";

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
