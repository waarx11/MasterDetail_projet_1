using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Représente un Objet
    /// </summary>
    [DataContract]
    public class Objet : Information
    {
        [DataMember(EmitDefaultValue = false)]
        public List<Objet> Objets { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Lieu> Lieux { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de l'objet</param>
        /// <param name="description">Description de l'objet</param>
        /// <param name="image1">Première image de l'objet</param>
        /// <param name="image2">Deuxième image de l'objet</param>
        /// <param name="region">La région de l'objet</param>
        public Objet(string nom, string description, string image1, string image2, Region region) : base(nom, description, image1, image2, region) { }
        /// <summary>
        /// Méthode qui initialise les listes de la classe Objet
        /// </summary>
        public void Initialisation()
        {
            Objets = new List<Objet>();
            Lieux = new List<Lieu>();
        }
        public override string ToString()
        {
            return $"OBJET:\tNom: {Nom} Description: {Description}";
        }
    }
}
