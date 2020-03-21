using System;
using System.Collections.Generic;
using System.Text;

namespace DarmarkCommon
{
    public interface IInputReader
    {
        bool GetString(out string inputString);
    }
}
