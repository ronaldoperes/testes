using Android.App;
using Android.Content;

namespace Android1.Resources
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class MyBootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            // Do stuff here when device reboots.
            context.StartActivity(typeof(MainActivity));
        }
    }
}