using System.Text;

namespace LCD.Test.Utilities
{
    internal static class StringLineExtensions
    {
        public static string DuplicateEachLineVertically(this string str, ushort times)
        {
            var builder = new StringBuilder();

            foreach (var line in str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
                for (var i = 0; i < times; i++)
                    builder.AppendLine(line);

            return builder.ToString();
        }
    }
}
