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

        public string Convert(int nombre)
        {
            return nombre == 1 ? One : Two;
        }
    }
}
