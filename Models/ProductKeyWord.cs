using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ProjectDotNet.Models
{
    public class ProductKeyWord
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int KeywordId { get; set; }

        public virtual KeyWord Keyword { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
