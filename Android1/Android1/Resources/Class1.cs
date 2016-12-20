using Android.App;
using Android.Content;
using Android.App.Admin;
using Android.Widget;
using Bradesco;

namespace Bradesco.Resources
{
    //[BroadcastReceiver(Enabled = true)]
    //[IntentFilter(new[] { Intent.ActionBootCompleted })]
    //public class MyBootReceiver : BroadcastReceiver
    //{
    //    public override void OnReceive(Context context, Intent intent2)
    //    {
    //        // Do stuff here when device reboots.
    //        //context.StartActivity(typeof(MainActivity));
    //        var intent = new Intent(context, typeof(MainActivity));
    //        intent.AddFlags(ActivityFlags.NewTask);
    //        context.StartActivity(intent);
    //    }
    //}

    [BroadcastReceiver(Permission = "android.permission.BIND_DEVICE_ADMIN", Enabled = true, Name = "br.com.bizsys.bradescovideo.AdminReceiver")]
    [MetaData("android.app.device_admin", Resource = "@xml/device_admin")]
    [IntentFilter(new[] {"android.app.action.DEVICE_ADMIN_ENABLED", Intent.ActionBootCompleted, Intent.ActionMain})]
    
    public class AdminReceiver : DeviceAdminReceiver
    {
        public override void OnReceive(Context context, Intent intent2)
        {
            // Do stuff here when device reboots.
            //context.StartActivity(typeof(MainActivity));
            intent2.AddFlags(ActivityFlags.TaskOnHome);
            
            var intent = new Intent(context, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(intent);
        }

        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);            
            Toast.MakeText(context, "[Device Admin enabled]",ToastLength.Short).Show();
            Common.BecomeHomeActivity(context);
        }

        public override void OnDisabled(Context context, Intent intent)
        {
            base.OnDisabled(context, intent);
            Toast.MakeText(context, "[Device Admin disabled]", ToastLength.Short).Show();
        }

        public override void OnLockTaskModeEntering(Context context, Intent intent, string pkg)
        {
            base.OnLockTaskModeEntering(context, intent, pkg);
            Toast.MakeText(context, "[Kiosk mode enabled]", ToastLength.Short).Show();
        }

        public override void OnLockTaskModeExiting(Context context, Intent intent)
        {
            base.OnLockTaskModeExiting(context, intent);
            Toast.MakeText(context, "[Kiosk mode disabled]", ToastLength.Short).Show();
        }

    }


    
    //@Override
    //public CharSequence onDisableRequested(Context context, Intent intent)
    //{
    //    return "Warning: Device Admin is going to be disabled.";
    //}

    //@Override
    //public void onDisabled(Context context, Intent intent)
    //{
    //    Common.showToast(context, "[Device Admin disabled]");
    //}

    //@Override
    //public void onLockTaskModeEntering(Context context, Intent intent,
    //        String pkg)
    //{
    //    Common.showToast(context, "[Kiosk Mode enabled]");
    //}

    //@Override
    //public void onLockTaskModeExiting(Context context, Intent intent)
    //{
    //    Common.showToast(context, "[Kiosk Mode disabled]");
    //}
}
