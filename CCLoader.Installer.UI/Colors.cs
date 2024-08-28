using osu.Framework.Graphics;

namespace CCLoader.Installer.UI;

public static class Colors
{
    public static Colour4 Background1 => get(0.1f, 0.1f);
    public static Colour4 Foreground2 => get(0.7f, 0.7f);

    private static Colour4 get(float saturation, float lightness)
    {
        return Colour4.FromHSL(0.5833333f, saturation, lightness);
    }
}
