using System;
using Plugins.Contract;

namespace Plugins.Client
{
    /// <summary>
    /// Client Plugin.
    /// </summary>
    public class ClientPlugin : ITestPlugin
    {
        public void ShowInfo()
        {
            Console.WriteLine("Client Plugin. Version : 1");
        }
    }
}
