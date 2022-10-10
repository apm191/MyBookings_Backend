using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusBookingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<BusBooking> busses = new List<BusBooking>();
        public BusBooking bus;

        public BusBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public IEnumerable<BusBooking> Get(int uid)
        {
            string query = $"exec spGetBus {uid}";
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
                            busses.Add(new BusBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetInt32(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetString(12), myReader.GetString(13), myReader.GetString(14), myReader.GetInt32(15)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return busses;
        }


        [HttpGet("{id}")]

        public BusBooking GetBus(int id)
        {
            string query = $"exec spGetParticularBus {id}";
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
                            bus = new BusBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetString(3), myReader.GetString(4), myReader.GetInt32(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetString(12), myReader.GetString(13), myReader.GetString(14), myReader.GetInt32(15));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return bus;
        }

        [HttpPost("{id}")]

        public void Post(int id)
        {
            string query = $"execute spUpdateBusStatus {id}";

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
