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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsCommunicationFoundation;


namespace WindowsPresentationFoundation
{
    public partial class Login : Window
    { 
        public Login()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }

        private void ConnexionButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceWCFSmartCityReference.ServiceWCFSmartCityClient service = new ServiceWCFSmartCityReference.ServiceWCFSmartCityClient();

            PasswordTB.Text = "";

            if (service.Connexion(LoginTB.Text, PasswordTB.Text))
                ResultatLabel.Content = "Connexion réussie !";
            else
                ResultatLabel.Content = "Connexion ratée !";

            ResultatLabel.Visibility = Visibility.Visible;
        }
    }
}
