using System;
using Android.Content;
using Android.Widget;
using Android.Content.PM;
using Android.App.Admin;

namespace Bradesco
{
    public class Common
    {
        public static void showToast(Context context, String text)
        {
            Toast.MakeText(context, text, ToastLength.Long).Show();
        }

        public static String GetHomeActivity(Context c)
        {
            PackageManager pm = c.PackageManager;
            Intent intent = new Intent(Intent.ActionMain);
            intent.AddCategory(Intent.CategoryHome);
            ComponentName cn = intent.ResolveActivity(pm);
            if (cn != null)
                return cn.FlattenToShortString();
            else
                return "none";
        }

        public static void BecomeHomeActivity(Context c)
        {
            ComponentName deviceAdmin = new ComponentName(c, "AdminReceiver");
            DevicePolicyManager dpm = (DevicePolicyManager)c.GetSystemService(Context.DevicePolicyService);
            dpm.SetLockTaskPackages(deviceAdmin, new string[] { "br.com.bizsys.bradescovideo" });

            if (!dpm.IsAdminActive(deviceAdmin))
            {
                showToast(c, "This app is not a device admin!");
                return;
            }
            if (!dpm.IsDeviceOwnerApp(c.PackageName))
            {
                showToast(c, "This app is not the device owner!");
                return;
            }
            IntentFilter intentFilter = new IntentFilter(Intent.ActionMain);
            intentFilter.AddCategory(Intent.CategoryDefault);
            intentFilter.AddCategory(Intent.CategoryHome);
            ComponentName activity = new ComponentName(c, "MainActivity");
            dpm.AddPersistentPreferredActivity(deviceAdmin, intentFilter, activity);
            showToast(c, "Home activity: " + GetHomeActivity(c));
        }
    }
}