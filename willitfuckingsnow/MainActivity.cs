using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Widget;
using willitfuckingsnow.Adapters;
using willitfuckingsnow.Fragments;
using Android.Support.V4.App;
using TinyIoC;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Data;
using System.Threading.Tasks;
using System.Threading;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Content;
using willitfuckingsnow.Services;
using System;
using System.Linq;

namespace willitfuckingsnow
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        Fragment[] Pages { get; set; }
        ViewPager ViewPager { get; set; }
        BottomNavigationView Navigation { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Pages = TinyIoCContainer.Current.Resolve<IAppPageCollection>()?.Pages ?? throw new System.Exception("IOC NOT WORKING");

            SetContentView(Resource.Layout.activity_main);
            ViewPager = FindViewById<ViewPager>(Resource.Id.vievpager);
            ViewPager.Adapter = new ViewPagerAdapter(SupportFragmentManager, Pages);
            Navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            Navigation.NavigationItemSelected += OnNavigationItemSelected;

            UpdateCurrent();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void OnNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs args)
        {

            UpdateCurrent();
            UpdateForecast();
            ViewPager.SetCurrentItem(args.Item.Order, true);
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
        }
        private void UpdateCurrent()
        {
            var intent = new Intent(Android.App.Application.Context, typeof(WeatherService));
            var dates = new string[]
            {
                DateTime.Now.ToString()
            };

            intent.PutStringArrayListExtra(
                WeatherServiceKeys.Dates,
                dates.ToList());
            intent.PutExtra(
                WeatherServiceKeys.ResultReciever,
                new SingleDayResultReciever());
            StartService(intent);
        }

        private void UpdateForecast()
        {
            var intent = new Intent(Android.App.Application.Context, typeof(WeatherService));
            var dates = new DateTime[]
            {
                DateTime.Now,
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2),
                DateTime.Now.AddDays(3),
                DateTime.Now.AddDays(4)
            }
            .Select(d => d.ToString());

            intent.PutStringArrayListExtra(
                WeatherServiceKeys.Dates,
                dates.ToList());
            intent.PutExtra(
                WeatherServiceKeys.ResultReciever,
                new MultipleDaysResultReciever());
            StartService(intent);
        }
    }
    public class SingleDayResultReciever : ResultReceiver
    {
        public SingleDayResultReciever() : base(new Handler())
        {
            ;
        }

        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            var results = resultData.GetParcelableArray(WeatherServiceKeys.Forecasts).Cast<WeatherState>();
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
            var payload = new CurrentWeather();
            payload.weather = results.First();
            store.Commit(Actions.UpdateCurrent, payload);
            base.OnReceiveResult(resultCode, resultData);
        }
    }

    public class MultipleDaysResultReciever : ResultReceiver
    {
        public MultipleDaysResultReciever() : base(new Handler())
        {
            ;
        }
        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            var results = resultData.GetParcelableArray(WeatherServiceKeys.Forecasts).Cast<WeatherState>();
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
            var payload = new WeatherCollection();
            payload.states = results;
            store.Commit(Actions.UpdateForecast, payload);
            base.OnReceiveResult(resultCode, resultData);
        }
    }
}

