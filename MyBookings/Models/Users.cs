namespace MyBookings.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserEmailID { get; set; }
        public long? UserPhoneNo { get; set; }
        public string? Password { get; set; }

        public string? ImageName { get; set; }
        public string? Birthday { get; set; }

        public string? Gender { get; set; }
        public string? MartialStatus { get; set; }

        public Users(int userID, string? userName, string? userEmailID, long? userPhoneNo, string? password, string? imageName, string? birthday, string? gender, string? martialStatus)
        {
            UserID = userID;
            UserName = userName;
            UserEmailID = userEmailID;
            UserPhoneNo = userPhoneNo;
            Password = password;
            ImageName = imageName;
            Birthday = birthday;
            Gender = gender;
            MartialStatus = martialStatus;
        }
    }
}
    