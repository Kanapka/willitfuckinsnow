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

namespace willitfuckingsnow.Data.State
{
    public class WeatherState : Java.Lang.Object, IParcelable
    {
        public string Location { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } = "";
        public string AdditionalStatus { get; set; } = "";
        public float Temperature { get; set; } = 0;
        public float SnowCover { get; set; } = 0;
        public string SnowStatus
        {
            get => SnowCover > 0
                ? "Fucking snows"
                : "Will be goddamn clear";
        }

        public WeatherState() { }
        public WeatherState(Parcel parcel)
        {
            Location = parcel.ReadString();
            Date = DateTime.Parse(parcel.ReadString());
            Status = parcel.ReadString();
            AdditionalStatus = parcel.ReadString();
            Temperature = parcel.ReadFloat();
            SnowCover = parcel.ReadFloat();
        }
        public int DescribeContents() => 0;

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(Location);
            dest.WriteString(Date.ToString());
            dest.WriteString(Status);
            dest.WriteString(AdditionalStatus);
            dest.WriteFloat(Temperature);
            dest.WriteFloat(SnowCover);
        }

        public override string ToString() => $"{Date.ToString("dd")}, {Temperature} °C, {Status}";
    }
}