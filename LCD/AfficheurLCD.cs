namespace LCD
{
    public class AfficheurLCD
    {
        private static readonly string One =
            "" + Environment.NewLine +
            "|" + Environment.NewLine +
            "|" + Environment.NewLine;

        private static readonly string Two =
            " _ " + Environment.NewLine +
            " _|" + Environment.NewLine +
            "|_ " + Environment.NewLine;

        private static readonly string Three =
            " _ " + Environment.NewLine +
            " _|" + Environment.NewLine +
            " _|" + Environment.NewLine;

        private static readonly string Four =
            "   " + Environment.NewLine +
            "|_|" + Environment.NewLine +
            "  |" + Environment.NewLine;

        public string Convert(int nombre)
        {
            switch (nombre)
            {
                case 1: return One;
                case 2: return Two;
                case 3: return Three;
                case 4: return Four;
                default: throw new NotImplementedException();
            }
        }
    }
}
