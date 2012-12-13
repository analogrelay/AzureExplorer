using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lightning.Extensibility;

namespace Lightning
{
    public static class Bootloader
    {
        [Obsolete("Apps should not call Bootloader.Boot, instead they should use the Launcher class provided by their platform-specific Lightning library")]
        public static void Boot(ApplicationDefinition appDef)
        {
            // Create an extension manager
            ExtensionManager extensions = appDef.CreateExtensionManager();

            // Use it to load the application
            LightningApplication app = extensions.GetSingleComponent<LightningApplication>();
        }
    }
}
