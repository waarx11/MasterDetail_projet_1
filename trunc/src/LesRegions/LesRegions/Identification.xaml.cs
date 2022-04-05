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
    /// Logique d'interaction pour Identification.xaml
    /// </summary>
    public partial class Identification : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public Identification()
        {
            InitializeComponent();
            Mgr.UtilisateurConnecté = new Utilisateur();
            Mgr.UtilisateurTemporaire = new Utilisateur();
            DataContext = Mgr.utilisateurTemporaire;
        }

        private void VisiteButton_Click(object sender, RoutedEventArgs e)
        {
            Mgr.UtilisateurConnecté = new Utilisateur();
            Mgr.Valeur = Accessibilite.Visiteur;
            var CarteFranceWindow = new CarteFrance();
            CarteFranceWindow.ShowDialog();
        }

        private void SuivantButton_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.GetUtilisateurExist(Mgr.utilisateurTemporaire.Identifiant, Mgr.utilisateurTemporaire.Mot_de_passe) == 1)
            {

                Mgr.UtilisateurConnecté = Mgr.GetUtilisateur(Mgr.utilisateurTemporaire.Identifiant);
                Mgr.Valeur = Accessibilite.Connecte;
                var CarteFranceWindow = new CarteFrance();
                CarteFranceWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Votre mot de passe ou identifiant n'est pas correct , veuillez retaper pour vous identifier !", "Identifiant ou mot de passe faux !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewCompteButton_Click(object sender, RoutedEventArgs e)
        {
            Mgr.UtilisateurConnecté = new Utilisateur();
            Mgr.UtilConnecte = Manager.NewOrChange.New;
            var NewCompteComptWindow = new CréationCompte();
            NewCompteComptWindow.ShowDialog();

        }

        private void QuitteButton_Click(object sender, RoutedEventArgs e)
        {
            Mgr.SauvegardeDonnees();
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Mgr.utilisateurTemporaire.Mot_de_passe = PasswordBox.Password;
        }
    }
}
