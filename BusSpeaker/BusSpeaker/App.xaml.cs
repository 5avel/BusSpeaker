using BusSpeaker.PageModels;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BusSpeaker
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var tabbedNavigation = new FreshTabbedNavigationContainer(Guid.NewGuid().ToString());

            tabbedNavigation.SetValue(NavigationPage.HasNavigationBarProperty, false);
            tabbedNavigation.AddTab<RoutePageModel>("Route", null);
            tabbedNavigation.AddTab<SettingsPageModel>("Settings", null);
            MainPage = tabbedNavigation;
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
