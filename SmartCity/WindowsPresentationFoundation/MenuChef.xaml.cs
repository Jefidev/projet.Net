using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private SmartCityReference.ServiceWCFSmartCityClient service;
        private string user;
        private string filtre;
        private SmartCityReference.DefautWCF def;
        //public ObservableCollection<SmartCityReference.DefautWCF> ocDef;


        public MenuChef(SmartCityReference.ServiceWCFSmartCityClient s, string m)
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();

            service = s;
            user = m;
            def = null;

            // Initialisation filtre
            FiltreCB.Items.Add("TOUS");
            FiltreCB.Items.Add("OUVERT");
            FiltreCB.Items.Add("EN TRAITEMENT");
            FiltreCB.Items.Add("A VALIDER");
            FiltreCB.Items.Add("RESOLU");
            FiltreCB.SelectedIndex = 0;
            filtre = "TOUS";

            // Initialisation DefautsLV
            RefreshDefautsLV();

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
            string tmp = typeItem.Content.ToString();

            if (!filtre.Equals(tmp))
            {
                filtre = tmp;
                RefreshDefautsLV();
            }
        }


        // Rafaichir la DefautsLV selon le nouveau filtre
        private void RefreshDefautsLV()
        {
            // DB => Défaut + dernière intervention de ce défaut

            // Remplir DefautsLV

            /*foreach (var v in List)
            {

                Test t = new Test
                {
                    Image = LoadImage(f.FileName),
                    Description = "description",
                    Commentaire = "Commentaire",
                    DernierStatut = "dernier",
                    yolo = "oijsdgjh"
                };
             
                DefautsLV.Items.Add();
            }*/
        }


        // Pour afficher les détails quand changement de défaut
        private void DefautsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // DB => Défaut + toutes les interventions de ce défaut (ORDER BY DEFAUT, DATE !!)
            // Remplir labels + InterventionsLV + photo
        }        
    }
}
