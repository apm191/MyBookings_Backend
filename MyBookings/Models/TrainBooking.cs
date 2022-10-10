namespace MyBookings.Models
{
    public class TrainBooking : Train
    {
        public int UserID { get; set; }
        public int BookingRefNo { get; set; }

        public string Boarding { get; set; }
        public string Destination { get; set; }

        public string Journey_Date { get; set; }
        public string Booking_Date { get; set; }
        public int Traveller { get; set; }
        public string BoardingTime { get; set; }
        public string ArrivalTime { get; set; }
        public string PickupLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string TripStatus { get; set; }

        public string TrainTicketClass { get; set; }
        public int TrainTicketPrice { get; set; }
        public string TrainTicketQuota { get; set; }
        public string SeatNo { get; set; }
        public string SeatType { get; set; }

        public TrainBooking(int userID,int trainID, int bookingRefNo, string boarding, string destination, string journey_Date, string booking_Date, int traveller, string boardingTime, string arrivalTime, string pickupLocation, string dropOffLocation, string tripStatus, string trainTicketClass, int trainTicketPrice, string trainTicketQuota, string seatNo, string seatType,string trainName) : base(trainID,trainName)
        {
            UserID = userID;
            BookingRefNo = bookingRefNo;
            Boarding = boarding;
            Destination = destination;
            Journey_Date = journey_Date;
            Booking_Date = booking_Date;
            Traveller = traveller;
            BoardingTime = boardingTime;
            ArrivalTime = arrivalTime;
            PickupLocation = pickupLocation;
            DropOffLocation = dropOffLocation;
            TripStatus = tripStatus;
            TrainTicketClass = trainTicketClass;
            TrainTicketPrice = trainTicketPrice;
            TrainTicketQuota = trainTicketQuota;
            SeatNo = seatNo;
            SeatType = seatType;
        }
    }
}
