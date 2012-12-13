using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using Lightning.Extensibility;

namespace Lightning
{
    public abstract class ApplicationDefinition
    {
        public Type ApplicationType { get; private set; }

        public ApplicationDefinition(Type applicationType)
        {
            ApplicationType = applicationType;
        }

        protected internal abstract ExtensionManager CreateExtensionManager();
    }
}
