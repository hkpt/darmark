using System;

namespace DarmarkCommon
{
    public interface IPlugin
    {
        string Name { get; }

        string Help { get; }
        bool Initialise(string[] args);
        bool Initialise(IPluginSettings pluginSettings);
        bool Execute();
    }
}
