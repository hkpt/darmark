using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    class FuncCommand : ICommand
    {
        public string Name { get; set; } = "func";

        private bool defined;

        public List<string> Commands { get; private set; }

        public FuncCommand()
        {
            this.Commands = new List<string>();
        }

        public void AddCommand(ICommand command)
        {
        }

        public bool Execute()
        {
            if (GlobalScope.Functions.TryGetValue(this.Name, out ICommand variable))
            {
                GlobalScope.Functions[this.Name] = this;
            }
            else
            {
                GlobalScope.Functions.Add(this.Name, this);
            }
            string line = string.Empty;
            while (true)
            {
                if(Console.ReadLine() is string input
                    && input != ":end")
                {
                    this.Commands.Add(input);
                }else
                {
                    this.defined = true;
                    break;
                }
            }
            return true;
        }

        public bool ExecuteFunction()
        {
            ScriptRunner scriptRunner = new ScriptRunner();
            scriptRunner.Initialise();
            foreach(string line in Commands)
            {
                scriptRunner.Execute(line);
            }
            return true;
        }

        public ICommand Initialise(string input)
        {
            if(input.Split(' ') is string[] functionDefinition &&
               functionDefinition.Length == 1)
            {
                FuncCommand function = new FuncCommand();
                function.Name = functionDefinition[0].Replace(":","");
                return function;
            }
            return new NoOpCommand();
        }
    }
}
