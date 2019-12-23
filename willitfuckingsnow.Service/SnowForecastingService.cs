using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace willitfuckingsnow.Services
{
    [BroadcastReceiver]
    public class SnowForecastingService : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            NotificationService.SetNotification(context);
            ;
        }
    }
}