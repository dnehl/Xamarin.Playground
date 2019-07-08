using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ImageButton
{
    public class ImageButton : Image
    {
        public ImageButton()
        {
            Initialize();
        }

        public static BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ImageButton));

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ImageButton));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public event EventHandler ItemTapped = (e, a) => { };

        public void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command =  TapCommand
            });
        }

        private ICommand TapCommand => new Command(async () =>
        {
            AnchorX = 0.48;
            AnchorY = 0.48;
            await this.ScaleTo(0.8, 50, Easing.Linear);
            await Task.Delay(100);
            await this.ScaleTo(1, 50, Easing.Linear);

            ItemTapped(this, EventArgs.Empty);
        });
    }
}
