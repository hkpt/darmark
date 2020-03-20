using System;
using System.Collections.Generic;
using System.Text;

namespace DarmarkCommon
{
    public interface IPluginSettings
    {
        Dictionary<object, object> Settings { get; }
    }
}
