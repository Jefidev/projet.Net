using Android.App;
using Android.OS;
using Android.Widget;
using SmartCityShared;

namespace SmartCityAndroid
{
    [Activity(Label = "SmartCityAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public int c = 0;
        public TextView tv;
        private WebServiceSmartCity.ServiceWCFSmartCity service = new WebServiceSmartCity.ServiceWCFSmartCity();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            tv = FindViewById<TextView>(Resource.Id.Compteur);

            Button button = FindViewById<Button>(Resource.Id.sendButton);
            button.Click += Button_Click;
            
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            tv.Text = service.sayHello();
            c++;
        }
    }
}

