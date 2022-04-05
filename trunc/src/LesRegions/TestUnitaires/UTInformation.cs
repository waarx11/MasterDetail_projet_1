using Modele;
using System;
using Xunit;

namespace TestUnitaires
{
    public class UTInformation
    {
        [Fact]
        public void TestConstructeur()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            Assert.True(i1.Nom.Equals("info"));
            Assert.True(i1.Description.Equals("desc"));
            Assert.True(i1.Image1.Equals("image1"));
            Assert.True(i1.Image2.Equals("image2"));
            Assert.True(i1.Region.Equals(new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
        }
        [Fact]
        public void TestSetNom()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            i1.Nom = "mauvaise-info";
            Assert.True(i1.Nom.Equals("mauvaise-info"));
        }
        [Fact]
        public void TestSetDescription()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            i1.Description = "mauvaise-desc";
            Assert.True(i1.Description.Equals("mauvaise-desc"));
        }
        [Fact]
        public void TestSetImage1()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            i1.Image1 = "mauvaise-image1";
            Assert.True(i1.Image1.Equals("mauvaise-image1"));
        }
        [Fact]
        public void TestSetImage2()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            i1.Image2 = "mauvaise-image2";
            Assert.True(i1.Image2.Equals("mauvaise-image2"));
        }
        [Fact]
        public void TestSetRegion()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            i1.Region = new Region("mauvaise-Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            Assert.True(i1.Region.Equals(new Region("mauvaise-Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map")));
        }
        [Fact]
        public void TestListAvis()
        {
            Objet i1 = new Objet("info", "desc", "image1", "image2", new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map"));
            i1.AjouterAvis(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Blabla voici mon avis"));
            Assert.True(i1.Avis[0].Equals(new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Blabla voici mon avis")));
        }
    }
}

