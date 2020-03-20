using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            if(GlobalScope.Variables.TryGetValue(this.Name, out IVariable variable))
            {
                GlobalScope.Variables[this.Name] = this;
            }
            else
            {
                GlobalScope.Variables.Add(this.Name, this);
            }
            return true;
        }

        public ICommand Initialise(string input)
        {
            if (input.Contains("=") &&
               input.Split('=') is string[] assignment &&
               assignment.Length > 1 &&
               Regex.Matches(assignment[1], "\"([^\"]*)\"") is MatchCollection quoteMatch &&
               quoteMatch.Count > 0)
            {
                VarCommand varCommand = new VarCommand();
                varCommand.Name = assignment[0].Trim();
                varCommand.Value = quoteMatch[0].ToString().Replace("\"", "");
                return varCommand;
            }
            return new NoOpCommand();
        }
    }
}
