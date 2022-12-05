using System.Text;

namespace LCD
{
    public class AfficheurLCD
    {
        private readonly ushort _tailleVerticale;
        private static readonly AfficheurLCD Defaut = new();

        private AfficheurLCD() : this(1)
        {
        }

        public AfficheurLCD(ushort tailleVerticale)
        {
            _tailleVerticale = tailleVerticale;
        }

        public static string ConvertWithDefaultSize(int nombre)
            => nombre switch
               {
                   0   => Digits.Zero,
                   1   => Digits.One,
                   2   => Digits.Two,
                   3   => Digits.Three,
                   4   => Digits.Four,
                   5   => Digits.Five,
                   6   => Digits.Six,
                   7   => Digits.Seven,
                   8   => Digits.Eight,
                   9   => Digits.Nine,
                   > 9 => Combine(ConvertWithDefaultSize(nombre / 10), ConvertWithDefaultSize(nombre % 10)),
                   _   => throw new NotImplementedException()
               };

        public string Convert(int nombre)
        {
            var taille1 = ConvertWithDefaultSize(nombre);
            return StretchVertical(taille1);
        }

        private string StretchVertical(string block)
        {
            var builder = new StringBuilder();

            foreach (var line in block.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
                for (var i = 0; i < _tailleVerticale; i++)
                    builder.AppendLine(line);

            return builder.ToString();
        }

        private static string Combine(string blockA, string blockB)
        {
            using var linesA = blockA
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Cast<string>()
                .GetEnumerator();

            using var linesB = blockB
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Cast<string>()
                .GetEnumerator();

            var builder = new StringBuilder();
            while (linesA.MoveNext() && linesB.MoveNext())
            {
                builder.Append(linesA.Current);
                builder.Append(' ');
                builder.Append(linesB.Current);
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
