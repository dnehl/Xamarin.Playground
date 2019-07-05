using Android.Content;
using Android.Content.Res;
using Android.Widget;
using RadioButton.Droid;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidRadioButton = Android.Widget.RadioButton;
using FormsRadioButton = RadioButton.RadioButtonItem;

[assembly: ExportRenderer(typeof(FormsRadioButton), typeof(RadioButtonViewRenderer))]
namespace RadioButton.Droid
{
    public class RadioButtonViewRenderer : ViewRenderer<FormsRadioButton, AndroidRadioButton>
    {
        private ColorStateList _textColor;
        public RadioButtonViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FormsRadioButton> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var radButton = new AndroidRadioButton(Context);
                _textColor = radButton.TextColors;
                radButton.CheckedChange += OnRadButtonOnCheckedChange;
                SetNativeControl(radButton);
            }

            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            UpdateTextColor();

            if (e.NewElement.FontSize > 0)
                Control.TextSize = (float)e.NewElement.FontSize;

            if (string.IsNullOrEmpty(e.NewElement.FontName))
                Control.Typeface = Element.FontName.ToTypeFace(Context.Assets);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(Element.Checked):
                    Control.Checked = Element.Checked;
                    break;
                case nameof(Element.Text):
                    Control.Text = Element.Text;
                    break;
                case nameof(Element.TextColor):
                    UpdateTextColor();
                    break;
                case nameof(Element.FontName):
                    if (!string.IsNullOrEmpty(Element.FontName))
                        Control.Typeface = Element.FontName.ToTypeFace(Context.Assets);
                    break;
                case nameof(Element.FontSize):
                    if (Element.FontSize > 0)
                        Control.TextSize = Element.FontSize.ToAndroidTextSize();
                    break;
            }
        }

        private void UpdateTextColor()
        {
            // if (Control == null || Element == null)
            //     return;

            //if (Element.TextColor == Xamarin.Forms.Color.Default)
            //    Control.SetTextColor(_textColor);
            //else
            //    Control.SetText(Element.TextColor.ToAndroid());
        }

        private void OnRadButtonOnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
            => Element.Checked = e.IsChecked;
    }
}