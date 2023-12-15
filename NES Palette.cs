// Name: NES Palette
// Submenu:
// Author:
// Title: NES Palette
// Version:
// Desc: Convert an image to use the NES palette.
// Keywords:
// URL:
// Help:

void Render(Surface dst, Surface src, Rectangle rect)
{
    //Full NES Palette
    ColorBgra[] palette = new ColorBgra[] {
        ColorBgra.ParseHexString("7C7C7C"),
        ColorBgra.ParseHexString("0000FC"),
        ColorBgra.ParseHexString("0000BC"),
        ColorBgra.ParseHexString("4428BC"),
        ColorBgra.ParseHexString("940084"),
        ColorBgra.ParseHexString("A80020"),
        ColorBgra.ParseHexString("A81000"),
        ColorBgra.ParseHexString("881400"),
        ColorBgra.ParseHexString("503000"),
        ColorBgra.ParseHexString("007800"),
        ColorBgra.ParseHexString("006800"),
        ColorBgra.ParseHexString("005800"),
        ColorBgra.ParseHexString("004058"),
        ColorBgra.ParseHexString("BCBCBC"),
        ColorBgra.ParseHexString("0078F8"),
        ColorBgra.ParseHexString("0058F8"),
        ColorBgra.ParseHexString("6844FC"),
        ColorBgra.ParseHexString("D800CC"),
        ColorBgra.ParseHexString("E40058"),
        ColorBgra.ParseHexString("F83800"),
        ColorBgra.ParseHexString("E45C10"),
        ColorBgra.ParseHexString("AC7C00"),
        ColorBgra.ParseHexString("00B800"),
        ColorBgra.ParseHexString("00A800"),
        ColorBgra.ParseHexString("00A844"),
        ColorBgra.ParseHexString("008888"),
        ColorBgra.ParseHexString("F8F8F8"),
        ColorBgra.ParseHexString("3CBCFC"),
        ColorBgra.ParseHexString("6888FC"),
        ColorBgra.ParseHexString("9878F8"),
        ColorBgra.ParseHexString("F878F8"),
        ColorBgra.ParseHexString("F85898"),
        ColorBgra.ParseHexString("F87858"),
        ColorBgra.ParseHexString("FCA044"),
        ColorBgra.ParseHexString("F8B800"),
        ColorBgra.ParseHexString("B8F818"),
        ColorBgra.ParseHexString("58D854"),
        ColorBgra.ParseHexString("58F898"),
        ColorBgra.ParseHexString("00E8D8"),
        ColorBgra.ParseHexString("787878"),
        ColorBgra.ParseHexString("FCFCFC"),
        ColorBgra.ParseHexString("A4E4FC"),
        ColorBgra.ParseHexString("B8B8F8"),
        ColorBgra.ParseHexString("D8B8F8"),
        ColorBgra.ParseHexString("F8B8F8"),
        ColorBgra.ParseHexString("F8A4C0"),
        ColorBgra.ParseHexString("F0D0B0"),
        ColorBgra.ParseHexString("FCE0A8"),
        ColorBgra.ParseHexString("F8D878"),
        ColorBgra.ParseHexString("D8F878"),
        ColorBgra.ParseHexString("B8F8B8"),
        ColorBgra.ParseHexString("B8F8D8"),
        ColorBgra.ParseHexString("00FCFC"),
        ColorBgra.ParseHexString("F8D8F8"),
        ColorBgra.ParseHexString("000000")
    };



    ColorBgra currentPixel;
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        if (IsCancelRequested) return;
        for (int x = rect.Left; x < rect.Right; x++)
        {
            currentPixel = src[x,y];

            //Check for transparent, and skip
            if (currentPixel.A < 250)
            {
                currentPixel = ColorBgra.Transparent;
            }

            else
            {
                int distance = 200000;
                ColorBgra newPixel = currentPixel;
                foreach (ColorBgra col in palette)
                {
                    int newDistance = Power2(currentPixel.R-col.R) + Power2(currentPixel.G-col.G) + Power2(currentPixel.B-col.B);
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        newPixel = col;
                    }
                }
                currentPixel = newPixel;
                currentPixel.A = 255;
            }
            
            dst[x,y] = currentPixel;
        }
    }
}

private int Power2(int x)
{
    return x*x;
}
