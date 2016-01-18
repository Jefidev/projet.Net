using Android.App;
using Android.OS;
using Android.Widget;
using SmartCityShared;
using System.ServiceModel;
using System;

namespace SmartCityAndroid
{
    [Activity(Label = "SmartCityAndroid", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity
    {
        public int c = 0;
        public TextView tv;
        public static readonly EndpointAddress endpoint = new EndpointAddress("http://192.168.1.8:53222/ServiceWCFSmartCity.svc");
        public ServiceWCFSmartCityClient _client;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitialisationService();

            tv = FindViewById<TextView>(Resource.Id.Compteur);

            Button button = FindViewById<Button>(Resource.Id.sendButton);
            button.Click += delegate { _client.sayHelloAsync(); };
            
        }

        private void InitialisationService()
        {
            BasicHttpBinding binding = createbasicHTTP();

            _client = new ServiceWCFSmartCityClient(binding, endpoint);
            _client.sayHelloCompleted += hello;
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

    }
}

