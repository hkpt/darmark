using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    interface IVariable : ICommand
    {
        string Value { get; }
    }
}
