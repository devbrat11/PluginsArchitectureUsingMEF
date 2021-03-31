using Plugins.Contract;
using System;
using System.Composition;

namespace Plugins.Extension
{
    /// <summary>
    /// Third party plugin.
    /// </summary>
    [Export(typeof(ITestPlugin))]
    public class PluginExtensionTypeOne : ITestPlugin
    { 
        public void ShowInfo()
        {
            Console.WriteLine("Extension : Type One Plugin. Version : 1");
        }
    }
}
