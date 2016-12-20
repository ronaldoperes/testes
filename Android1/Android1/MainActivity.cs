using System;
using Android.App;
using Android.App.Admin;
using Android.Views;
using Android.Widget;
using Android.OS;
using Quobject.SocketIoClientDotNet.Client;
using System.Collections.Generic;
using Android.Content;
using Bradesco.Resources;
using Android.Preferences;

namespace Bradesco
{    
    

    [Activity(Label = "Bradesco", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape,
        MainLauncher = true,  Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
        Immersive = true)]
    public class MainActivity : Activity
    {                
        private int count = 0;

        Socket socket = IO.Socket("http://192.168.0.10:3000");
                
        private MediaController mediaController;
        bool primeiro = false;
        
        private const string PrefKioskMode = "pref_kiosk_mode";

        
        
        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    //VideoView video = FindViewById<VideoView>(Resource.Id.myVideo);
        //    //video.SystemUiVisibility = StatusBarVisibility.Hidden;

        //    //if (!video.IsPlaying)
        //    //{
        //    //    socket.Emit("START");
        //    //    video.Start();
        //    //}            
        //}
      


        //protected override void OnStop()
        //{
        //    base.OnStop();
        //    //var intent = new Intent(this, typeof(MainActivity));
        //    //intent.AddFlags(ActivityFlags.NewTask);
        //    //this.StartActivity(intent);
        //}
     

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            Window.AddFlags(WindowManagerFlags.Fullscreen);// | WindowManagerFlags.TurnScreenOn);
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            Window.AddFlags(WindowManagerFlags.DismissKeyguard);
            Window.AddFlags(WindowManagerFlags.NotFocusable);


            IntentFilter filter = new IntentFilter(Intent.ActionScreenOff);


            RequestWindowFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var sp = PreferenceManager.GetDefaultSharedPreferences(this);

            var edit = sp.Edit();
            edit.PutBoolean(PrefKioskMode, true);
            edit.Commit();

            // Get our button from the layout resource,
            // and attach an event to it                                   

            VideoView video = FindViewById<VideoView>(Resource.Id.myVideo);
            video.SystemUiVisibility = StatusBarVisibility.Hidden;

            if (!video.IsPlaying)
            {
                socket.Emit("START");
                video.Start();
            }
            //Window.ClearFlags(WindowManagerFlags.TurnScreenOn);

            //var metrics = Resources.DisplayMetrics;
            //var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            //var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //var uri = Android.Net.Uri.Parse("http://192.168.30.193:3000/videos/a.mp4");
            //video.SetVideoURI(uri);


            //string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
            //string filename = System.IO.Path.Combine(path, "a.mp4");

            //var directories = Directory.EnumerateDirectories("./sdcard/Movies");

            video.SetVideoPath("./sdcard/Movies/a.mp4");


            video.Touch += delegate
            {
                socket.Emit("START");
                video.Start();
                count++;

                if (count > 50)
                    this.Finish();
            };


            mediaController = new MediaController(this, true);
            video.SetMediaController(mediaController);

            video.Completion += (object sender, EventArgs e) =>
            {
                video.Start();
                //socket.Emit("START");
                //socket.Emit("RESTART", video.CurrentPosition);
            };

            socket.On("UPDATE", () =>
            {
                socket.Emit("POS", video.CurrentPosition);
            });


            socket.On("START", () =>
            {
                video.Start();
                //video.SeekTo((int)data);
                //socket.Emit("RESTART", video.CurrentPosition);
            });

            socket.On("primeiro", (data) =>
            {
                primeiro = true;
            });

            //Console.WriteLine(primeiro);

            socket.On("POS", (data) =>
            {
                if (video.IsPlaying)
                {
                    string[] x = data.ToString().Replace("{", "").Replace("}", "").Replace("\n", "").Replace("\"", "").Split(':');
                    video.SeekTo(int.Parse(x[1]));
                }
            });


            //socket.On("RESTART", (data) =>
            //{
            //    Console.WriteLine(data);
            //    video.Start();
            //    video.SeekTo((int)data);
            //});



            //try
            //{
            //    socket.On(Socket.EVENT_CONNECT, () =>
            //    {
            //        socket.Emit("connection");
            //    });

            //    socket.On(Socket.EVENT_DISCONNECT, () =>
            //    {
            //        socket.Connect();
            //    });


            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex);
            //}


            //DevicePolicyManager devicePolicyManager = (DevicePolicyManager)GetSystemService(Context.DevicePolicyService);
            //ComponentName demoDeviceAdmin = new ComponentName(this, Java.Lang.Class.FromType(typeof(DeviceAdmin)));
            //Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
            //intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, demoDeviceAdmin);
            //intent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "Device administrator");
            //StartActivity(intent);

            StartLockTask();
            SendBroadcast(new Intent(Intent.ActionCloseSystemDialogs));
        }
        


        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }

       

        //public override void OnWindowFocusChanged(bool hasFocus)
        //{
        //    base.OnWindowFocusChanged(hasFocus);

        //    if (!hasFocus)
        //    {
        //        var closeDialog = new Intent(Intent.ActionCloseSystemDialogs);
        //        SendBroadcast(closeDialog);
        //    }
        //}

        //Optional: Disable buttons (i.e. volume buttons)
        private readonly IList<Keycode> _blockedKeys = new[] { Keycode.VolumeDown, Keycode.VolumeUp };
        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (_blockedKeys.Contains(e.KeyCode))
                return true;

           

            return base.DispatchKeyEvent(e);
        }

        //protected override void OnPause()
        //{

        //    ActivityManager AM = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);

        //    AM.MoveTaskToFront(this.TaskId,1);
            
        //    base.OnPause();
        //}



        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

    }
    
}

