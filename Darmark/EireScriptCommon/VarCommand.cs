using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    public class VarCommand : IVariable
    {
        public string Name { get; private set; } = "var";

        public string Value { get; private set; }

        public void AddCommand(ICommand command)
        {
        }

        public bool Execute()
        {
            return true;
        }

        public void Initialise(string input)
        {
            if(input.Contains("=") &&
               input.Split('=') is string[] assignment &&
               assignment.Length == 2)
            {
                this.Name = assignment[0];
                this.Value = assignment[1].Replace("\"", "");
            }
        }
    }
}
