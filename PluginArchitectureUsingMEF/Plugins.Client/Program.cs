using System;
using Plugins.Client;

namespace PluginArchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plugins using MEF...");
            var plugins = new PluginFactory().GetPlugins();

            foreach (var plugin in plugins)
            {
                plugin.ShowInfo();
            }
        }
    }

    public enum PluginType
    {
        Client,
        External
    }
}
