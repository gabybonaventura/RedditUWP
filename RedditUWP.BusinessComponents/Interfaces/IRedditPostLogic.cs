using System.Collections.Generic;
using RedditUWP.Entities;

namespace RedditUWP.BusinessComponents.Interfaces
{
    public interface IRedditPostLogic
    {
        List<RedditPost> GetRedditPost();
        bool ReadPost(RedditPost redditPost);
        bool DismissPost(RedditPost redditPost);
        bool DismissAllPosts();

    }
}
