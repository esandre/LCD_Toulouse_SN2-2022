namespace LCD.Test
{
    public class LCDTest
    {
        [Fact]
        public void Test1()
        {
            // ETANT DONNE le chiffre 1
            const int chiffre = 1;

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
            const int chiffre = 2;

            // QUAND on le convertit en LCD
            var lcd = new AfficheurLCD().Convert(2);

            // ALORS on obtient trois lignes horizontales et un deux lignes verticales opposées
            Assert.Equal(" _ " + Environment.NewLine +
                         " _|" + Environment.NewLine +
                         "|_ " + Environment.NewLine, lcd);
        }
    }
}