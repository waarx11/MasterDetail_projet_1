using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitaires
{
    public class UTLieu
    {
        [Fact]
        public void TestConstructeur()
        {
            Lieu l1 = new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map"));
            Assert.True(l1.Nom.Equals("Vieux Lyon"));
            Assert.True(l1.Description.Equals("Oh il est vieux ce lyon"));
            Assert.True(l1.Image1.Equals("Image1"));
            Assert.True(l1.Image2.Equals("Image2"));
            Assert.True(l1.Map.Equals("map"));
            Assert.True(l1.Region.Equals(new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map")));
        }
        [Fact]
        public void TestListActivites()
        {
            Lieu l1 = new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            l1.Activites.Add(new Activite("surf"));
            Assert.True(l1.Activites[0].Equals(new Activite("surf")));
        }
        [Fact]
        public void TestListAvis()
        {
            Lieu l1 = new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            l1.Avis.Add(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Voici mon contenu"));
            Assert.True(l1.Avis[0].Equals(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Voici mon contenu")));
        }
    }
}
