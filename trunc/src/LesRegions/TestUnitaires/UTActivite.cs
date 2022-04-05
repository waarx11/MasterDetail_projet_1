using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitaires
{
    public class UTActivite
    {
        [Fact]
        public void TestConstructeur()
        {
            Activite a1 = new Activite("Accrobranche");
            Assert.True(a1.Nom.Equals("Accrobranche"));
        }
        [Fact]
        public void TestSetNom()
        {
            Activite a1 = new Activite("Accrobranche");
            a1.Nom = "Jet-ski";
            Assert.True(a1.Nom.Equals("Jet-ski"));
        }
    }
}
