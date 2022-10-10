namespace MyBookings.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string CarOperatorName { get; set; }
        public string CarType { get; set; }

        public Car(int carID, string carOperatorName, string carType)
        {
            CarID = carID;
            CarOperatorName = carOperatorName;
            CarType = carType;
        }
    }
}
