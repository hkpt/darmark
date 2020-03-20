using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    public class CommandsRunner : ICommand
    {
        public string Name => Guid.NewGuid().ToString();

        ICollection<ICommand> nestedCommands;
        public CommandsRunner()
        {
            this.nestedCommands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            this.nestedCommands.Add(command);
        }

        public bool Execute()
        {
            bool returnFlag = true;
            foreach(ICommand command in this.nestedCommands)
            {
                returnFlag &= command.Execute();
            }
            return returnFlag;
        }

        public void Initialise(string input)
        {
        }
    }
}
