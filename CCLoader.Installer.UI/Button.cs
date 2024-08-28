using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;

namespace CCLoader.Installer.UI;

public partial class Button : CompositeDrawable
{
    private CircularContainer content;
    private Box hover;
    private Box flash;

    public Colour4 BackgroundColor { get; set; } = get(0.1f, 0.1f);

    private static Colour4 get(float saturation, float lightness)
    {
        return Colour4.FromHSL(0.5833333f, saturation, lightness);
    }
}
