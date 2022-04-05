using System;
using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// Représente un avis
    /// </summary>
    [DataContract]
    public class Avis : IEquatable<Avis>
    {
        [DataMember(EmitDefaultValue = false)]
        public Utilisateur Utilisateur { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Contenu { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="utilisateur">Un utilisateur(Nom, Prénom)</param>
        /// <param name="contenu">Contenu de l'avis</param>
        public Avis(Utilisateur utilisateur, string contenu)
        {
            Utilisateur = utilisateur;
            Contenu = contenu;
        }
        /// <summary>
        /// Deux avis sont égaux si l'utilisateur est le même et le contenu aussi
        /// </summary>
        /// <param name="other">Autre utilisateur</param>
        /// <returns></returns>
        public bool Equals([AllowNull] Avis other)
        {
            return Contenu.Equals(other.Contenu) && Utilisateur.Equals(other.Utilisateur);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Avis);
        }
        /// <summary>
        /// HashCode = HashCode du string Contenu
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Contenu.GetHashCode();
        }
        public override string ToString()
        {
            return $"AVIS:\tUtilisateur: {Utilisateur} Contenu: {Contenu}";
        }
    }
}
