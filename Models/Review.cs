namespace ProjectDotNet.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
       
        public string commemt { get; set; }
        public DateTime commemtDate { get; set; }

    }
}
