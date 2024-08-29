using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;

namespace CCLoader.Installer.Screens;

[LocalisableDescription(typeof(Strings), nameof(Strings.WelcomeHeader))]
public partial class WelcomeScreen : BaseScreen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        Content.Children =
        [
            new TextFlowContainer
            {
                Text = "This installer will automatically download and install the latest version of CCLoader for you.",
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
            }
        ];
    }
}
