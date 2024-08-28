using osu.Framework;
using osu.Framework.Platform;

namespace CCLoader.Installer;

public class Program
{
    public static void Main(string[] args)
    {
        using (DesktopGameHost host = Host.GetSuitableDesktopHost("CCLoaderInstaller", new HostOptions()
               {
                   PortableInstallation = true
               }))
        using (Game installer = new InstallerUserInterface())
            host.Run(installer);
    }
}
