using Plugins.Contract;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace PluginArchDemo
{
    internal class PluginsDemo
    {
        [ImportMany]
        public IEnumerable<IPlugin> Plugins { get; set; }

        public void Run()
        {
            Compose();
            foreach (var plugin in Plugins)
            {
                plugin.Plug();
            }
        }

        private void Compose()
        {
            var path = Directory.GetCurrentDirectory();
            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                        .ToList();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                Plugins = container.GetExports<IPlugin>();
            }
        }
    }
}
