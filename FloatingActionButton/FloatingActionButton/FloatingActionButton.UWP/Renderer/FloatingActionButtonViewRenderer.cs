using System.ComponentModel;
using Windows.UI.Xaml.Media;
using FloatingActionButton.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Color = Windows.UI.Color;

using FormsFloatingActionButton = FloatingActionButton.FloatingActionButton;

[assembly: ExportRenderer(typeof(FloatingActionButton.FloatingActionButton), typeof(FloatingActionButtonViewRenderer))]
namespace FloatingActionButton.UWP
{
    public class FloatingActionButtonViewRenderer : ButtonRenderer
    {

        public FloatingActionButtonViewRenderer()
        {
            
        }

        public static void OnInitialize()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            Element.WidthRequest = 50;
            Element.HeightRequest = 50;
            Element.CornerRadius = 25;
            Element.BorderWidth = 0;


            var col = ((FormsFloatingActionButton)Element).ButtonColor;
            Element.BackgroundColor = new Xamarin.Forms.Color(col.R.DoubleToByte(), col.G.DoubleToByte(), col.B.DoubleToByte(), col.A.DoubleToByte());

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
            if (e.PropertyName == "BackgroundColor")
                Control.BackgroundColor = ((FormsFloatingActionButton)Element).ButtonColor.ToUwpSolidColorBrush();
            
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
