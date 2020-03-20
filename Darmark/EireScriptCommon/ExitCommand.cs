using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    internal class ExitCommand : ICommand
    {
        public string Name => "exit";
        public void AddCommand(ICommand command)
        {
            // Don't Accept Any Nested Commands!!
        }

        public bool Execute()
        {
            // Just end - return a false.
            return false;
        }

        public ICommand Initialise(string input)
        {
            return this;
        }
    }
}
