namespace LCD.Test
{
    public class LCDTest
    {
        public static readonly object[][] Associations = new[]
        {
            new object[] { 1, Digits.One },
            new object[] { 2, Digits.Two },
            new object[] { 3, Digits.Three },
            new object[] { 4, Digits.Four },
            new object[] { 5, Digits.Five }
        };

        [Theory]
        [MemberData(nameof(Associations))]
        public void TestChiffreUnique(int chiffre, string representation)
        {
            // ETANT DONNE le chiffre <chiffre>
            // QUAND on le convertit en LCD
            var lcd = new AfficheurLCD().Convert(chiffre);

            // ALORS on obtient sa représentation LCD
            Assert.Equal(representation, lcd);
        }
    }
}