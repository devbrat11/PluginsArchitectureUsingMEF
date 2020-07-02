using Plugins.Contract;
using System;
using System.Composition;

namespace Plugin
{
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin
    { 
        public void Plug()
        {
            Console.WriteLine("Plugin is plugged.\nVersion : 1");
        }
    }
}
