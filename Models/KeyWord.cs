namespace ProjectDotNet.Models
{
    public class KeyWord
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<ProductKeyWord> Productkeywords { get; set; } = new List<ProductKeyWord>();
    }
}
