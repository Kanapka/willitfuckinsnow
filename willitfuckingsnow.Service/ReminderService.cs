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
    public class ReminderService : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            ;
        }
    }

    public static class ReminderScheduler
    {
        public static void RegisterJob<T>(this Context context) where T : BroadcastReceiver
        {
            var javaClass = Java.Lang.Class.FromType(typeof(T));
            var alarmManager = context.GetSystemService(Context.AlarmService) as AlarmManager;
            var executor = new Intent(context, javaClass);
            var operation = PendingIntent.GetBroadcast(context, 0, executor, PendingIntentFlags.UpdateCurrent);

            alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, 60 * 1000, 60 * 1000, operation);
        }
    }
}