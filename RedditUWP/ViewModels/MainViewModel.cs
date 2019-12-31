using AutoMapper;
using RedditUWP.BusinessComponents.Interfaces;
using RedditUWP.Entities;
using RedditUWP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;

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
        public ICommand RefreshCommand
        {
            get { return new DelegateCommand(Refresh, null); }
        }
        #endregion
        #region Methods
        public void PostSelected(RedditPostItemViewModel redditPostItemViewModel)
        {
            this.Id = redditPostItemViewModel.Id;
            this.Title = redditPostItemViewModel.Title;
            this.Thumbnail = redditPostItemViewModel.Thumbnail;
            if (this.redditPostLogic.ReadPost(redditPostItemViewModel.Base))
                redditPostItemViewModel.ItWasRead = true;
        }
        public async void DismissPost(RedditPostItemViewModel redditPostItemViewModel)
        {
            var redditPost = mapper.Map<RedditPost>(redditPostItemViewModel);
            var res = this.redditPostLogic.DismissPost(redditPost);
            if (res)
                this.Posts.Remove(redditPostItemViewModel);
            else
            {
                var messageDialog = new MessageDialog("The post could not be discarded, try again later.");
                await messageDialog.ShowAsync();
            }
        }
        private async void DismissAllPost()
        {
            var res = this.redditPostLogic.DismissAllPosts();
            if (res)
                this.Posts = new ObservableCollection<RedditPostItemViewModel>();
            else
            {
                var messageDialog = new MessageDialog("The posts could not be discarded, try again later.");
                await messageDialog.ShowAsync();
            }
        }
        private async void Refresh()
        {
            var postsReddit = this.redditPostLogic.GetRedditPost();
            if (postsReddit != null)
                this.Posts = new ObservableCollection<RedditPostItemViewModel>
                            (this.mapper.Map<List<RedditPostItemViewModel>>(postsReddit));
            else
            {
                var messageDialog = new MessageDialog("The posts could not be loaded, try again later.");
                await messageDialog.ShowAsync();
            }
        }
        #endregion
    }
}
