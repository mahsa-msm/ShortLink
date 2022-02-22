namespace ShortLink.Domain.Links
{
    public class Link : BaseEntity<int>
    {
        public string MainLink { get; private set; }
        public string ShortLink { get; private set; }
        public long VisitCount { get; private set; }

        private Link()
        {

        }

        public Link(string mainLink, string shortLink)
        {
            MainLink = mainLink;
            ShortLink = shortLink;
            VisitCount = 0;
        }
    }
}
