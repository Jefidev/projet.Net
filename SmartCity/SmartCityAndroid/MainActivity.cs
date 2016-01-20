using Android.App;
using Android.OS;
using Android.Widget;
using SmartCityShared;
using System.ServiceModel;
using System;
using Android.Content;
using Android.Provider;
using System.Collections.Generic;
using Android.Content.PM;
using Java.IO;
using Android.Graphics;
using Uri = Android.Net.Uri;
using Android.Locations;
using System.Linq;
using Android.Runtime;

namespace SmartCityAndroid
{
    [Activity(Label = "SmartCityAndroid", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity, ILocationListener
    {
        
        public static readonly EndpointAddress endpoint = new EndpointAddress("http://192.168.1.7:53222/ServiceWCFSmartCity.svc");
        public ServiceWCFSmartCityClient _client;

        public static File _file;
        public static File _dir;
        public static Bitmap curImage;

        public string coordonnes;
        Location currentLocation;

        LocationManager locationManager;
        string locationProvider;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitialisationService();

            Button sendButton = FindViewById<Button>(Resource.Id.sendButton);
            sendButton.Click += delegate { _client.sayHelloAsync(); };

            //Si y'a un appareil photo
            if(IsThereAnAppToTakePictures())
            {
                Button pictureButton = FindViewById<Button>(Resource.Id.photoButton);
                pictureButton.Click += takPicture;
            }

            InitializeLocationManager();
        }


        private void hello(object sender, sayHelloCompletedEventArgs e)
        {
            Button button = FindViewById<Button>(Resource.Id.sendButton);

            if (e.Error != null)
            {
                button.Text = e.Error.Message;
                return;
            }
            else if(e.Cancelled)
            {
                button.Text = e.Cancelled.ToString();
                return;
            }
            else
            {
                button.Text = e.Result;
            }
        }

        #region initialisation service

        private BasicHttpBinding createbasicHTTP()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }


        private void InitialisationService()
        {
            BasicHttpBinding binding = createbasicHTTP();

            _client = new ServiceWCFSmartCityClient(binding, endpoint);
            _client.sayHelloCompleted += hello;
        }

        #endregion

        #region Acces appareil photo

        private void takPicture(object sender, EventArgs eventArgs)
        {


            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
            StartActivityForResult(intent, 0);

        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void CreateDirectoryForPictures()
        {
            _dir = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");

            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Met l'image dans la galerie

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            //On prend l'image dans une variable membre
            curImage = BitmapFactory.DecodeFile(_file.Path);

        }

        #endregion

        #region recuperation coordonnes

        void InitializeLocationManager()
        {
            locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                locationProvider = string.Empty;
            }
        }

        //Methode de l'interface listener de la position
        public void OnLocationChanged(Location location)
        {
            throw new NotImplementedException();
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}

