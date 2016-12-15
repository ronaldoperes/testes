using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Quobject.SocketIoClientDotNet.Client;
using System.Threading.Tasks;
using Android.Media;

namespace Android1
{
    [Activity(Label = "Android1", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape,
        MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
        Immersive = true)]
    public class MainActivity : Activity
    {

        Socket socket = IO.Socket("http://192.168.30.193:3000");

        private MediaController mediaController;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.TurnScreenOn);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it                                   

            VideoView video = FindViewById<VideoView>(Resource.Id.myVideo);
            video.SystemUiVisibility = StatusBarVisibility.Hidden;
            
            //Window.ClearFlags(WindowManagerFlags.TurnScreenOn);

            //var metrics = Resources.DisplayMetrics;
            //var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            //var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            var uri = Android.Net.Uri.Parse("http://192.168.30.193:3000/videos/a.mp4");

            video.SetVideoURI(uri);

            mediaController = new MediaController(this, true);
            video.SetMediaController(mediaController);


            video.Completion += (object sender, EventArgs e) =>
            {
                video.Start();
                socket.Emit("RESTART", video.CurrentPosition);
            };

            socket.On("START", () =>
            {
                video.Start();
            });


            socket.On("RESTART", (data) =>
                        {
                            video.Start();
                            video.SeekTo((int)data);
                        });

            video.Touch += delegate
            {
                video.SystemUiVisibility = StatusBarVisibility.Hidden;
                socket.Emit("START");
                socket.Emit("RESTART", video.CurrentPosition);
                video.Start();

            };

            try
            {
                socket.On(Socket.EVENT_CONNECT, () =>
                {
                    socket.Emit("connection");
                });

                socket.On(Socket.EVENT_DISCONNECT, () =>
                {
                    socket.Connect();
                });


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }



        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

    }
}

