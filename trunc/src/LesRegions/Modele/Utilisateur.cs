using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Représente un utilisateur
    /// </summary>
    [DataContract]
    public class Utilisateur : IEquatable<Utilisateur>, INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Nom { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Prenom { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string Image { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public int Age { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string Adresse_mail { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string Numero_telephone { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string Description { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 11)]
        public ObservableCollection<Lieu> Lieux { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string Identifiant
        {
            get => identifiant;
            set
            {
                if (identifiant == value) return;
                identifiant = value;
                OnPropertyChanged();
            }
        }
        private string identifiant;
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string Mot_de_passe
        {
            get => mot_de_passe;
            set
            {
                if (mot_de_passe == value) return;
                mot_de_passe = value;
                OnPropertyChanged();
            }
        }
        private string mot_de_passe;

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public  Dictionary<DateTime, string> Evenements { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="prenom">Prénom de l'utilisateur</param>
        /// <param name="image">Photo de profil de l'utilisateur</param>
        /// <param name="information">Information de l'utilisateur</param>
        public Utilisateur(string nom, string prenom, string image, int age, string adresse_mail, string numero_telephone, string descrption, string identifiant, string mot_de_passe)
        {
            Nom = nom;
            Prenom = prenom;
            Image = image;
            Age = age;
            Adresse_mail = adresse_mail;
            Numero_telephone = numero_telephone;
            Description = descrption;
            Lieux = new ObservableCollection<Lieu>();
            Identifiant = identifiant;
            Mot_de_passe = mot_de_passe;
            Evenements = new Dictionary<DateTime, string>();
        }
        /// <summary>
        /// Constructeur mettant Age=0, Adresse_mail=anonyme, Numero_telephone=anonyme, Description=aucune
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        public Utilisateur(string nom, string prenom, string identifiant, string mot_de_passe)
        {
            Nom = nom;
            Prenom = prenom;
            Image = "image";
            Age = 0;
            Adresse_mail = "anonyme";
            Numero_telephone = "anonyme";
            Description = "aucune";
            Lieux = new ObservableCollection<Lieu>();
            Identifiant = identifiant;
            Mot_de_passe = mot_de_passe;
            Evenements = new Dictionary<DateTime, string>();
        }
        public Utilisateur()
        {
            Nom = null;
            Prenom = null;
            Image = null;
            Age = 0;
            Adresse_mail = null;
            Numero_telephone = null;
            Description = null;
            Lieux = new ObservableCollection<Lieu>();
            Identifiant = null;
            Mot_de_passe = null;
            Evenements = new Dictionary<DateTime, string>();
        }
        /// <summary>
        /// Ajoute une clé DateTime et une value string dans le Dictionary : Evenements
        /// </summary>
        /// <param name="d">DateTime : Date de l'évenement à ajouter</param>
        /// <param name="s">String : Description de l'évenement à ajouter</param>
        public void AjouterEvenement(DateTime d, string s)
        {
            Evenements[d] =s;  //Evenements.Add(d, s);
        }
        /// <summary>
        /// Supprime une paire clé(DateTime), value(string) du dictionnaire de la paire en paramètre
        /// </summary>
        /// <param name="d">DateTime : Date de l'évenement à supprimer</param>
        /// <param name="s">String : Description de l'évenement à supprimer</param>
        /// <returns>bool : return false si la paire n'existe pas et true si la suppression c'est effectuer</returns>
        public bool SupprimerEvenement(DateTime d, string s)
        {
            if(!Evenements.ContainsKey(d) || !Evenements.ContainsValue(s))
            {
                return false;
            }
            Evenements.Remove(d);
            return true;
        }
        /// <summary>
        /// Ajout un lieu à la liste de lieu de l'utilisateur si il exite déjà return false
        /// </summary>
        /// <param name="lieu">Nouveau lieu</param>
        /// <returns></returns>
        public bool AjouterLieu(Lieu lieu)
        {
            if (Lieux.Contains(lieu))
            {
                return false;
            }
            Lieux.Add(lieu);
            return true;
        }
        /// <summary>
        /// Supprime le lieu en paramettre dans la lite des lieux d'un utilisateur
        /// </summary>
        /// <param name="lieu">Lieu à supprimer</param>
        /// <returns></returns>
        public bool SupprimerLieu(Lieu lieu)
        {
            if (!Lieux.Contains(lieu))
            {
                return false;
            }
            Lieux.Remove(lieu);
            return true;
        }
        /// <summary>
        /// Utilisateur égal qu'un leurs noms et prénoms sont identiques 
        /// </summary>
        /// <param name="other">Autre utilisateur</param>
        /// <returns></returns>
        public bool Equals([AllowNull] Utilisateur other)
        {
            if (Identifiant == null) 
            {
                return false;
            }
            else
                return Identifiant.Equals(other.Identifiant);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Utilisateur);
        }
        /// <summary>
        /// HashCode est l'HashCode d'Identifiant
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if(Identifiant==null)
            {
                return 0;
            }
            else
                return Identifiant.GetHashCode();
        }
        public override string ToString()
        {
            return $"UTILISATEUR:\tNom: {Nom} Prénom: {Prenom} Age: {Age} adresse-mail: {Adresse_mail} numéro de téléphone: {Numero_telephone} description: {Description}";
        }
    }
}
