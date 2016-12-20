using Android.App;
using Android.Content;
using Android.App.Admin;
using Android.Widget;

namespace Bradesco.Resources
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class MyBootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent2)
        {
            // Do stuff here when device reboots.
            //context.StartActivity(typeof(MainActivity));
            var intent = new Intent(context, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(intent);
        }
    }

    

    [BroadcastReceiver(Permission = "android.permission.BIND_DEVICE_ADMIN")]
    [MetaData("name", Value = "android.app.device_admin")]
    [IntentFilter(new[] { "android.app.action.DEVICE_ADMIN_ENABLED", Intent.ActionMain })]
    public class DeviceAdmin : DeviceAdminReceiver
    {
        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);
            Toast.MakeText(context, "DeviceAdmin", ToastLength.Short).Show();
        }
        public override void OnDisabled(Context context, Intent intent)
        {
            base.OnDisabled(context, intent);
        }

        public override void OnPasswordChanged(Context context, Intent intent)
        {
            base.OnPasswordChanged(context, intent);
        }

        public override void OnPasswordFailed(Context context, Intent intent)
        {
            base.OnPasswordFailed(context, intent);
        }
        public override void OnPasswordSucceeded(Context context, Intent intent)
        {
            base.OnPasswordSucceeded(context, intent);
        }
    }
}