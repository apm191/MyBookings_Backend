using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookings.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public List<Transaction> transactions = new List<Transaction>();

        public TransactionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("{uid}")]

        public IEnumerable<Transaction> Get(int uid)
        {
            string query = $"exec spGetTransactions {uid}";
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
                            transactions.Add(new Transaction(myReader.GetInt32(0), myReader.GetInt32(1), myReader.GetInt32(2), myReader.GetInt32(3), myReader.GetString(4), myReader.GetString(5), myReader.GetString(6), myReader.GetString(7)));
                        }
                    }
                    myReader.Close();
                    myConnection.Close();
                }
            }
            return transactions;
        }

        [HttpPost]

        public void Post(Transaction trs)
        {
            string query = "execute spAddTransactions @UserID,@BookingRefNo,@Amount,@TransactionStatus,@TransactionType,@TransactionDate,@Comment";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");

            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@UserID", trs.UserID);
                    myCommand.Parameters.AddWithValue("@BookingRefNo", trs.BookingRefNo);
                    myCommand.Parameters.AddWithValue("@Amount", trs.Amount);
                    myCommand.Parameters.AddWithValue("@TransactionStatus", trs.TransactionStatus);
                    myCommand.Parameters.AddWithValue("@TransactionType", trs.TransactionType);
                    myCommand.Parameters.AddWithValue("@TransactionDate", trs.TransactionDate);
                    myCommand.Parameters.AddWithValue("@Comment", trs.Comment);
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
