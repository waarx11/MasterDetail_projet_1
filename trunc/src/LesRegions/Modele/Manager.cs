using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;


namespace Modele
{
    public class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Dépendance vers le gestionnaire de la persitance
        /// </summary>
        public IPersistanceManager Persist { get; set; }

        public ReadOnlyCollection<Region> Regions { get; private set; }
        public List<Region> regions = new List<Region>();
        public ReadOnlyCollection<Utilisateur> Utilisateurs { get; private set; }
        public List<Utilisateur> utilisateurs = new List<Utilisateur>();

        /// <summary>
        /// Enum permettant de gérer l'ajout d'un nouvel avis dans la bonne list Avis suivant la fenêtre ouverte (Lieu, Specialite, Objet).
        /// </summary> 
        public enum WindowType
        {
            WinLieu,
            WinSpecialite,
            WinObjet,
            WinRegion
        }
         
        public WindowType Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        private WindowType type;

        /// <summary>
        /// Enum permettant de gérer un utilisateur visiteur ou connecté
        /// </summary>
        public enum Accessibilite
        {
            Connecte,
            Visiteur
        }

        public Accessibilite Valeur
        {
            get => valeur;
            set
            {
                if (valeur != value)
                {
                    valeur = value;
                    OnPropertyChanged(nameof(Valeur));
                }
            }
        }
        private Accessibilite valeur;
        /// <summary>
        /// Enum permettant de savoir si l'utilisateur créer un nouvel utilisateur ou le modifie 
        /// </summary>
        public enum NewOrChange
        {
            New,
            Change
        }

        public NewOrChange UtilConnecte
        {
            get => utilConnecte;
            set
            {
                if (utilConnecte != value)
                {
                    utilConnecte = value;
                    OnPropertyChanged(nameof(UtilConnecte));
                }
            }
        }
        private NewOrChange utilConnecte;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public Lieu LieuSélectionné
        {
            get => lieuSélectionné;
            set
            {
                if(lieuSélectionné != value)
                {
                    lieuSélectionné = value;
                    OnPropertyChanged(nameof(LieuSélectionné));
                }
            }
        }
        private Lieu lieuSélectionné;

        public Region RégionSélectionné
        {
            get => régionSélectionné;
            set
            {
                if (régionSélectionné != value)
                {
                    régionSélectionné = value;
                    OnPropertyChanged(nameof(RégionSélectionné));
                }
            }
        }
        public Region régionSélectionné;

        public Objet ObjetSélectionné
        {
            get => objetSélectionné;
            set
            {
                if (objetSélectionné != value)
                {
                    objetSélectionné = value;
                    OnPropertyChanged(nameof(ObjetSélectionné));
                }
            }
        }
        public Objet objetSélectionné;

        public Specialite SpécialitéSélectionné
        {
            get => spécialitéSélectionné;
            set
            {
                if (spécialitéSélectionné != value)
                {
                    spécialitéSélectionné = value;
                    OnPropertyChanged(nameof(SpécialitéSélectionné));
                }
            }
        }
        public Specialite spécialitéSélectionné;

        public Utilisateur UtilisateurConnecté
        {
            get => utilisateurConnecté;
            set
            {
                if (utilisateurConnecté != value)
                {
                    utilisateurConnecté = value;
                    OnPropertyChanged(nameof(utilisateurConnecté));
                }
            }
        }
        public Utilisateur utilisateurConnecté;

        public Utilisateur UtilisateurTemporaire
        {
            get => utilisateurTemporaire;
            set
            {
                if (utilisateurTemporaire != value)
                {
                    utilisateurTemporaire = value;
                    OnPropertyChanged(nameof(utilisateurTemporaire));
                }
            }
        }
        public Utilisateur utilisateurTemporaire;

        /// <summary>
        /// Retourne le lieu de la liste de lieux de l'utilisateur connecté qui possède le nom donné en paramètre ou null si le nom n'est pas touvé
        /// </summary>
        /// <param name="Nom"></param>
        /// <returns></returns>
        public Lieu GetLieu(string Nom)
        {
            return UtilisateurConnecté.Lieux.SingleOrDefault(l => l.Nom == Nom);
        }
        /// <summary>
        /// Retourne un si l'identifiant et le mot de passe sont possèdé par le même utilisateur et ne sont pas vide ou faux sinon 0
        /// </summary>
        /// <param name="Identifiant">Identifiant d'un utilsateur à tester</param>
        /// <param name="Mot_de_passe">Mot de passe d'un utilsateur à tester</param>
        /// <returns></returns>
        public int GetUtilisateurExist(string Identifiant, string Mot_de_passe)
        {
            Utilisateur u1 = Utilisateurs.SingleOrDefault(u => u.Identifiant == Identifiant && u.Mot_de_passe == Mot_de_passe);
            if(u1 == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// Retourne l'utilisateur qui possède l'identifiant en paramètre
        /// </summary>
        /// <param name="Identifiant">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        public Utilisateur GetUtilisateur(string Identifiant)
        {
            return Utilisateurs.SingleOrDefault(l => l.Identifiant == Identifiant);
        }

        /// <summary>
        /// Constructeur qui initialise une ReadOnlyCollection de région et une ReadOnlyCollection d'utilisateur
        /// </summary>
        public Manager(IPersistanceManager p)
        {
            Persist = p;
            Regions = new ReadOnlyCollection<Region>(regions);
            Utilisateurs = new ReadOnlyCollection<Utilisateur>(utilisateurs);
        }

       public void ChargeDonnees()
        {
            var données = Persist.Charge(); // dépendance
            foreach(var u in données.utilisateurs)
            {
                utilisateurs.Add(u);
            }
            foreach (var r in données.regions)
            {
                regions.Add(r);
            }
        }

        public void SauvegardeDonnees()
        {
            Persist.Sauvegarde(utilisateurs, regions); // dépendance
        }


        /// <summary>
        /// Méthode qui change la propriété RégionSélectionné par la région en paramètre
        /// </summary>
        /// <param name="r"></param>
        public void ChangerRégionSélectionné(Region r)
        {
            RégionSélectionné = r;
        }
    }
}
