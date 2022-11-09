using System.Text;

namespace LCD
{
    public class AfficheurLCD
    {
        public string Convert(int nombre)
        {
            switch (nombre)
            {
                case 0: return Digits.Zero;
                case 1: return Digits.One;
                case 2: return Digits.Two;
                case 3: return Digits.Three;
                case 4: return Digits.Four;
                case 5: return Digits.Five;
                case 6: return Digits.Six;
                case 7: return Digits.Seven;
                case 8: return Digits.Eight;
                case 9: return Digits.Nine;
                case > 9: return Combine(Convert(nombre / 10), Convert(nombre % 10));
                default: throw new NotImplementedException();
            }
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
