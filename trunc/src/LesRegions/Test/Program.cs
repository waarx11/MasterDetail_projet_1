using Modele;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur les constructeur et affichage:");
            Console.WriteLine("-------------------------------------------------------------");
            Region region = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            Console.WriteLine(region);
            region.Initialisation();

            Utilisateur utilisateur = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            Console.WriteLine(utilisateur);

            Specialite specialite = new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            Console.WriteLine(specialite);
            specialite.Initialisation();

            Lieu lieu = new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            Console.WriteLine(lieu);

            Avis avis = new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com","07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er","azerty1"), "Blabla voici mon avis");
            Console.WriteLine(avis);

            Activite activite = new Activite("Jet-ski");
            Console.WriteLine(activite);

            Objet objet = new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            Console.WriteLine(objet);
            objet.Initialisation();

            
            
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur les listes de Région:");
            Console.WriteLine("-------------------------------------------------------------");
            region.Lieux.Add(new Lieu("Aubière", "Où j'habite", "image1", "image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            region.Specialites.Add(new Specialite("Lasagne", "description", "image1", "image2", new Region("Auvergne-Rhône-Alpes", "description", "logo", "image2", "map")));
            region.Objets.Add(new Objet("Couteaux", "description", "image1", "image2", new Region("Auvergne-Rhône-Alpes", "description", "logo", "image2", "map")));
            Console.WriteLine("** List Lieux **");
            foreach (Lieu l in region.Lieux)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine("** List Spécialités **");
            foreach (Specialite s in region.Specialites)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("** List Objets **");
            foreach (Objet o in region.Objets)
            {
                Console.WriteLine(o);
            }


            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur les listes de Objet:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("** List Objets **");
            objet.Objets.Add(new Objet("Couteaux", "description", "image1", "image2", new Region("Auvergne-Rhône-Alpes", "description", "logo", "image2", "map")));
            foreach (Objet o in objet.Objets)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("** List Lieux **");
            objet.Lieux.Add(new Lieu("Paris", "description", "image1", "image2","map", new Region("Auvergne-Rhône-Alpes", "description", "logo", "image2", "map")));
            foreach (Lieu l in objet.Lieux)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine("** List Avis **");
            objet.AjouterAvis(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Blabla voici mon avis"));
            foreach (Avis a in objet.Avis)
            {
                Console.WriteLine(a);
            }


            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur les listes de Sécialité:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("** List Spécialités **");
            specialite.Specialites.Add(new Specialite("Pizza", "description", "image1", "image2", new Region("Auvergne-Rhône-Alpes", "description", "logo", "image2", "map")));
            foreach (Specialite s in specialite.Specialites)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("** List Lieux **");
            specialite.Lieux.Add(new Lieu("Paris", "description", "image1", "image2", "map", new Region("Auvergne-Rhône-Alpes", "description", "logo", "image2", "map")));
            foreach (Lieu l in objet.Lieux)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine("** List Avis **");
            specialite.AjouterAvis(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Blabla voici mon avis"));
            foreach (Avis a in objet.Avis)
            {
                Console.WriteLine(a);
            }


            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur les listes de Lieu:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("** List Avis **");
            lieu.AjouterAvis(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Blabla voici mon avis"));
            foreach (Avis a in objet.Avis)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("** List Activités **");
            lieu.Activites.Add(new Activite("snow-board"));
            lieu.Activites.Add(new Activite("luge"));
            foreach (Activite a in lieu.Activites)
            {
                Console.WriteLine(a);
            }


            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur les listes de'Utilisareur:");
            Console.WriteLine("-------------------------------------------------------------");
            utilisateur.Evenements[new DateTime(21, 06 , 12)] = "snow";
            utilisateur.Evenements[new DateTime(21 , 06 , 13)] = "luge";
            utilisateur.Evenements[new DateTime(21 , 06 , 14)] = "ski";
            foreach(KeyValuePair<DateTime,string> kvp in utilisateur.Evenements)
            {
                Console.WriteLine($"[{kvp.Key} : {kvp.Value}]");
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Test sur la persistance");
            Console.WriteLine("-------------------------------------------------------------");

            Manager manager = new Manager(new Stub.Stub());
            manager.ChargeDonnees();
            manager.Persist = new DataContract.DataContract2XML();
            manager.SauvegardeDonnees();
        }
    }
}
