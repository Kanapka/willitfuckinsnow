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
using ListFragment = Android.Support.V4.App.ListFragment;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data;
using willitfuckingsnow.Adapters;

namespace willitfuckingsnow.Fragments
{
    public class Forecast : ListFragment, IObserver<IApplicationState>
    {
        IReduxStore<IApplicationState> store;
        WeatherState[] weatherStates = new WeatherState[] { };

        public Forecast(IReduxStore<IApplicationState> _store) : base()
        {
            store = _store;
            store.Subscribe(this);
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ListAdapter = new ForecastAdapter(Activity, store.State.Future.ToList());
            var view = inflater.Inflate(Resource.Layout.fragment_forecast, container, false);
            //view.FindViewById<Button>(Resource.Id.button_refreshForecast).Click += OnRefreshButtonPressed;
            this.store.Commit(Actions.InitializeUpdateForecast);
            return view;
        }

        public void OnRefreshButtonPressed(object sender, EventArgs args)
        {
            store.Commit(Actions.InitializeUpdateForecast);
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(IApplicationState state)
        {
            if (ListAdapter is ForecastAdapter adapter)
            {
                adapter.Update(store.State.Future.ToList());
                Activity.RunOnUiThread(() => adapter.NotifyDataSetChanged());
            }

        }

        public void OnCompleted()
        {
        }
    }
}