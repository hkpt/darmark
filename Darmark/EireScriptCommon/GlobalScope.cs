using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    static class GlobalScope
    {
        public static Dictionary<string, IVariable> Variables { get; } = new Dictionary<string, IVariable>();
    }
}
