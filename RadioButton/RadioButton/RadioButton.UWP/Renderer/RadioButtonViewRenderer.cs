using RadioButton.UWP.Renderer;
using System.ComponentModel;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;
using FormsRadioButton = RadioButton.RadioButtonItem;
using UwpRadioButton = Windows.UI.Xaml.Controls.RadioButton;

[assembly: ExportRenderer(typeof(FormsRadioButton), typeof(RadioButtonViewRenderer))]
namespace RadioButton.UWP.Renderer
{
    public class RadioButtonViewRenderer : ViewRenderer<FormsRadioButton, UwpRadioButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<FormsRadioButton> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var radButton = new UwpRadioButton();
                radButton.Checked += OnRadButtonOnCheckedChange;
                SetNativeControl(radButton);
            }

            Control.Content = e.NewElement.Text;
            Control.IsChecked = e.NewElement.Checked;

            if (e.NewElement.FontSize > 0)
                Control.FontSize = (float)e.NewElement.FontSize;

            // ToDo:
            //if (string.IsNullOrEmpty(e.NewElement.FontName))
            //    Control.FontFamily = Element.FontName.ToTypeFace(Context.Assets);
        }

        private void OnRadButtonOnCheckedChange(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is UwpRadioButton curRadioButton) || !curRadioButton.IsChecked.HasValue)
                return;
            Element.Checked = curRadioButton.IsChecked.Value;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(Element.Checked):
                    Control.IsChecked = Element.Checked;
                    break;
                case nameof(Element.Text):
                    Control.Content = Element.Text;
                    break;
                case nameof(Element.TextColor):
                    //UpdateTextColor();
                    break;
                case nameof(Element.FontName):
                    //if (!string.IsNullOrEmpty(Element.FontName))
                       // Control.Typeface = Element.FontName.ToTypeFace(Context.Assets);
                    break;
                case nameof(Element.FontSize):
                    if (Element.FontSize > 0)
                        Control.FontSize = Element.FontSize;
                    break;
            }
        }
    }
}
