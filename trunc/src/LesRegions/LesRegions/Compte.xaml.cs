using Modele;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LesRegions
{
    /// <summary>
    /// Logique d'interaction pour Compte.xaml
    /// </summary>
    public partial class Compte : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        private DateTime selectedKey;
        public Compte()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            var CarteFranceWindow = new CarteFrance();
            CarteFranceWindow.ShowDialog();
        }

        private void ContactButton_Click_1(object sender, RoutedEventArgs e)
        {
            var ContactWindow = new Contacts();
            ContactWindow.ShowDialog();
        }

        private void ModifButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Mgr.UtilConnecte = Manager.NewOrChange.Change;
            var IdentificationWindow = new CréationCompte();
            IdentificationWindow.ShowDialog();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            Mgr.UtilisateurConnecté.Evenements.Remove(selectedKey);
        }

        private void ChangeCompteButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddLieuButton_Click(object sender, RoutedEventArgs e)
        {
            var NouveauLieuWindow = new NouveauLieu();
            NouveauLieuWindow.ShowDialog();
        }

        private void SupprLieuButton_Click(object sender, RoutedEventArgs e)
        {
            var SupprLieuWindow = new SupprimerLieu();
            SupprLieuWindow.ShowDialog();
        }

        private void ValButton_Click(object sender, RoutedEventArgs e)
        {
            if(Evennement.Text == null)
            {
                MessageBox.Show("Vous ne pouvez pas continuer", "Renseignez l'événement de la date sélectionné", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.UtilisateurConnecté.Evenements[DatePicker.SelectedDate.Value] = Evennement.Text;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ListBox list= (sender as ListBox);
           KeyValuePair<DateTime, string> selectedEntry= (KeyValuePair<DateTime, string>)list.SelectedItem;
           selectedKey = selectedEntry.Key;
        }
    }
}

