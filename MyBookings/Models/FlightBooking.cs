namespace MyBookings.Models
{
    public class FlightBooking
    {
        public int UserID { get; set; }
        public int BookingRefNo { get; set; }   
        public string Boarding { get; set; }
        public string Destination { get; set; }
        public string JourneyDate { get; set; }
        public string BookingDate { get; set; }
        public string TripStatus { get; set; }

        public string FlightNo { get; set; }
        public string AirlineName { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Layover { get; set; }
        public int Baggagelimit { get; set; }

        public FlightBooking(int userID,int bookingRefNo, string boarding, string destination, string journeyDate, string bookingDate, string tripStatus, string flightNo, string airlineName, string departureTime, string arrivalTime, string layover, int baggagelimit)
        {
            UserID = userID;
            BookingRefNo = bookingRefNo;
            Boarding = boarding;
            Destination = destination;
            JourneyDate = journeyDate;
            BookingDate = bookingDate;
            TripStatus = tripStatus;
            FlightNo = flightNo;
            AirlineName = airlineName;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Layover = layover;
            Baggagelimit = baggagelimit;
        }
    }
}
