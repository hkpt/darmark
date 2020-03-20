using DarmarkCommon;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EireScript
{
    public class ScriptRunner : IPlugin
    {
        ICollection<ICommand> reservedCommands;
        public string Name => "script";

        public string Help => "--input \"filename|filename2|...\" Input script filenames";

        private string[] inputFiles;

        public ScriptRunner()
        {
            this.reservedCommands = new ICommand[]
            {
                new ExitCommand(),
                new PrintCommand()
            };
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
            foreach(string inputToken in tokens)
            {
                ICommand command = this.reservedCommands.SingleOrDefault(cmd => cmd.Name == inputToken);                ;
                command?.Initialise(string.Join(" ", tokens.Skip(1).ToArray()));
                yield return  command ?? new NoOpCommand();
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
            return false;
        }
    }
}
