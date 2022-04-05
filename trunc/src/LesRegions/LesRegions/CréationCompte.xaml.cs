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
    /// Logique d'interaction pour CréationCompte.xaml
    /// </summary>
    public partial class CréationCompte : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public CréationCompte()
        {
            InitializeComponent();
            DataContext = Mgr.UtilisateurConnecté;
            if(Mgr.UtilConnecte == Manager.NewOrChange.Change)
            {
                IdentifiantTectBox.IsReadOnly = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ValidButton_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordBox.Password == PasswordBox2.Password && !String.IsNullOrWhiteSpace(PasswordBox.Password) && !String.IsNullOrWhiteSpace(PasswordBox2.Password))
            {
                Close();
                var CarteFranceWindow = new CréationCompte2();
                CarteFranceWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Votre mot de passe est incorrect , veuillez retaper votre mot de passe !", "Mot de passe non identique!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Mgr.UtilisateurConnecté.Mot_de_passe = PasswordBox.Password;
        }
        private void PasswordBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Mgr.UtilisateurConnecté.Mot_de_passe = PasswordBox.Password;
        }
    }
}
