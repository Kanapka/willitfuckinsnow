using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using willitfuckingsnow.Data.Weather;
using TinyIoC;
using willitfuckingsnow.Fragments;


namespace willitfuckingsnow
{
    [Application(Label = "@string/app_name")]
    class App : Application
    {
        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {
        }

        public override void OnCreate()
        {
            var container = TinyIoCContainer.Current;
            container.Register<IWeatherRepository>(new WeatherRepository());
            container.Register<IAppPageCollection, WeatherPageCollection>();
            base.OnCreate();
        }
    }
}