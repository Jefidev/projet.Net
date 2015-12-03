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
    public partial class MenuChef : Window
    {
        private string CurUser;
        private string filtre;

        public MenuChef(string m)
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();

            CurUser = m;


            // Initialisation filtre

            FiltreCB.Items.Add("TOUS");
            FiltreCB.Items.Add("OUVERT");
            FiltreCB.Items.Add("EN TRAITEMENT");
            FiltreCB.Items.Add("A VALIDER");
            FiltreCB.Items.Add("RESOLU");
            FiltreCB.SelectedIndex = 0;
            filtre = "TOUS";

            // Initialisation DefautsLV



            // Initialisation des détails d'un défaut
            
            DefautLabel.Visibility = Visibility.Hidden;
            PositionLabel.Visibility = Visibility.Hidden;
            PositionReponseLabel.Visibility = Visibility.Hidden;
            DescriptionLabel.Visibility = Visibility.Hidden;
            DescriptionReponseLabel.Visibility = Visibility.Hidden;
            InterventionsLV.Visibility = Visibility.Hidden;
        }


        // Quand changement de filtre
        private void FiltreCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)FiltreCB.SelectedItem;
            filtre = typeItem.Content.ToString();
        }

        

        // Quand changement de défaut
    }
}
