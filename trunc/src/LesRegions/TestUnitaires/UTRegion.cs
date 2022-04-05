using Modele;
using System;
using Xunit;

namespace TestUnitaires
{
    public class UTRegion
    { 
        [Fact]
        public void TestConstructeur()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpes", "Meilleur région de France", "logo", "image", "map");
            Assert.True(r1.Nom.Equals("Auvergne-Rhône-Alpes"));
            Assert.True(r1.Description.Equals("Meilleur région de France"));
            Assert.True(r1.Logo.Equals("logo"));
            Assert.True(r1.Image.Equals("image"));
            Assert.True(r1.Map.Equals("map"));
        }
        [Fact]
        public void TestSetNom()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Nom = "L'argentine";
            Assert.True(r1.Nom.Equals("L'argentine"));
        }
        [Fact]
        public void TestSetDescription()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Description = "La pire région de France";
            Assert.True(r1.Description.Equals("La pire région de France"));
        }
        [Fact]
        public void TestSetLogo()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Logo = "mauvaise-logo";
            Assert.True(r1.Logo.Equals("mauvaise-logo"));
        }
        [Fact]
        public void TestSetImage()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Image = "fause-image";
            Assert.True(r1.Image.Equals("fause-image"));
        }
        [Fact]
        public void TestSetMap()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Map = "mauvaise-map";
            Assert.True(r1.Map.Equals("mauvaise-map"));
        }
        [Fact]
        public void TestListLieux()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Initialisation();
            r1.Lieux.Add(new Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", r1));
            Assert.True(r1.Lieux[0].Equals(new Modele.Lieu("Vieux Lyon", "Oh il est vieux ce lyon", "Image1", "Image2", "map", r1)));
        }
        [Fact]
        public void TestListObjets()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Initialisation();
            r1.Objets.Add(new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", r1));
            Assert.True(r1.Objets[0].Equals(new Objet("Briquet en or", "Un objet qui s'enflame", "Image1", "Image2", r1)));
        }
        [Fact]
        public void TestListSpecialites()
        {
            Region r1 = new Region("Auvergne-Rhône-Alpe", "Meilleur région de France", "logo", "image", "map");
            r1.Initialisation();
            r1.Specialites.Add(new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", r1));
            Assert.True(r1.Specialites[0].Equals(new Specialite("Les ravioles", "De la bonne bouffe", "Image1", "Image2", r1)));
        }
    }
}

