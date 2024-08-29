using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;

namespace CCLoader.Installer.Screens;

[LocalisableDescription(typeof(Strings), nameof(Strings.SelectHeader))]
public partial class SelectScreen : BaseScreen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        Content.Children =
        [
            new TextFlowContainer
            {
                Text = "Please select the CrossCode installation you want to install CCLoader and its components to.",
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
            }
        ];
    }
}
