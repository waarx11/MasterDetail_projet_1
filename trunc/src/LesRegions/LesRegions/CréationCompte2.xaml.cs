using LesRegions.converters;
using Modele;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour CréationCompte2.xaml
    /// </summary>
    public partial class CréationCompte2 : Window
    {
        public Manager Mgr => (App.Current as App).LeManager;
        public CréationCompte2()
        {
            InitializeComponent();
            DataContext = Mgr.UtilisateurConnecté;
        }

        private void ValidButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            var CompteWindow = new Compte();
            CompteWindow.ShowDialog();
            Mgr.Type = (WindowType)Accessibilite.Connecte;
            if (Mgr.UtilConnecte == Manager.NewOrChange.New)
            {
                Mgr.utilisateurs.Add(Mgr.UtilisateurConnecté);
            }
            else if(Mgr.UtilConnecte == Manager.NewOrChange.Change)
            {
                Mgr.utilisateurs.Remove(Mgr.UtilisateurConnecté);
                Mgr.utilisateurs.Add(Mgr.UtilisateurConnecté);
            }
        }

        private void AnnuleButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            var CréationCompteWindow = new CréationCompte();
            CréationCompteWindow.ShowDialog();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = "C:\\Users\\Public\\Pictures\\Sample Pictures",
                FileName = "Images",
                DefaultExt = ".jpg | .png | .gif",
                Filter = "All images files (.jpg, .png, .gif)|*.jpg;*.png;*.gif|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png|GIF files (.gif)|*.gif"
            };

            bool? result = dlg.ShowDialog();

            if(result == true)
            {
                FileInfo fi = new FileInfo(dlg.FileName);
                string filename = fi.Name;
                int i = 0;
                while (File.Exists(System.IO.Path.Combine(String2ImageConverter.ImagesPath, filename)))
                {
                    i++;
                    filename = $"{fi.Name.Remove(fi.Name.LastIndexOf('.'))}_{i}{fi.Extension}";
                }
                File.Copy(dlg.FileName, System.IO.Path.Combine(String2ImageConverter.ImagesPath, filename));
                Mgr.UtilisateurConnecté.Image = filename;
            }
        }
    }
}
