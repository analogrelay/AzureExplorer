using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lightning.Wpf
{
    public static class Launcher
    {
        public static void Run<TApp>(string[] args) where TApp : LightningApplication
        {
            // Create an Application Description
            ApplicationDefinition app = new ApplicationDefinition(
                GetSystemFolders(),
                GetExtensionFolders(),
                GetSystemAssemblies(typeof(TApp)),
                typeof(TApp));

#pragma warning disable 0618
            Bootloader.Boot(app);
#pragma warning restore 0618
        }

        private static IEnumerable<Assembly> GetSystemAssemblies(Type appType)
        {
            yield return typeof(Launcher).Assembly;
            yield return appType.Assembly;
        }

        private static IEnumerable<string> GetExtensionFolders()
        {
            yield return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions");
        }

        private static IEnumerable<string> GetSystemFolders()
        {
            yield return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "System");
        }
    }
}
