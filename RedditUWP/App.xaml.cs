using Autofac;
using AutoMapper;
using RedditUWP.API;
using RedditUWP.API.Interfaces;
using RedditUWP.API.Models;
using RedditUWP.BusinessComponents;
using RedditUWP.BusinessComponents.Interfaces;
using RedditUWP.DataAccess;
using RedditUWP.DataAccess.Interfaces;
using RedditUWP.Entities;
using RedditUWP.ViewModels;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace RedditUWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Container = ConfigureServices();

            this.Suspending += OnSuspending;
        }

        public static IContainer Container { get; set; }

        private IContainer ConfigureServices()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<MainViewModel>()
                .SingleInstance();

            containerBuilder.RegisterType<RedditPostLogic>().As<IRedditPostLogic>();
            containerBuilder.RegisterType<APIManagement>().As<IAPIManagement>();
            containerBuilder.RegisterType<SQLiteRepository>().As<IRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<RedditPost, RedditPostItemViewModel>();
                cfg.CreateMap<Child, RedditPost>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Data.Author))
                .ForMember(
                    dest => dest.CreatedUTC,
                    opt => opt.MapFrom(src =>
                    DateTimeOffset.FromUnixTimeSeconds(src.Data.CreatedUtc).UtcDateTime
                        ))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Data.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Data.Title))
                .ForMember(dest => dest.NumComments, opt => opt.MapFrom(src => src.Data.NumComments))
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(src => src.Data.Thumbnail));
            });
            containerBuilder.Register(
                ctx =>
                {
                    var scope = ctx.Resolve<ILifetimeScope>();
                    return new Mapper(
                        mapperConfiguration,
                        scope.Resolve);
                })
                .As<IMapper>()
                .InstancePerLifetimeScope();

            var container = containerBuilder.Build();

            return container;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
