using Windows.UI.Xaml.Media;
using Xamarin.Forms;

namespace FloatingActionButton.UWP
{
    public static class ColorExtensions
    {
        public static SolidColorBrush ToUwpSolidColorBrush(this Color color)
        {
            return new SolidColorBrush(Windows.UI.Color.FromArgb(color.A.DoubleToByte(), color.R.DoubleToByte(), color.G.DoubleToByte(), color.B.DoubleToByte()));
        }
    }
}
