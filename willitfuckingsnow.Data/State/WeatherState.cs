﻿using System;
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
    public class WeatherState
    {
        public string Location { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } = "";
        public string AdditionalStatus { get; set; } = "";
        public float Temperature { get; set; } = 0;

        public override string ToString() => $"{Date.ToString("dd")}, {Temperature} °C, {Status}";



    }
}