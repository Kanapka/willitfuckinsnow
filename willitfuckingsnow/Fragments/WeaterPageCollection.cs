using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace willitfuckingsnow.Fragments
{
    public interface IAppPageCollection
    {
        AppPage[] Pages { get; set; }
    }

    public class WeatherPageCollection : IAppPageCollection
    {
        private List<AppPage> pages = new List<AppPage>();
        public AppPage[] Pages { get => pages.ToArray(); set => pages.AddRange(value); }

        public WeatherPageCollection()
        {
            pages = new List<AppPage>{
                new Current(),
                new Forecast(),
                new Settings()
            };
        }
    }
}