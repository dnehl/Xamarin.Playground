using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace RadioButton
{
    public class RadioButtonGroup : StackLayout
    {
        public RadioButtonGroup()
        {
            Items = new ObservableCollection<RadioButtonItem>();
        }

        public ObservableCollection<RadioButtonItem> Items { get; set; }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(RadioButtonGroup), default(IEnumerable), propertyChanged: OnItemsSourceChanged);
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(RadioButtonGroup), -1, BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);
        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public static BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RadioButtonGroup), Color.Aqua);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(RadioButtonGroup), default(double));
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static BindableProperty FontNameProperty =
            BindableProperty.Create(nameof(FontName), typeof(string), typeof(RadioButtonGroup), string.Empty);
        public string FontName
        {
            get => (string)GetValue(FontNameProperty);
            set => SetValue(FontNameProperty, value);
        }

        public event EventHandler<int> CheckedChanged;


        private void OnCheckedChanged(object sender, bool isChecked)
        {
            if (!isChecked)
                return;

            if (!(sender is RadioButtonItem radioButton))
                return;

            foreach (var item in Items)
            {
                if (!radioButton.Id.Equals(item.Id))
                    item.Checked = false;
                else
                {
                    SelectedIndex = radioButton.Id;
                    CheckedChanged?.Invoke(sender, item.Id);
                }
            }
        }

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(newvalue is int newValue))
                return;

            if (newValue == -1)
                return;

            if (!(bindable is RadioButtonGroup radioButtonGroup))
                return;

            foreach (var radioButtonItem in radioButtonGroup.Items.Where(b => b.Id == radioButtonGroup.SelectedIndex))
                radioButtonItem.Checked = true;
        }


        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is RadioButtonGroup radioButtons))
                return;

            foreach (var item in radioButtons.Items)
                // ReSharper disable once DelegateSubtraction
                item.CheckedChanged -= radioButtons.OnCheckedChanged;

            radioButtons.Children.Clear();
            var index = 0;

            foreach (var item in radioButtons.ItemsSource)
            {
                var button = new RadioButtonItem
                {
                    Text = item.ToString(),
                    Id = index++,
                    TextColor = radioButtons.TextColor,
                    FontSize = Device.GetNamedSize(NamedSize.Small, radioButtons),
                    FontName = radioButtons.FontName
                };

                button.CheckedChanged += radioButtons.OnCheckedChanged;
                radioButtons.Items.Add(button);
                radioButtons.Children.Add(button);
            }
        }
    }
}