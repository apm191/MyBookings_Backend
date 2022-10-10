using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<FlightBooking> flights = new List<FlightBooking>();
        public FlightBooking flight;

        public FlightBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IEnumerable<FlightBooking> Get(int uid)
        {
            string query = $"execute spGetFlights {uid}";

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
                            flights.Add(new FlightBooking(myReader.GetInt32(0),myReader.GetInt32(1),myReader.GetString(2),myReader.GetString(3),myReader.GetString(4),myReader.GetString(5),myReader.GetString(6),myReader.GetString(7),myReader.GetString(8),myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetInt32(12)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }

            return flights;
        }


        [HttpGet("{id}")]

        public FlightBooking GetFlight(int id)
        {
            string query = $"execute spGetParticularFlight {id}";

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
                            flight = new FlightBooking(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7), myReader.GetString(8), myReader.GetString(9), myReader.GetString(10), myReader.GetString(11), myReader.GetInt32(12));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }

            return flight;
        }



        [HttpPost("{id}")]

        public void Post(int id)
        {
            string query = $"execute spUpdateFlightStatus {id}";

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

        //[HttpPut]

        //public void Put(FlightBooking fly_)
        //{
            
        //    SendMail(fly_);
        //}

        //public static void SendMail(FlightBooking fly)
        //{
        //    MailMessage mailmessage = new MailMessage("apurv.mundhra@gmail.com","19ucs247@lnmiit.ac.in");
        //    mailmessage.Subject = $"Booking Confirmed {fly.BookingRefNo}";
        //    mailmessage.Body = $"Your booking is Confirmed with {fly.AirlineName} and your Flight No. is {fly.FlightNo}";

        //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = new System.Net.NetworkCredential()
        //    {
        //        UserName = "apurv.mundhra@gmail.com",
        //        Password = "aM@01092001"
        //    };
        //    smtpClient.EnableSsl = true;
        //    smtpClient.Send(mailmessage);
        //}
    }
}
