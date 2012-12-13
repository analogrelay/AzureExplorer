using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using Lightning.Extensibility;

namespace Lightning.Wpf.Extensibility
{
    public class MefExtensionManager : ExtensionManager
    {
        private IEnumerable<string> SystemFolders { get; private set; }
        private IEnumerable<string> ExtensionFolders { get; private set; }
        private Type ApplicationType { get; private set; }

        private CompositionContainer _extensionContainer;
        private CompositionContainer _systemContainer;

        public MefExtensionManager(IEnumerable<string> systemFolders, IEnumerable<string> extensionFolders, Type applicationType)
        {
            SystemFolders = systemFolders;
            ExtensionFolders = extensionFolders;
            ApplicationType = applicationType;

            Compose();
        }

        public override object GetSingleComponent(Type type)
        {
            throw new NotImplementedException();
        }

        private void Compose()
        {
            _extensionContainer = new CompositionContainer(
                new AggregateCatalog(
                    ExtensionFolders.Select(f => new DirectoryCatalog(f))));
            _systemContainer = new CompositionContainer(
                new AggregateCatalog(
                    new AssemblyCatalog(ApplicationType.Assembly),
                    new AssemblyCatalog(typeof(MefExtensionManager).Assembly),
                    new AssemblyCatalog(typeof(ExtensionManager).Assembly),
                    new AggregateCatalog(
                        SystemFolders.Select(f => new DirectoryCatalog(f)))),
                _extensionContainer);
        }
    }
}
