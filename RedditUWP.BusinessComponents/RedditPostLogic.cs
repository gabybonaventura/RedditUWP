using System;
using System.Collections.Generic;
using System.Text;
using RedditUWP.API.Interfaces;
using RedditUWP.BusinessComponents.Interfaces;
using RedditUWP.Entities;

namespace RedditUWP.BusinessComponents
{
    public class RedditPostLogic : IRedditPostLogic
    {
        private IAPIManagement iAPIManagment;

        public RedditPostLogic(IAPIManagement iAPIManagment)
        {
            this.iAPIManagment = iAPIManagment;
        }
        public bool DismissAllPosts()
        {
            return true;
        }

        public bool DismissPost(RedditPost redditPost)
        {
            return true;
        }

        public List<RedditPost> GetRedditPost()
        {
            return this.iAPIManagment.GetRedditPost();
        }

        public bool ReadPost(RedditPost redditPost)
        {
            return true;
        }
    }
}
