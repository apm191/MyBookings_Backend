namespace MyBookings.Models
{
    public class BusBooking : Bus
    {
        public int UserID { get; set; }
        public int BookingRefNo { get; set; }

        public string Boarding { get; set; }
        public string Destination { get; set; }
        public int SeatNo { get; set; }
        public string Booking_Date { get; set; }
        public string Travel_Date { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string BoardingPoint { get; set; }
        public string DroppingPoint { get; set; }
        public string TripStatus { get; set; }

        public BusBooking(int userID, int busID, int bookingRefNo, string boarding, string destination, int seatNo, string booking_Date, string travel_Date, string departureTime, string arrivalTime, string boardingPoint, string droppingPoint, string tripStatus, string busOperatorName, string busType, int busTicketPrice) : base( busID, busOperatorName, busType, busTicketPrice)
        {
            UserID = userID;
            BookingRefNo = bookingRefNo;
            Boarding = boarding;
            Destination = destination;
            SeatNo = seatNo;
            Booking_Date = booking_Date;
            Travel_Date = travel_Date;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            BoardingPoint = boardingPoint;
            DroppingPoint = droppingPoint;
            TripStatus = tripStatus;
        }
    }
}
