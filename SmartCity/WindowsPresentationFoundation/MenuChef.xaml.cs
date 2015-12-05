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
        private int curDef;


        public MenuChef(SmartCityReference.ServiceWCFSmartCityClient s, string m)
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();

            service = s;
            user = m;

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
            HideDetails();
            HideActions();
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
            HideDetails();
            HideActions();

            Object item = DefautsLV.SelectedItem;

            if (item == null)
                return;

            curDef = (int)(item.GetType().GetProperty("IdDefaut").GetValue(item, null));
            SmartCityReference.DefautWCF def = service.GetDefautById(curDef);

            if (def == null)
                return;

            //Remplissage des labels
            DefautLabel.Content = "Défaut n° " + def.IdDefaut;
            PositionReponseLabel.Content = def.Position;
            DescriptionReponseLabel.Content = def.Description;

            // Remplissage photo
            BitmapImage bi = (BitmapImage)(item.GetType().GetProperty("Photo").GetValue(item, null));
            PhotoI.Source = bi;

            ShowDetails();

            // Boutons valider défaut/attribuer un ouvrier
            string lastEtat = (string)(item.GetType().GetProperty("Etat").GetValue(item, null));
            if (lastEtat.Equals("A VALIDER"))
                ValiderButton.Visibility = Visibility.Visible;
            /*else if (lastEtat.Equals("OUVERT"))
            {
                List<SmartCityReference.PersonneWCF> list = service.GetAllOuvriers().ToList();

                if (list == null)
                {
                    NoOuvrierLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    foreach (var p in list)
                    {
                        OuvriersCB.Items.Add(p.Mail);
                    }

                    OuvriersCB.SelectedIndex = 0;
                    OuvriersLabel.Visibility = Visibility.Visible;
                    OuvriersCB.Visibility = Visibility.Visible;
                    AttribuerOuvrierButton.Visibility = Visibility.Visible;
                }
            }*/

            // Remplissage d'InterventionsLV
            List<SmartCityReference.InterventionWCF> listInt = service.GetInterventionsByDefautOrderByDate(curDef).ToList();

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


        private void AttribuerOuvrierButton_Click(object sender, RoutedEventArgs e)
        {
            service.AddIntervention("EN TRAITEMENT", "Assignation d'un ouvrier (" + "ouvrier" + ")", DateTime.Now, curDef, user);
            service.AddIntervention("EN TRAITEMENT", "Assignation d'un ouvrier (par " + user + ")", DateTime.Now, curDef, "ouvrier");
            RefreshDefautsLV();
        }


        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            service.AddIntervention("RESOLU", "Problème résolu et validé", DateTime.Now, curDef, user);
            RefreshDefautsLV();
        }


        private void HideDetails()
        {
            DefautLabel.Visibility = Visibility.Hidden;
            PositionLabel.Visibility = Visibility.Hidden;
            PositionReponseLabel.Visibility = Visibility.Hidden;
            DescriptionLabel.Visibility = Visibility.Hidden;
            DescriptionReponseLabel.Visibility = Visibility.Hidden;
            InterventionsLV.Visibility = Visibility.Hidden;
            PhotoI.Visibility = Visibility.Hidden;
        }


        private void ShowDetails()
        {
            DefautLabel.Visibility = Visibility.Visible;
            PositionLabel.Visibility = Visibility.Visible;
            PositionReponseLabel.Visibility = Visibility.Visible;
            DescriptionLabel.Visibility = Visibility.Visible;
            DescriptionReponseLabel.Visibility = Visibility.Visible;
            InterventionsLV.Visibility = Visibility.Visible;
            PhotoI.Visibility = Visibility.Visible;
        }


        public void HideActions()
        {
            NoOuvrierLabel.Visibility = Visibility.Hidden;
            OuvriersLabel.Visibility = Visibility.Hidden;
            OuvriersCB.Visibility = Visibility.Hidden;
            ValiderButton.Visibility = Visibility.Hidden;
            AttribuerOuvrierButton.Visibility = Visibility.Hidden;
        }
    }
}
