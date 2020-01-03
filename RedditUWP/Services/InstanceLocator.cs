using RedditUWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace RedditUWP.Services
{
    class InstanceLocator
    {
        #region Properties
        public MainViewModel MainViewModel { get; } = (App.Current as App).Container.GetService<MainViewModel>();

        #endregion
    }
}
