
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FloatingActionButton
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingActionButton : Button
    {
        public FloatingActionButton()
        {
            InitializeComponent();
        }


        public static BindableProperty ButtonColorProperty =
            BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(FloatingActionButton), Color.Aqua);
        public Color ButtonColor
        {
            get => (Color) GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }
    }
}