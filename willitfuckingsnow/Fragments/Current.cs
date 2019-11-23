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
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;

namespace willitfuckingsnow.Fragments
{
    public class Current : AppPage
    {
        public string Location { get; set; } = "";

        public Current(IReduxStore<IApplicationState> store) : base()
        {
            store.Subscribe(this);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var view = inflater.Inflate(Resource.Layout.fragment_current, container, false);
            var location = view.FindViewById<TextView>(Resource.Id.textView_location);
            return view;
        }

        public override void OnNext(IApplicationState state)
        {
            if (this.View is View view)
            {
                view.FindViewById<TextView>(Resource.Id.textView_location).Text = state.Location;
                view.FindViewById<TextView>(Resource.Id.textView_status).Text = state.Status;
                view.FindViewById<TextView>(Resource.Id.textView_date).Text = state.Date.ToString("MMMM dd, yyyy");
                view.FindViewById<TextView>(Resource.Id.textView_additional).Text = state.AdditionalStatus;
                view.FindViewById<TextView>(Resource.Id.textView_temperature).Text = $"{state.Temperature} °C";
            }
        }
    }
}