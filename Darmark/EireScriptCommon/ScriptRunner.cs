using DarmarkCommon;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EireScript
{
    public class ScriptRunner : IPlugin
    {
        public string Name => "script";

        public string Help => "--input \"filename|filename2|...\" Input script filenames";

        private string[] inputFiles;

        public ScriptRunner()
        {
        }

        public bool Execute(object args)
        {
            return this.Execute();
        }

        public bool Execute()
        {
            Console.WriteLine("EireScript Intepreter");
            if(this.inputFiles == null)
            {
                ICommand scriptIn;
                do
                {
                    Console.Write(">");
                    scriptIn = ReadConsoleCommands();
                }while (scriptIn.Execute());
            }
            return true;
        }

        public void Execute(string line)
        {
            ICommand executableCommand = new CommandsRunner();

            foreach (ICommand command in this.EvalCommands(line))
            {
                executableCommand.AddCommand(command);
            }

            executableCommand.Execute();
        }

        private ICommand ReadConsoleCommands()
        {
            ICommand executableCommand = new CommandsRunner();

            foreach(ICommand command in this.EvalCommands(Console.ReadLine()))
            {
                executableCommand.AddCommand(command);
            }

            return executableCommand;
        }

        private IEnumerable<ICommand> EvalCommands(string inputString)
        {
            IEnumerable<string> tokens = inputString.Split(' ');
            int count = 0;
            foreach(string inputToken in tokens)
            {
                ++count;
                ICommand command = GlobalScope.ReservedCommands.SingleOrDefault(cmd => cmd.Name == inputToken);
                yield return command?.Initialise(string.Join(" ", tokens.Skip(count).ToArray())) ?? new NoOpCommand();
            }
        }

        public bool Initialise(string[] args)
        {
            IConfigurationRoot configs = new ConfigurationBuilder().AddCommandLine(args).Build();
            this.inputFiles = configs[Resources.InputCommandLineParameter]?.Split(Resources.InputCommandLineParameterDelimiter.ToArray())
                                                                               .Select(fn => fn.Trim())
                                                                               .ToArray();
            return true;
        }

        public bool Initialise(IPluginSettings pluginSettings)
        {
            return true;
        }

        public bool Initialise()
        {
            return true;
        }
    }
}
