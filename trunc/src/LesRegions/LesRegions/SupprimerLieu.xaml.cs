using Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour SupprimerLieu.xaml
    /// </summary>
    public partial class SupprimerLieu : Window, INotifyPropertyChanged
    {
        public string Nom
        {
            get => nom;
            set
            {
                if (nom == value) return;
                nom = value;
                OnPropertyChanged();
            }
        }
        string nom;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        public Lieu LeLieu { get; set; }
        public Manager Mgr => (App.Current as App).LeManager;
        public SupprimerLieu()
        {
            InitializeComponent();
            LeLieu = new Lieu(Nom);
            DataContext = this;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void ValidButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nom))
            {
                MessageBox.Show("Veuillez choisir un nom !", "Attention ! Ce nom n'est pas valid !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Mgr.GetLieu(Nom) == null)
            {
                MessageBox.Show("Un lieu avec ce nom n'existe pas, veuillez choisir un autre nom !", "Attention ! Ce nom est n'existe pas !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Mgr.UtilisateurConnecté.Lieux.Remove(Mgr.GetLieu(Nom));
            Close();
        }
    }
}
