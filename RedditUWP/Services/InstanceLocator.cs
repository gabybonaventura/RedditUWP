using RedditUWP.ViewModels;
using Autofac;

namespace RedditUWP.Services
{
    class InstanceLocator
    {
        #region Properties
        public MainViewModel MainViewModel
        {
            get { return App.Container.Resolve<MainViewModel>(); }
        }
        #endregion
    }
}
