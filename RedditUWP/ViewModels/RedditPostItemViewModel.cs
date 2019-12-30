using Autofac;
using RedditUWP.Entities;
using RedditUWP.ViewModels.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RedditUWP.ViewModels
{
    class RedditPostItemViewModel : RedditPost, INotifyPropertyChanged
    {
        #region Atributtes
        private bool itWasRemoved;
        private bool itWasRead;
        #endregion
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ItWasRead
        {
            get
            {
                return !itWasRead;
            }
            set
            {
                this.SetProperty(ref this.itWasRead, value);
            }
        }
        public string NumCommentString
        {
            get { return $"{this.NumComments} Comments"; }
        }
        public string HoursAgo
        {
            get
            {
                return $"{Math.Round((DateTime.Now - this.CreatedUTC).TotalHours)} Hours ago";
            }
        }
        public RedditPost Base
        {
            get
            {
                return new RedditPost()
                {
                    Id = this.Id,
                    Title = this.Title,
                    Author = this.Author,
                    CreatedUTC = this.CreatedUTC,
                    ItWasRead = this.ItWasRead,
                    NumComments = this.NumComments,
                    Thumbnail = this.Thumbnail
                };
            }
        }
        #endregion
        #region Commands
        public ICommand ItemSelectedCommand
        {
            get { return new DelegateCommand(ItemSelected, null); }
        }
        public ICommand DismissCommand
        {
            get { return new DelegateCommand(Dismiss, null); }
        }

        #endregion
        #region Methods
        private void ItemSelected()
        {
            if (this.itWasRemoved)
                return;
            App.Container.Resolve<MainViewModel>().PostSelected(this);
        }
        private void Dismiss()
        {
            App.Container.Resolve<MainViewModel>().DismissPost(this);
            this.itWasRemoved = true;
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
