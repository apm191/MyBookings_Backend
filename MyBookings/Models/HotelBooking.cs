namespace MyBookings.Models
{
    public class HotelBooking : Hotels
    {
        public int UserID { get; set; }
        public int BookingRefNo { get; set; }
        public string CheckIn_Date { get; set; }
        public string CheckOut_Date { get; set; }
        public string HotelRoomType { get; set; }
        public string TripStatus { get; set; }

        public HotelBooking(int userID,int hotelID, int bookingRefNo, string checkIn_Date, string checkOut_Date, string hotelRoomType, string tripStatus,string hotelName,string hotelAddress) : base(hotelID, hotelName, hotelAddress)
        {
            UserID = userID;
            BookingRefNo = bookingRefNo;
            CheckIn_Date = checkIn_Date;
            CheckOut_Date = checkOut_Date;
            HotelRoomType = hotelRoomType;
            TripStatus = tripStatus;
        }
    }
}
