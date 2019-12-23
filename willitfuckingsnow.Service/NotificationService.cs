using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace willitfuckingsnow.Services
{
    public class NotificationService
    {
        static string channelId = "willitfuckingsnow notifications";
        static int notificationId = 2473;
        static bool UseChannel => Build.VERSION.SdkInt >= BuildVersionCodes.O;
        static NotificationChannel channel;

        public static void CreateNotificationChannel(Context context)
        {
            if (UseChannel)
            {
                var notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
                var channelName = context.GetString(Resource.String.notification_channel_name);
                var notificationChannel = new NotificationChannel(channelId, channelName, NotificationImportance.High);

                notificationManager.CreateNotificationChannel(notificationChannel);
            }
        }
        public static void SetNotification(Context context)
        {
            if (channel == null) { CreateNotificationChannel(context); }
            var notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            var builder = UseChannel
                    ? new NotificationCompat.Builder(context, channelId)
                    : new NotificationCompat.Builder(context);
            var notification = builder.SetContentTitle("Fuck yeah")
                .SetContentText("Notification goddamn text, bitches")
                .SetCategory(Notification.CategoryService)
                .SetSmallIcon(Resource.Drawable.abc_ic_arrow_drop_right_black_24dp)
                .Build();
            notificationManager.Notify(notificationId, notification);
        }
    }
}