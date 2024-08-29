using CCLoader.Installer.UI;
using osu.Framework.Allocation;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace CCLoader.Installer.Screens;

public abstract partial class BaseScreen : Screen
{
    private const float offset = 100;

    protected FillFlowContainer Content { get; private set; }

    protected const float CONTENT_FONT_SIZE = 16;

    protected const float CONTENT_PADDING = 30;

    protected const float HEADER_FONT_SIZE = 40f;

    [BackgroundDependencyLoader]
    private void load()
    {
        const float spacing = 20;

        InternalChildren =
        [
            new BasicScrollContainer
            {
                RelativeSizeAxes = Axes.Both,
                Masking = false,
                Child = new Container
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding { Horizontal = CONTENT_PADDING },
                    Children =
                    [
                        new SpriteText
                        {
                            Text = this.GetLocalisableDescription(),
                            Colour = Colors.Foreground2,
                            Font = FontUsage.Default.With(size: 40f),
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        },

                        Content = new FillFlowContainer
                        {
                            Y = HEADER_FONT_SIZE + spacing,
                            Spacing = new Vector2(spacing),
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Direction = FillDirection.Vertical
                        }
                    ]
                }
            }
        ];

        // InternalChildren =
        // [
        //     new Container
        //     {
        //         RelativeSizeAxes = Axes.X,
        //         AutoSizeAxes = Axes.Y,
        //         Padding = new MarginPadding { Horizontal = CONTENT_PADDING },
        //         Children =
        //         [
        //             new SpriteText
        //             {
        //                 Text = this.GetLocalisableDescription(),
        //                 Font = FontUsage.Default.With(size: HEADER_FONT_SIZE),
        //             },
        //             Content = new FillFlowContainer
        //             {
        //                 Y = HEADER_FONT_SIZE + spacing,
        //                 Spacing = new Vector2(spacing),
        //                 RelativeSizeAxes = Axes.X,
        //                 AutoSizeAxes = Axes.Y,
        //                 Direction = FillDirection.Vertical,
        //             }
        //         ],
        //     }
        // ];
    }

    public override void OnEntering(ScreenTransitionEvent e)
    {
        base.OnEntering(e);
        this
            .FadeInFromZero(100)
            .MoveToX(offset)
            .MoveToX(0, 500, Easing.OutQuint);
    }

    public override void OnResuming(ScreenTransitionEvent e)
    {
        base.OnResuming(e);
        this
            .FadeInFromZero(100)
            .MoveToX(0, 500, Easing.OutQuint);
    }

    public override bool OnExiting(ScreenExitEvent e)
    {
        this
            .FadeOut(100)
            .MoveToX(offset, 500, Easing.OutQuint);

        return base.OnExiting(e);
    }

    public override void OnSuspending(ScreenTransitionEvent e)
    {
        this
            .FadeOut(100)
            .MoveToX(-offset, 500, Easing.OutQuint);

        base.OnSuspending(e);
    }
}
