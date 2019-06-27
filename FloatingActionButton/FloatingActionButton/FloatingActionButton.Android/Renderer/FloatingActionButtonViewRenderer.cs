
using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using FloatingActionButton.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidFloatingActionButton = Android.Support.Design.Widget.FloatingActionButton;
using FormsFloatingActionButton = FloatingActionButton.FloatingActionButton;

[assembly: ExportRenderer(typeof(FormsFloatingActionButton), typeof(FloatingActionButtonViewRenderer))]
namespace FloatingActionButton.Droid.Renderer
{
    class FloatingActionButtonViewRenderer : ViewRenderer<FormsFloatingActionButton, AndroidFloatingActionButton>
    {
        public FloatingActionButtonViewRenderer(Context context) :base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

            var fab = new AndroidFloatingActionButton(Context);
            fab.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());

            var elementImage = Element.ImageSource;

            if (elementImage != null)
                fab.SetImageDrawable(Context.GetDrawable(elementImage.ToString()));

            fab.Click += (sender, args) => {
                ((IButtonController)Element).SendClicked(); };
            SetNativeControl(fab);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Element.ButtonColor):
                    Control.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());
                    break;
                case nameof(Element.ImageSource):
                    if (Element.ImageSource != null) 
                        Control.SetImageDrawable(Context.GetDrawable(Element.ImageSource.ToString()));
                    break;
            }

            base.OnElementPropertyChanged(sender, e);
        }
    }
}