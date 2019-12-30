using System.Collections.Generic;
using RedditUWP.Entities;

namespace RedditUWP.DataAccess.Interfaces
{
    public interface IRepository
    {
        bool IsEmpty { get; }
        List<RedditPost> GetRedditPost();
        RedditPost GetRedditPostByID(string redditPostId);
        void InsertRedditPosts(List<RedditPost> redditPosts);
        void InsertRedditPost(RedditPost redditPost);
        void DeleteRedditPost(string redditPostId);
        void DeleteAllRedditPost();
        void UpdateRedditPost(RedditPost redditPost);
        void Save();
    }
}
