using System;
using System.Collections.Generic;
using System.Text;
using RedditUWP.API.Interfaces;
using RedditUWP.BusinessComponents.Interfaces;
using RedditUWP.DataAccess.Interfaces;
using RedditUWP.Entities;

namespace RedditUWP.BusinessComponents
{
    public class RedditPostLogic : IRedditPostLogic
    {
        private IAPIManagement iAPIManagment;
        private IRepository iRepository;

        public RedditPostLogic(IAPIManagement iAPIManagment, IRepository iRepository)
        {
            this.iAPIManagment = iAPIManagment;
            this.iRepository = iRepository;
        }
        public bool DismissAllPosts()
        {
            try
            {
                this.iRepository.DeleteAllRedditPost();
                this.iRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DismissPost(RedditPost redditPost)
        {
            try
            {
                this.iRepository.DeleteRedditPost(redditPost.Id);
                this.iRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public List<RedditPost> GetRedditPost()
        {
            List<RedditPost> redditPosts = null;
            try
            {
                var oldContentLeght = this.iAPIManagment.ContentLenght;
                redditPosts = this.iAPIManagment.GetRedditPost();

                if (this.iAPIManagment.ContentLenght == oldContentLeght
                    && !this.iRepository.IsEmpty)
                    redditPosts = this.iRepository.GetRedditPost();

                if (this.iRepository.IsEmpty)
                {
                    this.iRepository.InsertRedditPosts(redditPosts);
                    this.iRepository.Save();
                }
            }
            catch (Exception)
            {
                redditPosts = this.iRepository.GetRedditPost();
            }

            return redditPosts;
        }

        public bool ReadPost(RedditPost redditPost)
        {
            try
            {
                this.iRepository.UpdateRedditPost(redditPost);
                this.iRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
