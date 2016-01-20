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
using Environment = Android.OS.Environment;
using Android.Locations;
using System.Linq;
using Android.Runtime;
using SmartCityAndroid;


namespace SmartCityAndroid
{
    [Activity(Label = "SmartCityAndroid", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity , ILocationListener
    {
        //variables d'acces aux services
        public static readonly EndpointAddress endpoint = new EndpointAddress("http://192.168.1.7:53222/ServiceWCFSmartCity.svc");
        public ServiceWCFSmartCityClient _client;

        //Variables pour l'appareil photo
        public static File _file;
        public static File _dir;
        public static Bitmap curImage;

        //Variables de recuperation de coordonnees
        public string coordonnes;
        public Location currentLocation;
        public LocationManager locationManager;
        public string locationProvider;

        //Affichage ecran
        public EditText description;
        public EditText commentaire;
        public EditText mail;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitialisationService();

            Button sendButton = FindViewById<Button>(Resource.Id.sendButton);

            //Recuperation des differents champs texte
            description = FindViewById<EditText>(Resource.Id.DescriptionTF);
            commentaire = FindViewById<EditText>(Resource.Id.CommentaireTF);
            mail = FindViewById<EditText>(Resource.Id.mailTF);

            //Methode effectuee lors de l'envoie
            sendButton.Click += delegate {

                if(curImage == null)
                {
                    Toast.MakeText(this, "Vous devez prendre une photo du défaut", ToastLength.Long).Show();
                    return;
                }

                if(description.Text == null)
                {
                    Toast.MakeText(this, "Vous devez entrer une description du défaut", ToastLength.Long).Show();
                    return;
                }

                _client.OuvrirDefautAsync(null, description.Text, coordonnes, mail.Text, commentaire.Text);
            };

            _client.OuvrirDefautCompleted += _client_OuvrirDefautCompleted;

            //Si y'a un appareil photo
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                Button pictureButton = FindViewById<Button>(Resource.Id.photoButton);
                pictureButton.Click += takePicture;
            }

            InitializeLocationManager();
        }


        private void _client_OuvrirDefautCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Button button = FindViewById<Button>(Resource.Id.sendButton);

            if (e.Error != null)
            {
                Toast.MakeText(this, e.Error.Message, ToastLength.Long).Show();
                return;
            }
            else if (e.Cancelled)
            {
                Toast.MakeText(this, e.Cancelled.ToString(), ToastLength.Long).Show();
                return;
            }

            Toast.MakeText(this, "Le défaut a bien été envoyé", ToastLength.Long).Show();
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
        }

        #endregion

        #region Acces appareil photo

        private void takePicture(object sender, EventArgs eventArgs)
        {
            //Dans la foulee on va sauvegarder la position actuelle

            if (currentLocation != null)
            {
                coordonnes = string.Format("{0:f6},{1:f6}", currentLocation.Latitude, currentLocation.Longitude);
            }
            //Si le GPS n'a pas encore été réveillé
            else
            {
                Toast.MakeText(this, "Le GPS n'est pas encore actif. Réessayé dans 1 minute", ToastLength.Long).Show();
                return;
            }

            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
            StartActivityForResult(intent, 0);

        }


        private void CreateDirectoryForPictures()
        {
            _dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "defautPicture");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            Bitmap bitmap = _file.Path.LoadAndResizeBitmap(200, 200);
            if (bitmap != null)
            {
                curImage = bitmap;
                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
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

        //On bind le GPS quand l'application revient sur le devant de la scene
        protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
        }

        //On unbind le GPS quand l'applic se met en pause
        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }

        //Methode de l'interface listener de la position
        public void OnLocationChanged(Location location)
        {
            currentLocation = location;
        }

        public void OnProviderDisabled(string provider) {}

        public void OnProviderEnabled(string provider) {}

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras) {}

        #endregion
    }
}

