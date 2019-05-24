using BusSpeaker.DAL;
using BusSpeaker.DAL.Intefaces;
using BusSpeaker.PageModels;
using BusSpeaker.Services;
using BusSpeaker.Services.Intefaces;
using FreshMvvm;
using Microsoft.EntityFrameworkCore;
using Plugin.SimpleAudioPlayer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BusSpeaker
{
    public class App : Application
    {
        public App()
        {


            FreshIOC.Container.Register<DbContext, DBContext>();
            FreshIOC.Container.Register<IRoutRepository, RoutRepository>();
            FreshIOC.Container.Register<ISettingsRepository, SettingsRepository>();

            FreshIOC.Container.Register<IGeolocatorService, GeolocatorService>();
            FreshIOC.Container.Register<IStopPointsService, StopPointsService>();
            FreshIOC.Container.Register<IStopsSoundService, StopsSoundService>();

            FreshIOC.Container.Register(CrossSimpleAudioPlayer.Current);

            var tabbedNavigation = new FreshTabbedNavigationContainer(Guid.NewGuid().ToString());
            try
            {
                tabbedNavigation.AddTab<RoutePageModel>("Route", null); // ios exeption
                tabbedNavigation.AddTab<MapPageModel>("Map", null);
                tabbedNavigation.AddTab<SettingsPageModel>("Settings", null);
            }
            catch (Exception)
            {
                // ignored
            }


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