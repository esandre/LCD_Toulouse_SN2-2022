using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCD
{
    public static class Digits
    {
        public static readonly string One =
            "" + Environment.NewLine +
            "|" + Environment.NewLine +
            "|" + Environment.NewLine;

        public static readonly string Two =
            " _ " + Environment.NewLine +
            " _|" + Environment.NewLine +
            "|_ " + Environment.NewLine;

        public static readonly string Three =
            " _ " + Environment.NewLine +
            " _|" + Environment.NewLine +
            " _|" + Environment.NewLine;

        public static readonly string Four =
            "   " + Environment.NewLine +
            "|_|" + Environment.NewLine +
            "  |" + Environment.NewLine;

        public static readonly string Five =
            " _ " + Environment.NewLine +
            "|_ " + Environment.NewLine +
            " _|" + Environment.NewLine;

        public static readonly string Six =
            " _ " + Environment.NewLine +
            "|_ " + Environment.NewLine +
            "|_|" + Environment.NewLine;

        public static readonly string Seven =
            " _ " + Environment.NewLine +
            "  |" + Environment.NewLine +
            "  |" + Environment.NewLine;

        public static readonly string Eight =
            " _ " + Environment.NewLine +
            "|_|" + Environment.NewLine +
            "|_|" + Environment.NewLine;

        public static readonly string Nine =
            " _ " + Environment.NewLine +
            "|_|" + Environment.NewLine +
            " _|" + Environment.NewLine;
    }
}
