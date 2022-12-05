using System.Text;

namespace LCD
{
    public class AfficheurLCD
    {
        private readonly ushort _tailleVerticale;
        private readonly ushort _tailleHorizontale;
        private static readonly AfficheurLCD Defaut = new();

        private AfficheurLCD() : this(1)
        {
        }

        public AfficheurLCD(ushort tailleVerticale = 1, ushort tailleHorizontale = 1)
        {
            _tailleVerticale = tailleVerticale;
            _tailleHorizontale = tailleHorizontale;
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
            return StretchHorizontal(StretchVertical(taille1));
        }

        private string StretchVertical(string block)
        {
            if (_tailleVerticale == 1) return block;

            var builder = new StringBuilder();

            foreach (var line in block.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var lineWithoutHorizontalElements = line.Replace('_', ' ');
                if(!string.IsNullOrWhiteSpace(lineWithoutHorizontalElements))
                    for (var i = 0; i < _tailleVerticale - 1; i++)
                        builder.AppendLine(lineWithoutHorizontalElements);

                builder.AppendLine(line);
            }
            
            return builder.ToString();
        }

        private static IEnumerable<string> CutInChunksOf(string full, ushort chunkSize)
        {
            var charArray = full.ToArray();

            while (charArray.Length != 0)
            {
                yield return new string(charArray.Take(4).ToArray());
                charArray = charArray.Skip(4).ToArray();
            }
        }

        private string StretchHorizontal(string block)
        {
            if (_tailleHorizontale == 1) return block;

            var builder = new StringBuilder();

            foreach (var line in block.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var chunk in CutInChunksOf(line, 4))
                {
                    var isPartOfTheLastNumber = chunk.Length == 3;
                    var substring = isPartOfTheLastNumber ? chunk : chunk[..3];

                    var lineWithoutVerticalBars = substring.Replace('|', ' ');

                    var hasAStartBar = substring.StartsWith('|');
                    var hasAnEndBar = substring.EndsWith('|');
                    var hasAnHorizontalBar = substring.Contains('_');

                    var fillingChar = hasAnHorizontalBar ? '_' : ' ';

                    builder.Append(hasAStartBar ? '|' : ' ');

                    for (var i = 0; i < _tailleHorizontale; i++)
                        builder.Append(fillingChar);

                    builder.Append(hasAnEndBar ? '|' : ' ');

                    if (!isPartOfTheLastNumber) builder.Append(' ');
                }

                builder.AppendLine();
            }

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
