using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Représente une spécialité
    /// </summary>
    [DataContract]
    public class Specialite : Information
    {
        [DataMember(EmitDefaultValue = false)]
        public List<Specialite> Specialites { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Lieu> Lieux { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de la spécialité</param>
        /// <param name="description">Description de la spécialité</param>
        /// <param name="image1">Première image de la spécialité</param>
        /// <param name="image2">Deuxième image de la spécialité</param>
        /// <param name="region">La région de la spécialité</param>
        public Specialite(string nom, string description, string image1, string image2, Region region) : base(nom, description, image1, image2, region) { }
        /// <summary>
        /// Méthode qui initialise les listes de la classe Specialite
        /// </summary>
        public void Initialisation()
        {
            Specialites = new List<Specialite>();
            Lieux = new List<Lieu>();
        }
        public override string ToString()
        {
            return $"SPECIALITE:\tNom: {Nom} Description: {Description}";
        }
    }
}
