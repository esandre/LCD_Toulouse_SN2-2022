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
    }
}