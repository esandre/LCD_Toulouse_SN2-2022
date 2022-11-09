namespace LCD.Test
{
    public class LCDTest
    {
        [Fact]
        public void Test1()
        {
            // ETANT DONNE le chiffre 1
            // QUAND on le convertit en LCD
            var lcd = new AfficheurLCD().Convert(1);

            // ALORS on obtient deux lignes verticales
            Assert.Equal("" + Environment.NewLine +
                         "|" + Environment.NewLine +
                         "|" + Environment.NewLine, lcd);
        }

        [Fact]
        public void Test2()
        {
            // ETANT DONNE le chiffre 2
            // QUAND on le convertit en LCD
            var lcd = new AfficheurLCD().Convert(2);

            // ALORS on obtient trois lignes horizontales et un deux lignes verticales opposées
            Assert.Equal(" _ " + Environment.NewLine +
                         " _|" + Environment.NewLine +
                         "|_ " + Environment.NewLine, lcd);
        }

        [Fact]
        public void Test3()
        {
            // ETANT DONNE le chiffre 3
            // QUAND on le convertit en LCD
            var lcd = new AfficheurLCD().Convert(3);

            // ALORS on obtient trois lignes horizontales et un deux lignes verticales côté droit
            Assert.Equal(" _ " + Environment.NewLine +
                         " _|" + Environment.NewLine +
                         " _|" + Environment.NewLine, lcd);
        }

        [Fact]
        public void Test4()
        {
            // ETANT DONNE le chiffre 4
            // QUAND on le convertit en LCD
            var lcd = new AfficheurLCD().Convert(4);

            // ALORS on obtient trois lignes horizontales et un deux lignes verticales opposées
            Assert.Equal("   " + Environment.NewLine +
                         "|_|" + Environment.NewLine +
                         "  |" + Environment.NewLine, lcd);
        }
    }
}