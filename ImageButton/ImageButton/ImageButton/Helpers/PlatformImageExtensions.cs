using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageButton
{
    public class PlatformImageExtensions : IMarkupExtension<string>
    {
        public string SourceImage { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            if (SourceImage == null)
                return null;

            string imagePath;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    imagePath = SourceImage;
                    break;

                case Device.iOS:
                    imagePath = SourceImage + ".png";
                    break;

                case Device.UWP:
                    imagePath = "Assets/" + SourceImage + ".png";
                    break;

                default:
                    throw new ArgumentException();
            }

            return imagePath;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
