using System.Text;

namespace LCD
{
    public static class AfficheurLCD
    {
        public static string Convert(int nombre) =>
            nombre switch
            {
                0 => Digits.Zero,
                1 => Digits.One,
                2 => Digits.Two,
                3 => Digits.Three,
                4 => Digits.Four,
                5 => Digits.Five,
                6 => Digits.Six,
                7 => Digits.Seven,
                8 => Digits.Eight,
                9 => Digits.Nine,
                > 9 => Combine(Convert(nombre / 10), Convert(nombre % 10)),
                _ => throw new NotImplementedException()
            };

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
