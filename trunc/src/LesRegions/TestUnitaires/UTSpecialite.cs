using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitaires
{
    public class UTSpecialite
    {
        [Fact]
        public void TestConstructeur()
        {
            Specialite s1 = new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            Assert.True(s1.Nom.Equals("Les ravioles"));
            Assert.True(s1.Description.Equals("De la bonne bouffe"));
            Assert.True(s1.Image1.Equals("Image1"));
            Assert.True(s1.Image2.Equals("Image2"));
            Assert.True(s1.Region.Equals(new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
        }
        [Fact]
        public void TestListLieux()
        {
            Specialite s1 = new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            s1.Initialisation();
            s1.Lieux.Add(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            Assert.True(s1.Lieux[0].Equals(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"))));
        }
        [Fact]
        public void TestListAvis()
        {
            Specialite s1 = new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            s1.Initialisation();
            s1.Avis.Add(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"),"Voici mon contenu"));
            Assert.True(s1.Avis[0].Equals(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Voici mon contenu")));
        }
        [Fact]
        public void TestListSpecialites()
        {
            Specialite s1 = new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            s1.Initialisation();
            s1.Specialites.Add(new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            Assert.True(s1.Specialites[0].Equals(new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"))));
        }
    }
}
