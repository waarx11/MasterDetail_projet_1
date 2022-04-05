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
using static Modele.Manager;

namespace LesRegions
{
    /// <summary>
    /// Logique d'interaction pour Specialites.xaml
    /// </summary>
    public partial class Specialites : Window
    {

        public Manager Mgr => (App.Current as App).LeManager;

        public Specialites()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Mgr.Type = Manager.WindowType.WinRegion;
            Mgr.SpécialitéSélectionné = null;
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            var ContactWindow = new Contacts();
            ContactWindow.ShowDialog();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.Valeur == Manager.Accessibilite.Visiteur)
            {
                MessageBox.Show("Vous n'avez pas accès à ce contenu", "Connectez-vous pour avoir accès à votre compte", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            else
            {
                var Avis_et_nouveaux_lieuxWindow = new NouvelAvis();
                Avis_et_nouveaux_lieuxWindow.ShowDialog();
            }
        }

        private void LieuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                Mgr.Type = WindowType.WinLieu;
                var LieuWindow = new Lieux();
                LieuWindow.ShowDialog();
            }
        }

        private void SpécialitéListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                Mgr.Type = WindowType.WinSpecialite;
                var SpecialiteWindow = new Specialites();
                SpecialiteWindow.ShowDialog();
            }
        }
    }
}

