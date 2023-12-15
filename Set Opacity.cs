// Name: Set Opacity
// Submenu:
// Author:
// Title: Set Opacity
// Version:
// Desc: Set all pixels to the desired alpha value.
// Keywords:
// URL:
// Help:
#region UICode
IntSliderControl Amount1 = 255; // [0,255] Set all pixels to the desired alpha value.
#endregion

void Render(Surface dst, Surface src, Rectangle rect)
{
    ColorBgra currentPixel;
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        if (IsCancelRequested) return;
        for (int x = rect.Left; x < rect.Right; x++)
        {
            currentPixel = src[x,y];
            currentPixel.A = (byte) Amount1;
            dst[x,y] = currentPixel;
        }
    }
}
