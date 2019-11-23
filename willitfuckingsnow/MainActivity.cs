﻿using Android.App;
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

namespace willitfuckingsnow
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        AppPage[] Pages { get; set; }
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
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void OnNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs args)
        {
            ViewPager.SetCurrentItem(args.Item.Order, true);
        }
    }
}

