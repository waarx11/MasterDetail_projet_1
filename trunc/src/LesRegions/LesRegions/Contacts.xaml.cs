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
    /// Logique d'interaction pour Contacts.xaml
    /// </summary>
    public partial class Contacts : Window
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EnvoieButton_Click(object sender, RoutedEventArgs e)
        {
            if(RadioButton1.IsChecked == false && RadioButton2.IsChecked == false && RadioButton3.IsChecked == false && RadioButton4.IsChecked == false)
            {
                MessageBox.Show("Problème aucune raison selectionné", "Selectionner une raison de nous conctacter", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Close();
            }
        }
    }
}
