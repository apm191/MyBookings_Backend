namespace MyBookings.Models
{
    public class Bus
    {
        public int BusID { get; set; }
        public string BusOperatorName { get; set; }
        public string BusType { get; set; }
        public int BusTicketPrice { get; set; }

        public Bus(int busID, string busOperatorName, string busType, int busTicketPrice)
        {
            BusID = busID;
            BusOperatorName = busOperatorName;
            BusType = busType;
            BusTicketPrice = busTicketPrice;
        }
    }
}
