using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    class FileLineInputReader : IInputReader
    {
        private string[] lines;
        int count = 0;
        public FileLineInputReader(string[] lines)
        {
            this.lines = lines;
        }

        public bool GetString(out string inputString)
        {
            inputString = string.Empty;
            if(lines.Length > count)
            {
                inputString = lines[count++];
                return true;
            }
            return false;
        }
    }
}
