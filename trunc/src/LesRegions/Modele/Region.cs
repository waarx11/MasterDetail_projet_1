using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// Représente une Région
    /// </summary>
    [DataContract]
    public class Region : IEquatable<Region>
    {
        [DataMember(EmitDefaultValue = false)]
        public string Nom { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Logo { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Image { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Map { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Specialite> Specialites { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Objet> Objets { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Lieu> Lieux { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de la région</param>
        /// <param name="description">Description de la région</param>
        /// <param name="logo">Logo de la région</param>
        /// <param name="image">Image de la région</param>
        /// <param name="map">Map des département de la région</param>
        public Region (string nom, string description, string logo, string image, string map)
        {
            Nom = nom;
            Description = description;
            Logo = logo;
            Image = image;
            Map = map;
        }
        /// <summary>
        /// Méthode qui initialise les listes de la classe Region
        /// </summary>
        public void Initialisation()
        {
            Specialites = new List<Specialite>();
            Objets = new List<Objet>();
            Lieux = new List<Lieu>();
        }
        public bool Equals([AllowNull] Region other)
        {
            return Nom.Equals(other.Nom);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Region);
        }
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
        public override string ToString()
        {
            return $"REGION:\tNom: {Nom} Description: {Description}";
        }

    }
}
