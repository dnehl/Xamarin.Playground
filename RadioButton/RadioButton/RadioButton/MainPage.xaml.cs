using System.ComponentModel;
using Xamarin.Forms;

namespace RadioButton
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();

            RadioButtonGroup.ItemsSource = new[]
            {
               "Austria",
               "Germany", 
               "France", 
               "Italy"
            };
        }
    }
}
