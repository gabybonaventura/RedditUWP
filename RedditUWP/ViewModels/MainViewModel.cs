using RedditUWP.Models;
using RedditUWP.ViewModels.Base;
using System.Collections.ObjectModel;

namespace RedditUWP.ViewModels
{
    class MainViewModel : BindableBase
    {
        #region Attributes
        private string id, title, author, thumbnail;
        private ObservableCollection<RedditPost> posts;
        #endregion
        #region Constructors
        public MainViewModel()
        {
            this.Id = "10";
            this.Thumbnail = "https://a.thumbs.redditmedia.com/NPbKE2FAaO97ci2jIVCy5L04nEWd60_nS52LdmMQMV4.jpg";
            this.Author = "author";
            this.Title = "title";

            this.Posts = new ObservableCollection<RedditPost>();
            this.Posts.Add(
                new RedditPost()
                {
                    Title = "post1",
                    Author = "asd",
                    Thumbnail = "https://a.thumbs.redditmedia.com/NPbKE2FAaO97ci2jIVCy5L04nEWd60_nS52LdmMQMV4.jpg"
                });
            this.Posts.Add(
                new RedditPost()
                {
                    Title = "post2",
                    Author = "asfasdd",
                    Thumbnail = "https://a.thumbs.redditmedia.com/NPbKE2FAaO97ci2jIVCy5L04nEWd60_nS52LdmMQMV4.jpg"
                });
        }
        #endregion
        #region Properties
        public ObservableCollection<RedditPost> Posts
        {
            get
            {
                return posts;
            }
            set
            {
                this.SetProperty(ref this.posts, value);
            }
        }
        public string Id 
        {
            get
            {
                return id;
            }
            set
            {
                this.SetProperty(ref this.id, value);
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                this.SetProperty(ref this.title, value);
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                this.SetProperty(ref this.author, value);
            }
        }
        public string Thumbnail
        {
            get
            {
                return thumbnail;
            }
            set
            {
                this.SetProperty(ref this.thumbnail, value);
            }
        }
        #endregion
    }
}
