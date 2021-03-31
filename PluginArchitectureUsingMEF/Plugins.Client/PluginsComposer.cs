using Plugins.Contract;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace PluginArchDemo
{
    /// <summary>
    /// Plugins Composition using MEF.
    /// </summary>
    internal class PluginsComposer
    {
        [ImportMany]
        public IEnumerable<ITestPlugin> Plugins { get; set; }

        /// <summary>
        /// Method to get plugins from the search directories. By default search directory is the current directory.
        /// </summary>
        public void Compose(List<string> searchDirectories=null)
        {
            if (searchDirectories == null || searchDirectories.Count == 0)
            {
                searchDirectories = new List<string>()
                {
                    Directory.GetCurrentDirectory()
                };
            }

            List<Assembly> searchAssemblies = new List<Assembly>();
            foreach(var directory in searchDirectories)
            {
                var assemblies = Directory
                       .GetFiles(directory, "*.dll", SearchOption.AllDirectories)
                       .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                       .ToList();
                searchAssemblies.AddRange(assemblies);
            }
           
            ContainerConfiguration configuration = new ContainerConfiguration()
                .WithAssemblies(searchAssemblies);

            using (var container = configuration.CreateContainer())
            {
                Plugins = container.GetExports<ITestPlugin>();
            }
        }
    }
}
