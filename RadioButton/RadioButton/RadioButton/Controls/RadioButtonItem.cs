using System;
using Xamarin.Forms;

namespace RadioButton
{
    public class RadioButtonItem : View
    {
#pragma warning disable 108, 114
        public int Id { get; set; }
#pragma warning restore 108,114

        public static BindableProperty CheckedProperty =
            BindableProperty.Create(nameof(Checked), typeof(bool), typeof(RadioButtonItem), false);
        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);
            set
            {
                SetValue(CheckedProperty, value);
                var eventHandler = CheckedChanged;
                eventHandler?.Invoke(this, value);
            }
        }

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(RadioButtonItem), default(string));
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(RadioButtonItem), default(double));
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static BindableProperty FontNameProperty =
            BindableProperty.Create(nameof(FontName), typeof(string), typeof(RadioButtonItem), string.Empty);
        public string FontName
        {
            get => (string)GetValue(FontNameProperty);
            set => SetValue(FontNameProperty, value);
        }

        public static BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RadioButtonItem), Color.Aqua);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public EventHandler<bool> CheckedChanged;
    }
}
