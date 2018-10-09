using BusSpeaker.Models;
using BusSpeaker.PageModels;
using BusSpeaker.Services;
using BusSpeaker.Services.Intefaces;
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
            FreshIOC.Container.Register<IRouteStore, SQLiteRouteStore>();
            FreshIOC.Container.Register<IGeolocatorService, GeolocatorService>();

            var tabbedNavigation = new FreshTabbedNavigationContainer(Guid.NewGuid().ToString());

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
