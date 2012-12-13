using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lightning.Wpf
{
    public class WpfApplicationDefinition : ApplicationDefinition
    {
        public IEnumerable<string> SystemFolders { get; private set; }
        public IEnumerable<string> ExtensionFolders { get; private set; }
        
        public WpfApplicationDefinition(IEnumerable<string> systemFolders, IEnumerable<string> extensionFolders, Type type) : base(type)
        {
            SystemFolders = systemFolders;
            ExtensionFolders = extensionFolders;
        }
    }
}
