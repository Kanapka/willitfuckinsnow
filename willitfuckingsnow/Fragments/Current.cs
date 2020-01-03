using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Services;

namespace willitfuckingsnow.Fragments
{
    public class Current : AppPage
    {
        public string Location { get; set; } = "";

        public Current(IReduxStore<IApplicationState> store) : base(store)
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_current, container, false);
            view.FindViewById(Resource.Id.button_refreshCurrent).Click += OnRefreshButtonPressed;
            view.FindViewById(Resource.Id.button_scheduleJob).Click += OnScheduleButtonPressed;
            store.Commit(Actions.InitializeUpdateCurrent);
            return view;
        }

        public void OnRefreshButtonPressed(object sender, EventArgs args)
        {
            store.Commit(Actions.InitializeUpdateCurrent);
        }

        public void OnScheduleButtonPressed(object sender, EventArgs args)
        {
            UserBotheringService.SetNotification(Context, "Willowy crap");
            this.Context.RegisterJob<SnowForecastingService>();
        }

        public override void OnNext(IApplicationState state)
        {
            if (this.View is View view)
            {
                view.FindViewById<TextView>(Resource.Id.textView_location).Text = state.Today.Location;
                view.FindViewById<TextView>(Resource.Id.textView_status).Text = state.Today.Status;
                view.FindViewById<TextView>(Resource.Id.textView_date).Text = state.Today.Date.ToString("MMMM dd, yyyy");
                view.FindViewById<TextView>(Resource.Id.textView_additional).Text = state.Today.AdditionalStatus;
                view.FindViewById<TextView>(Resource.Id.textView_temperature).Text = $"{state.Today.Temperature} °C";
                view.FindViewById<Button>(Resource.Id.button_refreshCurrent).Text = state.Busy.Today
                    ? Context.Resources.GetString(Resource.String.button_loading)
                    : Context.Resources.GetString(Resource.String.button_refresh);
            }
        }
    }
}