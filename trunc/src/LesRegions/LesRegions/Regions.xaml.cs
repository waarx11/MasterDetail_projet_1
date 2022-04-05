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
    /// Logique d'interaction pour Regions.xaml
    /// </summary>
    public partial class Regions : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public Regions()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            var ContactrWindow = new Contacts();
            ContactrWindow.ShowDialog();
        }

        private void LieuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ListBox).SelectedItem != null)
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
        private void ObjetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                Mgr.Type = WindowType.WinObjet;
                var ObjetWindow = new Objets();
                ObjetWindow.ShowDialog();
            }
        }
    }
}
