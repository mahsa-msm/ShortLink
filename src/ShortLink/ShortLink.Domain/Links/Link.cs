namespace ShortLink.Domain.Links
{
    public class Link : BaseEntity<int>
    {
        public string MainLink { get; set; }
        public string ShortLink { get; set; }
        public long VisitCount { get; set; }
    }
}
