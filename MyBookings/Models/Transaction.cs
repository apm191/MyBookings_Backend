namespace MyBookings.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int BookingRefNo { get; set; }
        public int Amount { get; set; }

        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string Comment { get; set; }

        public Transaction(int transactionID, int userID, int bookingRefNo, int amount, string transactionStatus, string transactionType, string transactionDate, string comment)
        {
            TransactionID = transactionID;
            UserID = userID;
            BookingRefNo = bookingRefNo;
            Amount = amount;
            TransactionStatus = transactionStatus;
            TransactionType = transactionType;
            TransactionDate = transactionDate;
            Comment = comment;
        }
    }
}
