using System;
using System.Collections.Generic;
using System.Diagnostics;
using CCLoader.Installer.Screens;
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
    private int? currentStepIndex;

    private readonly List<Type> steps = new();

    private ScreenStack? screenStack;

    private Container screenContent = null!;
    private Container content = null!;

    [BackgroundDependencyLoader]
    private void load()
    {
        steps.Add(typeof(WelcomeScreen));
        steps.Add(typeof(SelectScreen));

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

                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding
                    {
                        Top = 100,
                        Bottom = 50
                    },
                    Children =
                    [
                        content = new Container
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            Padding = new MarginPadding { Bottom = 20 },
                            Child = new GridContainer
                            {
                                RelativeSizeAxes = Axes.Both,
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                ColumnDimensions =
                                [
                                    new Dimension(),
                                    new Dimension(minSize: 640, maxSize: 800),
                                    new Dimension()
                                ],
                                Content = new[]
                                {
                                    new[]
                                    {
                                        Empty(),
                                        new Container
                                        {
                                            RelativeSizeAxes = Axes.Both,
                                            Masking = true,
                                            CornerRadius = 14,
                                            Children =
                                            [
                                                new Box
                                                {
                                                    RelativeSizeAxes = Axes.Both,
                                                    Colour = Colors.Background6
                                                },
                                                new Container
                                                {
                                                    RelativeSizeAxes = Axes.Both,
                                                    Padding = new MarginPadding { Vertical = 20 },
                                                    Child = screenContent = new Container { RelativeSizeAxes = Axes.Both }
                                                }
                                            ]
                                        },
                                        Empty()
                                    }
                                }
                            },
                        }
                    ]
                }
            ]
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        if (currentStepIndex == null)
            showFirstStep();
    }

    private void showFirstStep()
    {
        Debug.Assert(currentStepIndex == null);

        screenContent.Child = screenStack = new ScreenStack
        {
            RelativeSizeAxes = Axes.Both
        };

        currentStepIndex = -1;
        showNextStep();
    }

    private void showNextStep()
    {
        Debug.Assert(currentStepIndex != null);
        Debug.Assert(screenStack != null);

        currentStepIndex++;

        var nextScreen = (Screen)Activator.CreateInstance(steps[currentStepIndex.Value])!;
        screenStack.Push(nextScreen);
    }

    public override void SetHost(GameHost host)
    {
        base.SetHost(host);
        Window.Title = "CCLoader Installer";
        Window.MinSize = new System.Drawing.Size(1280, 720);
        Window.MaxSize = new System.Drawing.Size(1280, 720);
    }
}
