using Android.Content.Res;
using Android.Graphics;
using System;

namespace RadioButton.Droid
{
    public static class TypeFaceExtensions
    {
        public static Typeface ToTypeFace(this string fontName, AssetManager assets)
        {
            try
            {
                return Typeface.CreateFromAsset(assets, fontName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Typeface.Default;
            }
        }
    }
}