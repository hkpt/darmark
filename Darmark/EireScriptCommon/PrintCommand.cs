using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EireScript
{
    class PrintCommand : ICommand
    {
        public string Name => "print";

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
            if (input.Contains("\""))
            {
                this.valueToPrint = input.Replace("\"", "");
            }
            else
            {
                this.valueToPrint = GlobalScope.Variables[input].Value;
            }
            return this;
        }
    }
}
