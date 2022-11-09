﻿namespace LCD
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
                default: throw new NotImplementedException();
            }
        }
    }
}
