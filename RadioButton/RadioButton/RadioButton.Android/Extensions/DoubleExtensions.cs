using Android.Content;

namespace RadioButton.Droid
{
    public static class DoubleExtensions
    {
        public static float ToAndroidTextSize(this double value)
        {
            return (float) value;
        }
    }
}