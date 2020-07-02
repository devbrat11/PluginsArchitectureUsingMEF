using System;

namespace PluginArchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plugins using MEF...");
            new PluginsDemo().Run();
        }
    }
}
