using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RedditUWP.DataAccess.Interfaces;
using RedditUWP.Entities;


namespace RedditUWP.DataAccess
{
    public class SQLiteRepository : IRepository
    {
        private SQLiteConnection connection;
        public SQLiteRepository()
        {
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "RedditPost.sqlite");
            this.connection = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            this.connection.CreateTable<RedditPost>();

        }

        public bool IsEmpty
        {
            get { return this.connection.Table<RedditPost>().Count() == 0; }
        }

        public void DeleteAllRedditPost()
        {
            this.connection.DeleteAll<RedditPost>();
        }

        public void DeleteRedditPost(string redditPostId)
        {
            this.connection.Delete<RedditPost>(redditPostId);
        }

        public List<RedditPost> GetRedditPost()
        {
            return this.connection.Table<RedditPost>().ToList();
        }

        public RedditPost GetRedditPostByID(string redditPostId)
        {
            return this.connection.Table<RedditPost>().Where(r => r.Id == redditPostId).FirstOrDefault();
        }

        public void InsertRedditPost(RedditPost redditPost)
        {
            this.connection.Insert(redditPost);
        }

        public void InsertRedditPosts(List<RedditPost> redditPosts)
        {
            this.connection.InsertAll(redditPosts);
        }

        public void Save()
        {
            //not required in this implementation
        }
         
        public void UpdateRedditPost(RedditPost redditPost)
        {
            this.connection.Update(redditPost);
        }
    }
}
