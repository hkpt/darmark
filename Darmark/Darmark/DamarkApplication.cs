using DarmarkCommon;
using EireScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darmark
{
    public class DamarkApplication
    {
        ICollection<IPlugin> plugins;
        public DamarkApplication()
        {
            plugins = new IPlugin[]
            {
                new ScriptRunner()
            };
        }

        public void Run(string[] args)
        {
            string pluginName = args[0];
            if (args.Length > 0 &&
                this.plugins.SingleOrDefault(p => p.Name == pluginName) is IPlugin plugin &&
                plugin.Initialise(args))
            {
                plugin.Execute();
            }
            else
            {
                this.OutputHelp();
            }
        }

        public void OutputHelp()
        {
            foreach(IPlugin plugin in this.plugins)
            {
                Console.WriteLine(plugin.Name);
                Console.WriteLine(plugin.Help);
            }
        }
    }
}
