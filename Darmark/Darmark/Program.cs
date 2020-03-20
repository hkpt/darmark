using Darmark.Properties;
using EireScript;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Darmark
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configs = new ConfigurationBuilder().AddCommandLine(args).Build();
            string[] InputFiles = configs[Resources.InputCommandLineParameter]?.Split(Resources.InputCommandLineParameterDelimiter)
                                                                               .Select(fn => fn.Trim())
                                                                               .ToArray();
            Compiler compiler = new Compiler(InputFiles);
            compiler.Compile();
        }
    }
}
