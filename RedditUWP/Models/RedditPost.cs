using System;

namespace RedditUWP.Models
{
    class RedditPost
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedUTC { get; set; }
        public string Thumbnail { get; set; }
        public int NumComments { get; set; }
        public bool ItWasRead { get; set; }
    }
}
