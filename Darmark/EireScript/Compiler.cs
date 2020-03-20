using System;
using System.Linq;

namespace EireScript
{
    public class Compiler
    {
        private string[] filenames;
        public Compiler(string[] filenames)
        {
            this.filenames = filenames;
        }

        public void Compile()
        {
            foreach(string filename in this.filenames)
            {
                Console.WriteLine($"Processing {filename}");
            }
        }
    }
}
