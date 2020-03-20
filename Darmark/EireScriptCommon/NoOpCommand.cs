using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    public class NoOpCommand : ICommand
    {
        public string Name => Guid.NewGuid().ToString();

        public void AddCommand(ICommand command)
        {
        }

        public bool Execute()
        {
            return true;
        }

        public ICommand Initialise(string input)
        {
            return this;
        }
    }
}
