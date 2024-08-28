using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace CCLoader.Installer.UI;

public partial class TextBox : BasicTextBox
{
    protected override Color4 SelectionColour => Colors.Background6;
    protected override Color4 InputErrorColour => Colors.Error;
    protected override float LeftRightPadding => SidePadding;

    public int SidePadding { get; init; } = 5;
    public float TextContainerHeight { get; init; } = 0.75f;

    public Action<TextBox, string> OnCommitAction { get; set; } = (_1, _2) => { };

    private Container textContainer => TextContainer;

    public Colour4 BackgroundInactive
    {
        get => BackgroundUnfocused;
        set => BackgroundUnfocused = value;
    }

    public Colour4 BackgroundActive
    {
        get => BackgroundFocused;
        set => BackgroundFocused = value;
    }

    public TextBox()
    {
        Colour = Colour4.White;
        CornerRadius = 5f;
        Masking = true;
        BackgroundInactive = Colors.Background3;
        BackgroundActive = Colors.Background4;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        BackgroundCommit = BorderColour = Colors.Highlight;
        Placeholder.Colour = Colors.Foreground;
        TextContainer.Height = TextContainerHeight;
    }

    protected override Caret CreateCaret()
    {
        return new CustomCaret(this)
        {
            SelectionColour = SelectionColour
        };
    }

    protected override void OnTextCommitted(bool textChanged)
    {
        OnCommitAction(this, this.Text);
    }

    public void NotifyError() => this.NotifyInputError();

    protected override Drawable GetDrawableCharacter(char c)
    {
        return new FallingDownContainer
        {
            Anchor = Anchor.CentreLeft,
            Origin = Anchor.CentreLeft,
            AutoSizeAxes = Axes.Both,
            Child = new SpriteText
            {
                Text = c.ToString(),
                Font = FontUsage.Default.With(size: FontSize),
            }
        };
    }

    public partial class CustomCaret : Caret
    {
        private TextBox box { get; }
        public Color4 SelectionColour { get; set; }

        public CustomCaret(TextBox box)
        {
            this.box = box;

            Size = new Vector2(4f, 0.8f);
            Anchor = Anchor.CentreLeft;
            Origin = Anchor.CentreLeft;
            CornerRadius = 2f;
            Masking = true;

            InternalChild = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Colour4.White
            };
        }

        protected override void LoadComplete()
        {
            RelativeSizeAxes = box.FontSize != box.TextContainer.DrawHeight ? Axes.None : Axes.Y;
            base.LoadComplete();
        }

        public override void Hide() => this.FadeOut(200);

        public override void DisplayAt(Vector2 position, float? selectionWidth)
        {
            if (selectionWidth.HasValue)
            {
                this.MoveTo(new Vector2(position.X, position.Y), 100, Easing.OutQuint);
                this.ResizeWidthTo(selectionWidth.Value, 100, Easing.OutQuint);
                this.FadeColour(SelectionColour, 200, Easing.OutQuint);
            }
            else
            {
                this.MoveTo(new Vector2(position.X, position.Y), 100, Easing.OutQuint);
                this.ResizeWidthTo(2f, 100.0, Easing.OutQuint);
                this.FadeColour(Color4.White, 200.0, Easing.OutQuint);
            }
        }
    }
}
