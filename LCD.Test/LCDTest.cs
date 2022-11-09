namespace LCD.Test
{
    public class LCDTest
    {
        public static readonly object[][] Associations = new[]
        {
            new object[] { 0, Digits.Zero },
            new object[] { 1, Digits.One },
            new object[] { 2, Digits.Two },
            new object[] { 3, Digits.Three },
            new object[] { 4, Digits.Four },
            new object[] { 5, Digits.Five },
            new object[] { 6, Digits.Six },
            new object[] { 7, Digits.Seven },
            new object[] { 8, Digits.Eight },
            new object[] { 9, Digits.Nine }
        };

        [Theory]
        [MemberData(nameof(Associations))]
        public void TestChiffreUnique(int chiffre, string representation)
        {
            // ETANT DONNE le chiffre <chiffre>
            // QUAND on le convertit en LCD
            var lcd = AfficheurLCD.Convert(chiffre);

            // ALORS on obtient sa représentation LCD
            Assert.Equal(representation, lcd);
        }

        [Fact]
        public void Test10()
        {
            //ETANT DONNE le chiffre 10
            //QUAND on le convertit en LCD
            var lcd = AfficheurLCD.Convert(10);

            // ALORS on obtient la représentation LCD de 1 suivie de 0, horizontalement
            Assert.Equal("     _ " + Environment.NewLine +
                         "  | | |" + Environment.NewLine +
                         "  | |_|" + Environment.NewLine
                , lcd);
        }

        [Fact]
        public void Test1234567890()
        {
            //ETANT DONNE le chiffre 1234567890
            //QUAND on le convertit en LCD
            var lcd = AfficheurLCD.Convert(1234567890);

            // ALORS on obtient la représentation LCD de 1 suivie de 2, etc., horizontalement
            Assert.Equal("     _   _       _   _   _   _   _   _ " + Environment.NewLine +
                         "  |  _|  _| |_| |_  |_    | |_| |_| | |" + Environment.NewLine +
                         "  | |_   _|   |  _| |_|   | |_|  _| |_|" + Environment.NewLine
                , lcd);
        }
    }
}