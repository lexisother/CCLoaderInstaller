using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;

namespace CCLoader.Installer.UI;

public partial class Button : CompositeDrawable
{
    private CircularContainer content;
    private Box hover;
    private Box flash;

    public Colour4 BackgroundColor { get; set; } = Colors.Background2;
    public Colour4 TextColor { get; set; } = Colors.Foreground3;

    public string Text { get; set; } = "";

    public Action Action { get; set; } = () => { };

    [BackgroundDependencyLoader]
    private void load()
    {
        Size = new Vector2(300f, 50f);

        InternalChild = content = new CircularContainer
        {
            RelativeSizeAxes = Axes.Both,
            Masking = true,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Children =
            [
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = BackgroundColor
                },
                hover = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0.0f
                },
                flash = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0.0f
                },
                new SpriteText
                {
                    Text = Text,
                    Colour = TextColor,
                    Font = FontUsage.Default.With(size: 24),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre
                }
            ]
        };
    }

    protected override bool OnClick(ClickEvent e)
    {
        flash.FadeOutFromOne(1000, Easing.OutQuint);
        Action();
        return true;
    }

    protected override bool OnHover(HoverEvent e)
    {
        hover.FadeTo(0.2f, 50.0);
        return true;
    }

    protected override void OnHoverLost(HoverLostEvent e) => hover.FadeTo(0.0f, 200.0);

    protected override bool OnMouseDown(MouseDownEvent e)
    {
        content.ScaleTo(0.9f, 1000.0, Easing.OutQuint);
        return true;
    }

    protected override void OnMouseUp(MouseUpEvent e)
    {
        content.ScaleTo(1f, 800.0, Easing.OutElasticHalf);
    }
}
