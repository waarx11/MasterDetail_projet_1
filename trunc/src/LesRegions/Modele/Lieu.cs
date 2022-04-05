using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Représente un lieu
    /// </summary>
    [DataContract]
    public class Lieu : Information
    {
        [DataMember(EmitDefaultValue = false)]
        public string Map { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool IsChecked { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Activite> Activites { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom du lieu</param>
        /// <param name="description">Description du lieu</param>
        /// <param name="image1">Première image du lieu</param>
        /// <param name="image2">Deuxième image du lieu</param>
        /// <param name="map">Map du lieu</param>
        /// <param name="region">La région du lieu</param>
        public Lieu(string nom, string description, string image1, string image2, string map, Region region) : base(nom, description, image1, image2, region)
        {
            Map = map;
            IsChecked = false;
            Activites = new List<Activite>();
        }
        /// <summary>
        /// Constructeur qui prend seulement un nom pour gérer la liste de lieu d'un utilisateur
        /// </summary>
        /// <param name="nom">Nom du lieu</param>
        public Lieu(string nom) : base(nom, null, null, null, null)
        {
            Map = null;
            IsChecked = false;
            Activites = new List<Activite>();
        }
        /// <summary>
        /// Constructeur null
        /// </summary>
        public Lieu() : base(null, null, null, null, null)
        {
            Map = null;
            IsChecked = false;
            Activites = new List<Activite>();
        }
        public override string ToString()
        {
            return $"LIEU:\tNom: {Nom} Description: {Description}";
        }

    }
}
