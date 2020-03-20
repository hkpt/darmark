using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    class CallCommand : ICommand
    {
        public string Name { get; set; } = "call";

        public void AddCommand(ICommand command)
        {
            throw new NotImplementedException();
        }

        public bool Execute()
        {
            if(GlobalScope.Functions.TryGetValue(this.Name, out ICommand function) &&
               function is FuncCommand funcCommand)
            {
                return funcCommand.ExecuteFunction();
            }
            return true;
        }

        public ICommand Initialise(string input)
        {
            if(input.Split(' ') is string[] callDefinition &&
               callDefinition.Length > 0)
            {
                CallCommand callCommand = new CallCommand();
                callCommand.Name = callDefinition[0].Trim();
                return callCommand;
            }
            return new NoOpCommand();
        }
    }
}
