using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitaires
{
    public class UTUtilisateur
    {
        [Fact]
        public void TestConstructeur1()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat","Adrien1er","azerty1");
            Assert.True(u1.Nom.Equals("DENONFOUX"));
            Assert.True(u1.Prenom.Equals("Adrien"));
            Assert.True(u1.Image.Equals("Image"));
            Assert.True(u1.Age.Equals(18));
            Assert.True(u1.Adresse_mail.Equals("adriendenonfoux3005didi@gamil.com"));
            Assert.True(u1.Numero_telephone.Equals("07-68-42-61-44"));
            Assert.True(u1.Description.Equals("Bonjour je m'appelle Adrien et j'adore le chocolat"));
            Assert.True(u1.Identifiant.Equals("Adrien1er"));
            Assert.True(u1.Mot_de_passe.Equals("azerty1"));
        }
        [Fact]
        public void TestConstructeur2()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Adrien1er", "azerty1");
            Assert.True(u1.Nom.Equals("DENONFOUX"));
            Assert.True(u1.Prenom.Equals("Adrien"));
            Assert.True(u1.Image.Equals("image"));
            Assert.True(u1.Age.Equals(0));
            Assert.True(u1.Adresse_mail.Equals("anonyme"));
            Assert.True(u1.Numero_telephone.Equals("anonyme"));
            Assert.True(u1.Description.Equals("aucune"));
            Assert.True(u1.Identifiant.Equals("Adrien1er"));
            Assert.True(u1.Mot_de_passe.Equals("azerty1"));
        }
        [Fact]
        public void TestSetNom()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Nom = "VERDIER";
            Assert.True(u1.Nom.Equals("VERDIER"));
        }
        [Fact]
        public void TestSetPrenom()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Description = "Nathan";
            Assert.True(u1.Description.Equals("Nathan"));
        }
        [Fact]
        public void TestSetImage()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Image = "Bonne_Image";
            Assert.True(u1.Image.Equals("Bonne_Image"));
        }
        [Fact]
        public void TestSetAge()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Age = 19;
            Assert.True(u1.Age.Equals(19));
        }
        [Fact]
        public void TestSetAdresse_mail()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Adresse_mail = "nathanverdier@gmail.com";
            Assert.True(u1.Adresse_mail.Equals("nathanverdier@gmail.com"));
        }
        [Fact]
        public void TestSetNumero_telephone()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Numero_telephone = "07-68-42-61-45";
            Assert.True(u1.Numero_telephone.Equals("07-68-42-61-45"));
        }
        [Fact]
        public void TestSetDescription()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Description = "Bonjour je m'appelle Nathan et j'adore le vanille";
            Assert.True(u1.Description.Equals("Bonjour je m'appelle Nathan et j'adore le vanille"));
        }

        [Fact]
        public void TestSetIdentifiant()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Identifiant = "Adrien2eme";
            Assert.True(u1.Identifiant.Equals("Adrien2eme"));
        }
        [Fact]
        public void TestSetMotDePasse()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.Mot_de_passe = "1ytreza";
            Assert.True(u1.Mot_de_passe.Equals("1ytreza"));
        }
        [Fact]
        public void TestListLieux()
        {
            Utilisateur u1 = new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1");
            u1.AjouterLieu(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            u1.AjouterLieu(new Lieu("Aubière", "Où j'habite", "image1", "image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            Assert.True(u1.Lieux[0].Equals(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"))));
            u1.SupprimerLieu(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            Assert.True(u1.Lieux[0].Equals(new Lieu("Aubière", "Où j'habite", "image1", "image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"))));
        }
    }
}
