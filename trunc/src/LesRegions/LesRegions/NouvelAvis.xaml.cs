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
using static Modele.Manager;

namespace LesRegions
{
    /// <summary>
    /// Logique d'interaction pour Avis_et_nouveaux_lieux.xaml
    /// </summary>
    public partial class NouvelAvis : Window, INotifyPropertyChanged
    {
        public Manager Mgr => (App.Current as App).LeManager;

        public string Contenu
        {
            get => contenu;
            set
            {
                if (contenu == value) return;
                contenu = value;
                OnPropertyChanged();
            }
        }
        string contenu;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        
        public Avis NewAvis { get; set; }
        public NouvelAvis()
        {
            InitializeComponent();
            NewAvis = new Avis(Mgr.UtilisateurConnecté, Contenu);
            DataContext = this;
        }




        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ValidButton_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.Type == WindowType.WinLieu)
            {
                Mgr.LieuSélectionné.Avis.Add(new Avis(Mgr.UtilisateurConnecté, Contenu));
            }
            else if (Mgr.Type == WindowType.WinSpecialite)
            {
                Mgr.SpécialitéSélectionné.Avis.Add(new Avis(Mgr.UtilisateurConnecté, Contenu));
            }
            else if (Mgr.Type == WindowType.WinObjet)
            {
                Mgr.ObjetSélectionné.Avis.Add(new Avis(Mgr.UtilisateurConnecté, Contenu));
            }
            Close();
        }
    }
}
