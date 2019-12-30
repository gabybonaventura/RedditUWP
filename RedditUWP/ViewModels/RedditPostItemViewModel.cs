using Autofac;
using RedditUWP.Entities;
using RedditUWP.ViewModels.Base;
using System.Windows.Input;

namespace RedditUWP.ViewModels
{
    class RedditPostItemViewModel : RedditPost
    {
        #region Atributtes
        private bool itWasRemoved;
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
        #endregion
    }
}
