namespace LCD
{
    public class AfficheurLCD
    {
        public string Convert(int nombre)
        {
            switch (nombre)
            {
                case 1: return Digits.One;
                case 2: return Digits.Two;
                case 3: return Digits.Three;
                case 4: return Digits.Four;
                case 5: return Digits.Five;
                case 6: return Digits.Six;
                default: throw new NotImplementedException();
            }
        }
    }
}
