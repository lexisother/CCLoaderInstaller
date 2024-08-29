// using CCLoader.Installer.UI;

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
// using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace CCLoader.Installer.Screens.Welcome;

public partial class WelcomeScreen : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        Anchor = Origin = Anchor.Centre;

        InternalChildren =
        [
            new FillFlowContainer
            {
                AutoSizeAxes = Axes.Both,
                Direction = FillDirection.Vertical,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Spacing = new Vector2(0f, 10f),
                Children =
                [
                ]
            }
        ];
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        this.ScaleTo(0.9f).FadeInFromZero(400.0).ScaleTo(1f, 800.0, Easing.OutQuint);
    }

    public override void OnSuspending(ScreenTransitionEvent e)
    {
        this.ScaleTo(1.1f, 800.0, Easing.OutQuint).FadeOut(400.0);
    }
}
