using AutoMapper;
using RedditUWP.BusinessComponents.Interfaces;
using RedditUWP.Entities;
using RedditUWP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RedditUWP.ViewModels
{
    class MainViewModel : BindableBase
    {
        #region Attributes
        private string id, title, author, thumbnail;
        private ObservableCollection<RedditPostItemViewModel> posts;
        private IRedditPostLogic redditPostLogic;
        private IMapper mapper;
        #endregion
        #region Constructors
        public MainViewModel(IRedditPostLogic redditPostLogic, IMapper mapper)
        {
            this.redditPostLogic = redditPostLogic;
            this.mapper = mapper;

            this.Id = "10";
            this.Thumbnail = "https://a.thumbs.redditmedia.com/NPbKE2FAaO97ci2jIVCy5L04nEWd60_nS52LdmMQMV4.jpg";
            this.Author = "author";
            this.Title = "title";
            
            var postsReddit = this.redditPostLogic.GetRedditPost();

            this.Posts = new ObservableCollection<RedditPostItemViewModel>
                            (this.mapper.Map<List<RedditPostItemViewModel>>(postsReddit));
        }
        #endregion
        #region Properties
        public ObservableCollection<RedditPostItemViewModel> Posts
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
        #region Commands
        public ICommand DismissAllPostCommand
        {
            get { return new DelegateCommand(DismissAllPost, null); }
        }
        #endregion
        #region Methods
        public void PostSelected(RedditPostItemViewModel redditPostItemViewModel)
        {
            this.Id = redditPostItemViewModel.Id;
            this.Title = redditPostItemViewModel.Title;
            this.Thumbnail = redditPostItemViewModel.Thumbnail;
            redditPostItemViewModel.ItWasRead = true;
        }
        public void DismissPost(RedditPostItemViewModel redditPostItemViewModel)
        {
            this.Posts.Remove(redditPostItemViewModel);
        }
        private void DismissAllPost()
        {
            this.Posts = new ObservableCollection<RedditPostItemViewModel>();
        }
        #endregion
    }
}
