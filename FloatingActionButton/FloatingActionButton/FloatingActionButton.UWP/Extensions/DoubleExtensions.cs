using System;

namespace FloatingActionButton.UWP
{
    public static class DoubleExtensions
    {
        public static byte DoubleToByte(this double d)
        {
            return Convert.ToByte(d);
        }
    }
}