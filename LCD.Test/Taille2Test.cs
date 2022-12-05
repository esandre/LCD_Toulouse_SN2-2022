using LCD.Test.Utilities;
using Xunit.Abstractions;

namespace LCD.Test
{
    public class Taille2Test
    {
#if INTEGRATION
        private const ushort MaxReasonableValue = ushort.MaxValue;
#else
        private const ushort MaxReasonableValue = 50;
#endif

        private readonly ITestOutputHelper _testOutputHelper;
        private static readonly int[] NombresATester = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 1234567890 };
        private static readonly ushort[] EtirementsVerticauxATester = new ushort[] { 2, 3, MaxReasonableValue };

        public static readonly IEnumerable<object> CasTestStretch
            = new CartesianData(NombresATester, EtirementsVerticauxATester);

        public Taille2Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(CasTestStretch))]
        public void TestVerticalStretch(int nombre, ushort verticalStretch)
        {
            // ETANT DONNE le nombre <nombre>
            // ET un afficheur LCD taille verticale <verticalStretch>
            var afficheur = new AfficheurLCD(tailleVerticale: verticalStretch);

            // QUAND on le convertir en LCD taille 1*<verticalStretch>
            var lcd = afficheur.Convert(nombre);

            // ALORS on obtient un <nombre> où chaque barre verticale est multipliée par <verticalStretch>
            var aimedNumber = AfficheurLCD.ConvertWithDefaultSize(nombre);
            var expected = aimedNumber.DuplicateEachLineVertically(verticalStretch);

            _testOutputHelper.WriteLine("expected");
            _testOutputHelper.WriteLine(expected);

            _testOutputHelper.WriteLine("result");
            _testOutputHelper.WriteLine(lcd);

            Assert.Equal(expected, lcd);
        }

        [Theory]
        [MemberData(nameof(CasTestStretch))]
        public void TestHorizontalStretch(int nombre, ushort horizontalStretch)
        {
            // ETANT DONNE le nombre <nombre>
            // ET un afficheur LCD taille horizontale <horizontalStretch>
            var afficheur = new AfficheurLCD(tailleHorizontale: horizontalStretch);

            // QUAND on le convertir en LCD taille <horizontalStretch>*1
            var lcd = afficheur.Convert(nombre);

            // ALORS on obtient un <nombre> où chaque barre horizontale est multipliée par <horizontalStretch>
            var aimedNumber = AfficheurLCD.ConvertWithDefaultSize(nombre);
            var expected = aimedNumber.DuplicateEachLineHorizontally(horizontalStretch);

            _testOutputHelper.WriteLine("expected");
            _testOutputHelper.WriteLine(expected);

            _testOutputHelper.WriteLine("result");
            _testOutputHelper.WriteLine(lcd);

            Assert.Equal(expected, lcd);
        }
    }
}
