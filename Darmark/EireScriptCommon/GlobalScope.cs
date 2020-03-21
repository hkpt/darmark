using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    static class GlobalScope
    {
        public static Dictionary<string, IVariable> Variables { get; } = new Dictionary<string, IVariable>();
        public static Dictionary<string, ICommand> Functions { get; } = new Dictionary<string, ICommand>();
        public static IInputReader InputReader { get; set; }

        public static ICollection<ICommand> ReservedCommands { get; } = new ICommand[]
                                                                        {
                                                                            new ExitCommand(),
                                                                            new PrintCommand(),
                                                                            new PrintLnCommand(),
                                                                            new FuncCommand(),
                                                                            new CallCommand(),
                                                                            new VarCommand()
                                                                        };
    }
}
