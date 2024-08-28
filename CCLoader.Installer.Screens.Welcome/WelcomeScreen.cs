using CCLoader.Installer.UI;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
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
                    new SpriteText
                    {
                        Text = "Welcome to the CCLoader installer!",
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Font = FontUsage.Default.With(size: 40f),
                        Colour = Colors.Foreground2
                    },
                    new SpriteText
                    {
                        Text = "This installer will automatically download and install the latest version of CCLoader for you.",
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Padding = new MarginPadding
                        {
                            Bottom = 20f
                        },
                        Font = FontUsage.Default.With(size: 24f),
                        Colour = Colors.Foreground2
                    },

                    new FillFlowContainer
                    {
                        AutoSizeAxes = Axes.Both,
                        Direction = FillDirection.Horizontal,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Spacing = new Vector2(20f, 0f),
                        Children =
                        [
                            // Don't question the nesting; it errors if I put the TextBox & SpriteText next to eachother
                            new FillFlowContainer
                            {
                                AutoSizeAxes = Axes.Both,
                                Direction = FillDirection.Horizontal,
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Spacing = new Vector2(20f, 0f),
                                Children =
                                [
                                    new TextBox
                                    {
                                        Width = 800f,
                                        Height = 48f,
                                        SidePadding = 10,
                                        FontSize = 24f,
                                        Text = ""
                                    },
                                ]
                            },
                            // TODO: Button
                            new SpriteText
                            {
                                Text = "Install",
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Font = FontUsage.Default.With(size: 40f),
                                Colour = Colors.Foreground2
                            },
                        ]
                    }
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
