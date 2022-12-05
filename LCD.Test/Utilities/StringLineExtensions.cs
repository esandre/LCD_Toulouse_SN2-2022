using System.Text;

namespace LCD.Test.Utilities
{
    internal static class StringLineExtensions
    {
        public static string DuplicateEachLineVertically(this string block, ushort times)
        {
            if (times == 1) return block;

            var builder = new StringBuilder();

            foreach (var line in block.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var lineWithoutHorizontalBars = line.Replace('_', ' ');
                if(!string.IsNullOrWhiteSpace(lineWithoutHorizontalBars) )
                    for (var i = 0; i < times - 1; i++)
                        builder.AppendLine(lineWithoutHorizontalBars);

                builder.AppendLine(line);
            }

            return builder.ToString();
        }

        private static IEnumerable<string> CutInChunksOf(this string full, ushort chunkSize)
        {
            var charArray = full.ToArray();

            while(charArray.Length != 0)
            {
                yield return new string(charArray.Take(4).ToArray());
                charArray = charArray.Skip(4).ToArray();
            }
        }

        public static string DuplicateEachLineHorizontally(this string block, ushort times)
        {
            if (times == 1) return block;

            var builder = new StringBuilder();

            foreach (var line in block.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach(var chunk in line.CutInChunksOf(4))
                {
                    var isPartOfTheLastNumber = chunk.Length == 3;
                    var substring = isPartOfTheLastNumber ? chunk : chunk[..3];

                    var lineWithoutVerticalBars = substring.Replace('|', ' ');

                    var hasAStartBar = substring.StartsWith('|');
                    var hasAnEndBar = substring.EndsWith('|');
                    var hasAnHorizontalBar = substring.Contains('_');

                    var fillingChar = hasAnHorizontalBar ? '_' : ' ';

                    builder.Append(hasAStartBar ? '|' : ' ');

                    for (var i = 0; i < times; i++)
                        builder.Append(fillingChar);

                    builder.Append(hasAnEndBar ? '|' : ' ');

                    if(!isPartOfTheLastNumber) builder.Append(' ');
                }
                
                builder.AppendLine();
            }

            return builder.ToString();
            ;
        }
    }
}
