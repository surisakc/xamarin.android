using Android.Content;
using Android.Database;
using Android.Media;
using Android.OS;
using Android.Util;

namespace Volume
{
    public class SettingsContentObserver : ContentObserver
    {
        int previousVolume;
        Context context;

        public SettingsContentObserver(Context c, Handler handler) : base(handler)
        {
            context = c;

            AudioManager audio = (AudioManager)context.GetSystemService(Context.AudioService);
            previousVolume = audio.GetStreamVolume(Stream.Music);
        }

        override
    public bool DeliverSelfNotifications()
        {
            return base.DeliverSelfNotifications();
        }

        override
    public void OnChange(bool selfChange)
        {
            base.OnChange(selfChange);

            AudioManager audio = (AudioManager)context.GetSystemService(Context.AudioService);
            int currentVolume = audio.GetStreamVolume(Stream.Music);

            int delta = previousVolume - currentVolume;

            if (delta > 0)
            {
                Log.Debug("on change", "volume decreased"); // volume decreased.
                previousVolume = currentVolume;
            }
            else if (delta < 0)
            {
                Log.Debug("on change", "volume increased"); // volume increased.
                previousVolume = currentVolume;
            }
        }
    }
}

