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

namespace willitfuckingsnow
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        TextView textMessage { get; set; }
        AppPage[] Pages { get; set; }
        ViewPager viewPager { get; set; }
        BottomNavigationView navigation { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Pages = new AppPage[]
            {
                new Current(),
                new Forecast(),
                new Settings()
            };

            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            viewPager = FindViewById<ViewPager>(Resource.Id.vievpager);
            viewPager.Adapter = new ViewPagerAdapter(SupportFragmentManager, Pages);
            navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.NavigationItemSelected += OnNavigationItemSelected;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void OnNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs args)
        {
            viewPager.SetCurrentItem(args.Item.Order, true);
        }
    }
}

