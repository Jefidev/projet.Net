using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        //private SmartCityReference.DefautWCF def;
        //public ObservableCollection<SmartCityReference.DefautWCF> ocDef;


        public MenuChef(SmartCityReference.ServiceWCFSmartCityClient s, string m)
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();

            service = s;
            user = m;
            //def = null;

            // Initialisation filtre
            filtre = "TOUS";
            FiltreCB.Items.Add("TOUS");
            FiltreCB.Items.Add("OUVERT");
            FiltreCB.Items.Add("EN TRAITEMENT");
            FiltreCB.Items.Add("A VALIDER");
            FiltreCB.Items.Add("RESOLU");
            FiltreCB.SelectedIndex = 0;

            // Initialisation DefautsLV
            RefreshDefautsLV();

            // Initialisation des détails d'un défaut
            HideLabels();
        }


        // Quand changement de filtre
        private void FiltreCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp = (string)FiltreCB.SelectedItem;

            if (!filtre.Equals(tmp))
            {
                filtre = tmp;
                RefreshDefautsLV();
            }
        }


        // Rafaichir la DefautsLV selon le nouveau filtre
        private void RefreshDefautsLV()
        {
            DefautsLV.Items.Clear();

            List<SmartCityReference.DefautWCF> listDef = service.GetAllDefauts().ToList();

            if(listDef == null)
                return;

            foreach (var d in listDef)
            {
                SmartCityReference.InterventionWCF i = service.GetLastInterventionByDefaut(d.IdDefaut);

                if (filtre.Equals("TOUS") || filtre.Equals(i.Etat))
                {
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CreateOptions = BitmapCreateOptions.None;
                    bi.CacheOption = BitmapCacheOption.Default;
                    bi.StreamSource = new MemoryStream(d.Photo.Bytes);
                    bi.EndInit();

                    var tmp = new
                    {
                        IdDefaut = d.IdDefaut,
                        Photo = bi,
                        Etat = i.Etat,
                        Description = d.Description,
                        Commentaire = i.Commentaire
                    };

                    DefautsLV.Items.Add(tmp);
                }
            }
        }


        // Pour afficher les détails quand changement de défaut
        private void DefautsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InterventionsLV.Items.Clear();

            Object item = DefautsLV.SelectedItem;

            if (item == null)
            {
                HideLabels();
                return;
            }

            int id = (int)(item.GetType().GetProperty("IdDefaut").GetValue(item, null));
            SmartCityReference.DefautWCF def = service.GetDefautById(id);

            if (def == null)
                return;

            //Remplissage des labels
            DefautLabel.Content = "Défaut n° " + def.IdDefaut;
            PositionReponseLabel.Content = def.Position;
            DescriptionReponseLabel.Content = def.Description;

            // Remplissage photo
            BitmapImage bi = (BitmapImage)(item.GetType().GetProperty("Photo").GetValue(item, null));
            PhotoI.Source = bi;

            ShowLabels();


            // Remplissage d'InterventionsLV
            List<SmartCityReference.InterventionWCF> listInt = service.GetInterventionsByDefautOrderByDate(id).ToList();

            if (listInt == null)
                return;

            foreach (var i in listInt)
            {
                var tmp = new
                {
                    Etat = i.Etat,
                    DateIntervention = i.DateIntervention,
                    Personne = i.Personne,
                    Commentaire = i.Commentaire
                };

                InterventionsLV.Items.Add(tmp);
            }
        }        


        private void HideLabels()
        {
            DefautLabel.Visibility = Visibility.Hidden;
            PositionLabel.Visibility = Visibility.Hidden;
            PositionReponseLabel.Visibility = Visibility.Hidden;
            DescriptionLabel.Visibility = Visibility.Hidden;
            DescriptionReponseLabel.Visibility = Visibility.Hidden;
            InterventionsLV.Visibility = Visibility.Hidden;
            PhotoI.Visibility = Visibility.Hidden;
        }


        private void ShowLabels()
        {
            DefautLabel.Visibility = Visibility.Visible;
            PositionLabel.Visibility = Visibility.Visible;
            PositionReponseLabel.Visibility = Visibility.Visible;
            DescriptionLabel.Visibility = Visibility.Visible;
            DescriptionReponseLabel.Visibility = Visibility.Visible;
            InterventionsLV.Visibility = Visibility.Visible;
            PhotoI.Visibility = Visibility.Visible;
        }
    }
}
