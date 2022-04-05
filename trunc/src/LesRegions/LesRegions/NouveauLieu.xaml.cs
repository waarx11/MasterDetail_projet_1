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
    /// Logique d'interaction pour NouveauLieu.xaml
    /// </summary>
    public partial class NouveauLieu : Window, INotifyPropertyChanged
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
        public NouveauLieu()
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
            if (string.IsNullOrWhiteSpace(LeLieu.Nom))
            {
                MessageBox.Show("Veuillez choisir un nom !", "Attention ! Ce nom n'est pas valid !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Mgr.GetLieu(LeLieu.Nom) != null)
            {
                MessageBox.Show("Un lieu avec ce nom existe déjà, veuillez choisir un autre nom!", "Attention ! Ce nom est déjà utilise !", MessageBoxButton.OK, MessageBoxImage.Error);
                int i = 1;
                string nom;
                do
                {
                    i++;
                    nom = $"{LeLieu.Nom}_{i:000}";
                } while (i <= 999 && Mgr.GetLieu(nom) != null);
                if (i != 1000) LeLieu.Nom = nom;
                return;
            }
            Mgr.UtilisateurConnecté.Lieux.Add(LeLieu);
            Close();
        }
    }
}
