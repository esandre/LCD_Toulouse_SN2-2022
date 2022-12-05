namespace LCD.Test
{
    public class Taille2Test
    {
        [Fact]
        public void Test1()
        {
            // ETANT DONNE le chiffre 1
            const int chiffre = 1;

            // ET un afficheur LCD taille verticale 2
            var afficheur = new AfficheurLCD(tailleVerticale: 2);

            // QUAND on le convertir en LCD taille 1*2
            var lcd = afficheur.Convert(chiffre);

            // ALORS on obtient 4 barres verticales à droite
            Assert.Equal(
                "   " + Environment.NewLine +
                "   " + Environment.NewLine +
                "  |" + Environment.NewLine +
                "  |" + Environment.NewLine +
                "  |" + Environment.NewLine +
                "  |" + Environment.NewLine, 
                lcd);
        }
    }
}
