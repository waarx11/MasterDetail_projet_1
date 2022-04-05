using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LesRegions
{
    /// <summary>
    /// Logique d'interaction pour CarteFrance.xaml
    /// </summary>
    public partial class CarteFrance : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public CarteFrance()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void QuitteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CompteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(Mgr.Valeur == Manager.Accessibilite.Visiteur) 
            {
                MessageBox.Show("Vous n'avez pas accès à ce contenu", "Connectez-vous pour avoir accès à votre compte", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Close();
                var CompteWindow = new Compte();
                CompteWindow.ShowDialog();
            }
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            var ContactWindow = new Contacts();
            ContactWindow.ShowDialog();
        }

        private void Region_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Polygon s = (Polygon)sender;
            Polygon[] array =
            {
                Auvergne_Rhône_Alpes,
                Provence_Côte_d_azur,
                Occitanie,
                Corse,
                Nouvelle_Aquitaine,
                Bourgogne_Franche_Comté,
                Bretagne,
                Centre_Val_de_Loire,
                Grand_Est,
                Hauts_de_france,
                îl_de_france,
                Normandie,
                Pays_de_la_Loire,
                Guadeloupe,
                Matinique,
                Guyane,
                Nouvelle_Calédonie,
                Réunion
            };

            int index = 0;
            foreach(Polygon pol in array)
            {
                if (pol.Name == s.Name)
                    Mgr.RégionSélectionné = Mgr.Regions[index];
                index++;
            }

            var RegionWindow = new Regions();
            RegionWindow.ShowDialog();
        }

    }
}
