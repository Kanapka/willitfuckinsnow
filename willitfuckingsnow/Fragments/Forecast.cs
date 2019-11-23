using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using willitfuckingsnow.Data.State;
using Fragment = Android.Support.V4.App.Fragment;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data;

namespace willitfuckingsnow.Fragments
{
    public class Forecast : AppPage
    {
        public Forecast(IReduxStore<IApplicationState> store) : base(store)
        {
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_forecast, container, false);
            return view;
        }

        public override void OnNext(IApplicationState state)
        {
        }
    }
}