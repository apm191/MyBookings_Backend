namespace MyBookings.Models
{
    public class CarBooking : Car
    {
        public int UserID { get; set; }
        public int BookingRefNo { get; set; }

        public string Boarding { get; set; }
        public string Destination { get; set; }
        public int Traveller { get; set; }
        public string Booking_Date { get; set; }
        public string PickupTime { get; set; }
        public string PickupLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string TripStatus { get; set; }
        public int CarRent { get; set; }

        public CarBooking(int userID, int carID,int bookingRefNo, string boarding, string destination, int traveller, string booking_Date, string pickupTime, string pickupLocation, string dropOffLocation, string tripStatus, int carRent,string carOperatorName,string carType) : base (carID,carOperatorName,carType)
        {
            UserID = userID;
            BookingRefNo = bookingRefNo;
            Boarding = boarding;
            Destination = destination;
            Traveller = traveller;
            Booking_Date = booking_Date;
            PickupTime = pickupTime;
            PickupLocation = pickupLocation;
            DropOffLocation = dropOffLocation;
            TripStatus = tripStatus;
            CarRent = carRent;
        }
    }
}
