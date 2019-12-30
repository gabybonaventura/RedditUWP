using System;
using System.Collections.Generic;
using System.Text;
using RedditUWP.Entities;

namespace RedditUWP.API.Interfaces
{
    public interface IAPIManagement
    {
        int ContentLenght { get; set; }
        List<RedditPost> GetRedditPost();
    }
}
