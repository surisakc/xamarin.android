using Android.App;
using Android.Content;
using Android.Util;
using System;

namespace Volume
{
    [BroadcastReceiver]
    [IntentFilter(
        new[] { Android.Content.Intent.ActionBootCompleted },
        Categories = new[] { Android.Content.Intent.CategoryDefault }
    )]
    public class ReceiveBoot : BroadcastReceiver
    {
        int numberOfVolumnDownPresses = 0;

        Guid guid;
        public ReceiveBoot()
        {
            guid = Guid.NewGuid();
        }


        public override void OnReceive(Context context, Intent intent)
        {
            if ((intent.Action != null) &&
                (intent.Action ==
                    Android.Content.Intent.ActionBootCompleted))
            {

                //Android.Content.Intent start = new Android.Content.Intent(context, typeof(PeriodicService));
                //start.AddFlags(ActivityFlags.NewTask);
                //start.AddFlags(ActivityFlags.FromBackground);
                //context.ApplicationContext.StartService(start);

            }

            if (intent.Action == "android.media.VOLUME_CHANGED_ACTION")
            {

                int newVolume = intent.GetIntExtra("android.media.EXTRA_VOLUME_STREAM_VALUE", 0);
                int oldVolume = intent.GetIntExtra("android.media.EXTRA_PREV_VOLUME_STREAM_VALUE", 0);

                if (newVolume != oldVolume)
                {
                    if (newVolume > oldVolume)
                    {
                        Log.Info(guid.ToString() + DateTime.Now, $"Volume UP: {newVolume}, Prev Volumn: {oldVolume}");
                    }
                    else
                    {
                        Log.Info(guid.ToString() + DateTime.Now, $"Volume DOWN: {newVolume}, Prev Volumn: {oldVolume}");
                        numberOfVolumnDownPresses++;
                        Log.Debug(guid.ToString() + DateTime.Now, numberOfVolumnDownPresses.ToString());
                        if (numberOfVolumnDownPresses == 3)
                        {
                            numberOfVolumnDownPresses = 0;

                            Android.Content.Intent start = new Android.Content.Intent(context, typeof(AppActivity));
                            start.AddFlags(ActivityFlags.NewTask);
                            context.ApplicationContext.StartActivity(start);
                        }
                    }
                }
            }
        }
    }
}

