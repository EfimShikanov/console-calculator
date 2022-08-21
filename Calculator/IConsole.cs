using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    public interface IConsole
    {
        void WriteLine(string input);
        void WriteLine(string input, params object[] args);
        void Write(string input);
        string ReadLine();
    }

    class DefaultConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void WriteLine(string input, params object[] args)
        {
            Console.WriteLine(input, args);
        }
    }
}
