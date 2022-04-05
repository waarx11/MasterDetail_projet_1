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
    /// Logique d'interaction pour Objets.xaml
    /// </summary>
    public partial class Objets : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;   
        public Objets()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Mgr.Type = Manager.WindowType.WinRegion;
            Mgr.ObjetSélectionné = null;
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

        private void ObjetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                Mgr.Type = WindowType.WinObjet;
                var ObjetsWindow = new Objets();
                ObjetsWindow.ShowDialog();
            }
        }
        private void LieuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                Mgr.Type = WindowType.WinLieu;
                var LieuxWindow = new Lieux();
                LieuxWindow.ShowDialog();
            }
        }

    }
}
