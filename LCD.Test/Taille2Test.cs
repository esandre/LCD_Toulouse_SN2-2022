using LCD.Test.Utilities;
using Xunit.Abstractions;

namespace LCD.Test
{
    public class Taille2Test
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private static readonly int[] NombresATester = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 1234567890 };
        private static readonly ushort[] EtirementsVerticauxATester = new ushort[] { 2, 3, ushort.MaxValue };

        public static readonly IEnumerable<object> CasTestVerticalStretch
            = new CartesianData(NombresATester, EtirementsVerticauxATester);

        public Taille2Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(CasTestVerticalStretch))]
        public void TestVerticalStretch(int nombre, ushort verticalStretch)
        {
            // ETANT DONNE le nombre <nombre>
            // ET un afficheur LCD taille verticale <verticalStretch>
            var afficheur = new AfficheurLCD(tailleVerticale: verticalStretch);

            // QUAND on le convertir en LCD taille 1*<verticalStretch>
            var lcd = afficheur.Convert(nombre);

            // ALORS on obtient un <nombre> où chaque barre vertical est multipliée par <verticalStretch>
            var aimedNumber = AfficheurLCD.ConvertWithDefaultSize(nombre);
            var expected = aimedNumber.DuplicateEachLineVertically(verticalStretch);

            Assert.Equal(expected, lcd);
            _testOutputHelper.WriteLine(expected);
            _testOutputHelper.WriteLine(lcd);
        }
    }
}
