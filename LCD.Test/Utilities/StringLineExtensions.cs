using System.Text;

namespace LCD.Test.Utilities
{
    internal static class StringLineExtensions
    {
        public static string DuplicateEachLineVertically(this string str, ushort times)
        {
            if (times < 2) throw new ArgumentOutOfRangeException(nameof(times), times, "Minimal value : 2");

            var builder = new StringBuilder();

            foreach (var line in str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var lineWithoutHorizontalBars = line.Replace('_', ' ');
                if(!string.IsNullOrWhiteSpace(lineWithoutHorizontalBars) )
                    for (var i = 0; i < times - 1; i++)
                        builder.AppendLine(lineWithoutHorizontalBars);

                builder.AppendLine(line);
            }

            return builder.ToString();
        }
    }
}
