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
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;
using Fragment = Android.Support.V4.App.Fragment;

namespace willitfuckingsnow.Fragments
{
    public interface IAppPageCollection
    {
        Fragment[] Pages { get; set; }
    }

    public class WeatherPageCollection : IAppPageCollection
    {
        private List<Fragment> pages = new List<Fragment>();
        public Fragment[] Pages { get => pages.ToArray(); set => pages.AddRange(value); }

        public WeatherPageCollection(IReduxStore<IApplicationState> store)
        {
            pages = new List<Fragment>{
                new Current(store),
                new Forecast(store),
                new Settings(store)
            };
        }
    }
}