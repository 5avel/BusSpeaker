using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace BusSpeaker.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {

            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_sqlite3());

            SQLitePCL.Batteries.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyAW-NW1G_KPtl1exwZj4P_JzqPibBDJN4U");


            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");





        }
    }
}
