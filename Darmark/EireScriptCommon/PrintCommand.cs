using DarmarkCommon;
using System;
using System.Collections.Generic;
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
            this.valueToPrint = input.Replace("\"", "");
            return this;
        }
    }
}
