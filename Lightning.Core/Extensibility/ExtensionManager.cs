using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lightning.Extensibility
{
    public abstract class ExtensionManager
    {
        /// <summary>
        /// Gets a component from the container. Throws if more than one container is registered
        /// </summary>
        /// <typeparam name="T">The type of the component to get</typeparam>
        /// <returns>An instance of the component. Non-null if the method doesn't throw</returns>
        public virtual T GetSingleComponent<T>()
        {
            return (T)GetSingleComponent(typeof(T));
        }

        /// <summary>
        /// Gets a component from the container. Throws if more than one container is registered
        /// </summary>
        /// <param name="type">The type of the component to get</param>
        /// <returns>An instance of the component. Non-null if the method doesn't throw</returns>
        public abstract object GetSingleComponent(Type type);
    }
}
