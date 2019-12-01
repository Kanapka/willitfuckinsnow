using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using willitfuckingsnow.Data;
using willitfuckingsnow.Data.State;

namespace willitfuckingsnow.Adapters
{
    class ForecastAdapter : BaseAdapter<WeatherState>
    {

        Context context;
        List<WeatherState> States = new List<WeatherState> { };

        public ForecastAdapter(Context context, List<WeatherState> states)
        {
            this.context = context;
            this.States = states;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            ForecastAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as ForecastAdapterViewHolder;

            if (holder == null)
            {
                holder = new ForecastAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.fragment_single_day, parent, false);
                view.Tag = holder;
            }

            var weatherStatus = this[position];
            view.FindViewById<TextView>(Resource.Id.textView_single_date_day).Text = weatherStatus.Date.ToString("dddd");
            view.FindViewById<TextView>(Resource.Id.textView_single_date_status).Text = weatherStatus.Status;
            view.FindViewById<TextView>(Resource.Id.textView_single_date_temperature).Text = weatherStatus.Temperature.ToString() + " °C";
            return view;
        }

        public override int Count => States.Count;

        public override WeatherState this[int position]
            => position > States.Count
            ? new WeatherState()
            : States[position];

        public void Update(IEnumerable<WeatherState> newState)
        {
            States.Clear();
            States.AddRange(newState);
        }
    }

    class ForecastAdapterViewHolder : Java.Lang.Object
    {
    }
}