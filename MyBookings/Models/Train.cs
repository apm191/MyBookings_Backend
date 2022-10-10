namespace MyBookings.Models
{
    public class Train
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }

        public Train(int trainID, string trainName)
        {
            TrainID = trainID;
            TrainName = trainName;
        }
    }
}
