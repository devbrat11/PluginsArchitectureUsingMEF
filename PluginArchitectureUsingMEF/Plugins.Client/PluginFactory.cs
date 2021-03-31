using System.Collections.Generic;
using System.IO;
using PluginArchDemo;
using Plugins.Contract;

namespace Plugins.Client
{
    /// <summary>
    /// Factory class to get plugins.
    /// </summary>
    public class PluginFactory
    {
        public IEnumerable<ITestPlugin> GetPlugins(PluginType pluginType=PluginType.Client)
        {
            if (pluginType==PluginType.External)
            {
                return GetExternalPlugins();
            }
            else
            {
                return GetClientPlugins();
            }
        }

        private IEnumerable<ITestPlugin> GetClientPlugins()
        {
            return new List<ITestPlugin>()
            {
                new ClientPlugin()
            };
        }

        private IEnumerable<ITestPlugin> GetExternalPlugins()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            // plugin directory path.
            var externalPluginDllDirectory = @"..\PluginArchitectureUsingMEF\Plugins.Extension\obj\Debug\netcoreapp2.1";
            var searchDirectories = new List<string>()
                {
                    currentDirectory,
                    externalPluginDllDirectory
                };

            PluginsComposer composer = new PluginsComposer();
            composer.Compose(searchDirectories);
            return composer.Plugins;
        }
    }
}
