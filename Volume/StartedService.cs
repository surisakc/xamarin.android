using Android.App;
using Android.Content;
using Android.OS;

namespace Volume
{
    [Service]
    public class StartedService : Service
    {

        ReceiveBoot receiveBoot = new ReceiveBoot();

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            // Testing with BroadcastReceiver.
            IntentFilter filter = new IntentFilter();
            filter.AddAction("android.media.VOLUME_CHANGED_ACTION");
            RegisterReceiver(receiveBoot, filter);

            return StartCommandResult.NotSticky;
        }

        public override void OnDestroy()
        {
            // Testing with BroadcastReceiver.
            UnregisterReceiver(receiveBoot);

            base.OnDestroy();
        }
    }
}

