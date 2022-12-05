using LCD.Test.Utilities;

namespace LCD.Test
{
    public class Taille2Test
    {
        private static readonly int[] NombresATester = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 10, 123456789 };
        private static readonly ushort[] EtirementsVerticauxATester = new ushort[] { 2, 3, ushort.MaxValue };

        public static readonly IEnumerable<object> CasTestVerticalStretch
            = new CartesianData(NombresATester, EtirementsVerticauxATester);

        [Theory]
        [MemberData(nameof(CasTestVerticalStretch))]
        public void TestVerticalStretch(int nombre, ushort verticalStretch)
        {
            // ETANT DONNE le nombre <nombre>
            // ET un afficheur LCD taille verticale <verticalStretch>
            var afficheur = new AfficheurLCD(tailleVerticale: verticalStretch);

            // QUAND on le convertir en LCD taille 1*<verticalStretch>
            var lcd = afficheur.Convert(nombre);

            // ALORS on obtient un <nombre> étiré <verticalStretch> fois en hauteur
            var aimedNumber = AfficheurLCD.ConvertWithDefaultSize(nombre);

            Assert.Equal(aimedNumber.DuplicateEachLineVertically(verticalStretch), lcd);
        }
    }
}
