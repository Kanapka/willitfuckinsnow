using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace willitfuckingsnow.Fragments
{
    public class Current : AppPage
    {
        public string Location { get; set; } = "";

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.fragment_current, container, false);
            var location = view.FindViewById<TextView>(Resource.Id.textView_location);
            location.Text = "FUCK";
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                location.Text = "lol wtf";
            });
            return view;

        }
    }
}