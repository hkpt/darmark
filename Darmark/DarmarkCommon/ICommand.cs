using System;
using System.Collections.Generic;
using System.Text;

namespace DarmarkCommon
{
    public interface ICommand
    {
        string Name { get; }
        ICommand Initialise(string input);
        void AddCommand(ICommand command);
        bool Execute();
    }
}
