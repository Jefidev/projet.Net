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
using BusinessLogicLayer.DTO;

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
            PersonneDTO p = BusinessLogicLayer.BLL.SelectPersonne(LoginTB.Text);

            if (PasswordTB.Text.Equals(p.Password))
                ResultatLabel.Content = "Réussi";
            else
                ResultatLabel.Content = "Raté";
        }

    }
}
