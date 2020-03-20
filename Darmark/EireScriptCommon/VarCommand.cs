using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    public class VarCommand : IVariable
    {
        public string Name { get; set; } = "var";

        public string Value { get; set; }

        public void AddCommand(ICommand command)
        {
        }

        public bool Execute()
        {
            GlobalScope.Variables.Add(this.Name, this);
            return true;
        }

        public ICommand Initialise(string input)
        {
            if (input.Contains("=") &&
               input.Split('=') is string[] assignment &&
               assignment.Length == 2)
            {
                VarCommand varCommand = new VarCommand();
                varCommand.Name = assignment[0].Trim();
                varCommand.Value = assignment[1].Replace("\"", "").Trim();
                return varCommand;
            }
            return new NoOpCommand();
        }
    }
}
