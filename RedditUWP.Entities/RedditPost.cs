using System;
using SQLite.Net.Attributes;

namespace RedditUWP.Entities
{
    public class RedditPost
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedUTC { get; set; }
        public string Thumbnail { get; set; }
        public int NumComments { get; set; }
        public bool ItWasRead { get; set; }
    }
}
