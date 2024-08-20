namespace ProjectDotNet.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int rating { get; set; }
        public string commemt { get; set; }
        public DateTime commemtDate { get; set; }

    }
}
