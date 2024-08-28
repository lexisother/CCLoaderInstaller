using osu.Framework.Graphics;

namespace CCLoader.Installer.UI;

public static class Colors
{
    public static Colour4 Background1 => get(0.1f, 0.1f);
    public static Colour4 Background2 => Colors.get(0.1f, 0.15f);
    public static Colour4 Background3 => Colors.get(0.1f, 0.2f);
    public static Colour4 Background4 => Colors.get(0.1f, 0.25f);
    public static Colour4 Background5 => Colors.get(0.1f, 0.3f);
    public static Colour4 Background6 => Colors.get(0.1f, 0.35f);

    public static Colour4 Foreground => Colors.get(0.1f, 0.6f);
    public static Colour4 Foreground1 => Colors.get(0.7f, 0.6f);
    public static Colour4 Foreground2 => Colors.get(0.7f, 0.7f);
    public static Colour4 Foreground3 => Colors.get(0.7f, 0.8f);

    public static Colour4 Highlight => Colors.get(1f, 0.7f);
    public static Colour4 Error => Colour4.FromHSL(0.0f, 0.7f, 0.6f);

    private static Colour4 get(float saturation, float lightness)
    {
        return Colour4.FromHSL(0.5833333f, saturation, lightness);
    }
}
