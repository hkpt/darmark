using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    class PrintLnCommand : ICommand
    {
        public string Name => "println";

        public string Value { get; set; }
        public void AddCommand(ICommand command)
        {
        }

        public bool Execute()
        {
            string val = string.Empty;
            if (Value.Split(' ') is string[] splitInput &&
               splitInput.Length > 0)
            {
                if (Value.Contains("\""))
                {
                    val = splitInput[0].Replace("\"", "");
                }
                else
                {
                    val = GlobalScope.Variables[splitInput[0]].Value;
                }
            }
            Console.WriteLine(val);
            return true;
        }

        public ICommand Initialise(string input)
        {
            PrintLnCommand print = new PrintLnCommand();
            print.Value = input;
            return print;
        }
    }
}
