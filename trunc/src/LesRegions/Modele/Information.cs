using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract]
    public abstract class Information : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        [DataMember(EmitDefaultValue = false)]
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
        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Image1 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Image2 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Region Region { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Avis> Avis { get; set; }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de l'information</param>
        /// <param name="description">Description de l'informatio</param>
        /// <param name="image1">Première imagede l'informatio</param>
        /// <param name="image2">Deuxième image de l'informatio</param>
        /// <param name="region">La région de l'informatio</param>
        public Information(string nom, string description, string image1, string image2, Region region)
        {
            Nom = nom;
            Description = description;
            Image1 = image1;
            Image2 = image2;
            Region = region;
            Avis = new ObservableCollection<Avis>();
        }
        /// <summary>
        /// Ajoute l'avis en paramètre dans la liste d'avis de l'information
        /// </summary>
        /// <param name="avis">Avis à ajouter</param>
        public void AjouterAvis(Avis avis)
        {
            Avis.Add(avis);
        }
        /// <summary>
        /// Deux informations sont égales si elles ont le même nom
        /// </summary>
        /// <param name="other">Autre information</param>
        /// <returns></returns>
        public bool Equals([AllowNull] Information other)
        {
            return Nom.Equals(other.Nom);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Information);
        }
        /// <summary>
        /// HashCode = HashCode du string Nom
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            if(Nom == null)
            {
                return 31;
            }
            return Nom.GetHashCode();
        }
    }
}
