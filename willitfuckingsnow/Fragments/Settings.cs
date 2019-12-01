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
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;
using Fragment = Android.Support.V4.App.Fragment;

namespace willitfuckingsnow.Fragments
{
    public class Settings : AppPage
    {
        public Settings(IReduxStore<IApplicationState> store) : base(store)
        { }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_settings, container, false);

        }

        public override void OnNext(IApplicationState state)
        {
        }
    }
}