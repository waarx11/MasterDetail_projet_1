using System;
using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// Représente une activité
    /// </summary>
    [DataContract]
    public class Activite : IEquatable<Activite>
    {
        [DataMember(EmitDefaultValue = false)]
        public string Nom { get; set; }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom">Nom de l'activité</param>
        public Activite(string nom)
        {
            Nom = nom;
        }
        /// <summary>
        /// Deux activités sont égales si elles ont le même nom 
        /// </summary>
        /// <param name="other">Autre activité</param>
        /// <returns></returns>
        public bool Equals([AllowNull] Activite other)
        {
            return Nom.Equals(other.Nom);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Activite);
        }
        /// <summary>
        /// HashCode = HashCode du string Nom
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
        public override string ToString()
        {
            return $"ACTIVITE:\tNom: {Nom}";
        }
    }
}
