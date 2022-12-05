using LCD.Test.Utilities;
using Xunit.Abstractions;

namespace LCD.Test
{
    public class Taille2Test
    {
#if INTEGRATION
        private const ushort MaxReasonableValue = ushort.MaxValue;
#else
        private const ushort MaxReasonableValue = 10;
#endif

        private readonly ITestOutputHelper _testOutputHelper;
        private static readonly int[] NombresATester = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 1234567890 };
        private static readonly ushort[] EtirementsATester = new ushort[] { 1, 2, MaxReasonableValue };

        public static readonly IEnumerable<object> CasTestStretch
            = new CartesianData(NombresATester, EtirementsATester, EtirementsATester);

        public Taille2Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(CasTestStretch))]
        public void TestStretches(int nombre, ushort verticalStretch, ushort horizontalStretch)
        {
            // ETANT DONNE le nombre <nombre>
            // ET un afficheur LCD taille verticale <verticalStretch> et horizontale <horizontalStretch>
            var afficheur = new AfficheurLCD(tailleVerticale: verticalStretch, tailleHorizontale: horizontalStretch);

            // QUAND on le convertir en LCD
            var lcd = afficheur.Convert(nombre);

            // ALORS on obtient un <nombre> où chaque barre verticale est multipliée par <verticalStretch>
            // et chaque barre horizontale par <horizontalStretch>
            var aimedNumber = AfficheurLCD.ConvertWithDefaultSize(nombre);
            var expected = aimedNumber
                .DuplicateEachLineVertically(verticalStretch)
                .DuplicateEachLineHorizontally(horizontalStretch);

            _testOutputHelper.WriteLine("expected");
            _testOutputHelper.WriteLine(expected);

            _testOutputHelper.WriteLine("result");
            _testOutputHelper.WriteLine(lcd);

            Assert.Equal(expected, lcd);
        }
    }
}
