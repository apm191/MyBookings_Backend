namespace MyBookings.Models
{
    public class Hotels
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }

        public Hotels(int hotelID, string hotelName, string hotelAddress)
        {
            HotelID = hotelID;
            HotelName = hotelName;
            HotelAddress = hotelAddress;
        }
    }
}
