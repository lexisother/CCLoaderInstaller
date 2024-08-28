using CCLoader.Installer.Screens.Welcome;
using CCLoader.Installer.UI;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;

namespace CCLoader.Installer;

public partial class InstallerUserInterface : Game
{
    private ScreenStack screenStack;

    [BackgroundDependencyLoader]
    private void load()
    {
        screenStack = new ScreenStack
        {
            RelativeSizeAxes = Axes.Both
        };

        Child = new SafeAreaContainer
        {
            RelativeSizeAxes = Axes.Both,
            Children =
            [
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colors.Background1
                },
                screenStack
            ]
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        screenStack.Push(new WelcomeScreen());
    }

    public override void SetHost(GameHost host)
    {
        base.SetHost(host);
        Window.Title = "CCLoader Installer";
        Window.MinSize = new System.Drawing.Size(1280, 720);
        Window.MaxSize = new System.Drawing.Size(1280, 720);
    }

    public override void RegisterForDependencyActivation(IDependencyActivatorRegistry registry)
    {
        if (registry.IsRegistered(typeof(InstallerUserInterface)))
            return;

        base.RegisterForDependencyActivation(registry);
        registry.Register(typeof(InstallerUserInterface), (InjectDependencyDelegate)((t, d) => ((InstallerUserInterface)t).load()), null);
    }
}
