using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace Demoapp.Helpers
{
    public class FontManager
    {
        public static string ROOT = "fonts/", FONTAWESOME = ROOT + "fa_regular_400.ttf";

        public static Typeface GetTypeFace(Context context, string font)
        {
            return Typeface.CreateFromAsset(context.Assets, font);
        }

        public static void MarkAsIconContainer(View v, Typeface typeface)
        {
            if (v is ViewGroup)
            {
                ViewGroup vg = (ViewGroup)v;
                for (int i = 0; i < vg.ChildCount; i++)
                {
                    View child = vg.GetChildAt(i);
                    MarkAsIconContainer(child, typeface);
                }
            }
            else if (v is TextView)
            {
                ((TextView)v).SetTypeface(typeface, TypefaceStyle.Normal);
            }
        }
    }
}