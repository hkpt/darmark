using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    class PrintLnCommand : ICommand
    {
        public string Name => "println";

        private string valueToPrint = string.Empty;

        public void AddCommand(ICommand command)
        {
        }

        public bool Execute()
        {
            Console.WriteLine(this.valueToPrint);
            return true;
        }

        public ICommand Initialise(string input)
        {
            if (input.Split(' ') is string[] splitInput &&
               splitInput.Length > 0)
                if (input.Contains("\""))
                {
                    this.valueToPrint = input.Replace("\"", "");
                }
                else
                {
                    this.valueToPrint = GlobalScope.Variables[splitInput[0]].Value;
                }
            return this;
        }
    }
}
