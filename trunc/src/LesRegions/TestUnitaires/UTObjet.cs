using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitaires
{
    public class UTObjet
    {
        [Fact]
        public void TestConstructeur()
        {
            Objet o1 = new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map"));
            Assert.True(o1.Nom.Equals("Briquet en or"));
            Assert.True(o1.Description.Equals("Un objet qui s'enflame"));
            Assert.True(o1.Image1.Equals("Image1"));
            Assert.True(o1.Image2.Equals("Image2"));
            Assert.True(o1.Region.Equals(new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map")));
        }
        [Fact]
        public void TestListLieux()
        {
            Objet o1 = new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map")); 
            o1.Initialisation();
            o1.Lieux.Add(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map")));
            Assert.True(o1.Lieux[0].Equals(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map"))));
        }
        [Fact]
        public void TestListAvis()
        {
            Objet o1 = new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map"));
            o1.Initialisation();
            o1.Avis.Add(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Voici mon contenu"));
            Assert.True(o1.Avis[0].Equals(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Voici mon contenu")));
        }
        [Fact]
        public void TestListObjets()
        {
            Objet o1 = new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map"));
            o1.Initialisation();
            o1.Objets.Add(new Objet("Briquet en argent", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
            Assert.True(o1.Objets[0].Equals(new Objet("Briquet en argent", "Un objet qui s'enflame", "Image1", "Image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"))));
        }
    }
}
