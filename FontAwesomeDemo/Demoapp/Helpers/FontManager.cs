using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Collections;

namespace Demoapp.Helpers
{
    public class FontManager
    {
        public static string ROOT = "fonts/", FONTAWESOME = ROOT + "fontawesome-webfont.ttf";

        public static Hashtable fontCache = new Hashtable();

        public static Typeface GetTypeFace(Context context, string font)
        {
            Typeface tf = (Typeface)fontCache[font];

            if (tf == null)
            {
                try
                {
                    tf = Typeface.CreateFromAsset(context.Assets, font);
                }
                catch (System.Exception e)
                {

                    return null;
                }

                fontCache.Add(font, tf);
            }
            return tf;
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
                ((TextView)v).SetTypeface(typeface, TypefaceStyle.Bold);
            }
        }
    }
}