using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitaires
{
    public class UTAvis
    {
        [Fact]
        public void TestConstructeur()
        {
            Avis a1 = new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"),"Mon avis");
            Assert.True(a1.Utilisateur.Equals(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1")));
            Assert.True(a1.Contenu.Equals("Mon avis"));
        }
        [Fact]
        public void TestSetUtilisateur()
        {
            Avis a1 = new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Mon avis");
            a1.Utilisateur = new Utilisateur("Verdier", "Nathan", "Image", 18, "verdierNathan@gamail.com", "07-68-42-61-45", "Bonjour je m'appelle nathan et j'adore la vanille", "Waarx", "Nathan63");
            Assert.True(a1.Utilisateur.Equals(new Utilisateur("Verdier", "Nathan", "Image", 18, "verdierNathan@gamail.com", "07-68-42-61-45", "Bonjour je m'appelle nathan et j'adore la vanille", "Waarx", "Nathan63")));
        }
        [Fact]
        public void TestSetContenu()
        {
            Avis a1 = new Avis(new Utilisateur("DENONFOUX", "Adrien", "Image", 18, "adriendenonfoux3005didi@gamil.com", "07-68-42-61-44", "Bonjour je m'appelle Adrien et j'adore le chocolat", "Adrien1er", "azerty1"), "Mon avis");
            a1.Contenu = "Votre avis";
            Assert.True(a1.Contenu.Equals("Votre avis"));
        }
    }
}
