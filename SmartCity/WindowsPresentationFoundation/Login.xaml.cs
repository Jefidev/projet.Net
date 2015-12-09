using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WindowsPresentationFoundation
{
    public partial class Login : Window
    { 
        public Login()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            LoginTB.Focus();
        }

        private void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            SmartCityReference.ServiceWCFSmartCityClient service = new SmartCityReference.ServiceWCFSmartCityClient();
            SmartCityReference.PersonneWCF p = service.Connexion(LoginTB.Text, PasswordTB.Text);

            if (p == null)
                ResultatLabel.Content = "Connexion ratée !";
            else
            {
                MenuChef menuchef = new MenuChef(service, p);
                App.Current.MainWindow = menuchef;
                this.Close();
                menuchef.Show();
            }

            ResultatLabel.Visibility = Visibility.Visible;
            PasswordTB.Text = "";
        }
    }
}
