using CalculatorProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.IO;
using Xunit;
using System.Text.RegularExpressions;

namespace CalculatorTests
{
    public class CalculatorProgramTest
    {
        [Fact]
        public void ShouldDoRunWithConsoleMock()
        {
            MockConsole mockConsole = new MockConsole();
            CalcProgram program = new CalcProgram();
            program.MyConsole = mockConsole;
            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
            mockConsole.Output.Enqueue("2");
            mockConsole.Output.Enqueue("3");
            mockConsole.Output.Enqueue("a");
            mockConsole.Output.Enqueue("n");
            program.RunCalculator();
            var expectedResult = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: 5" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";
            Assert.Equal(expectedResult, Regex.Replace(mockConsole.Inputs.ToString(), @"[\r\t\n]+", string.Empty));
        }

        [Fact]
        public void ShouldDoRunWithInvalidInputMessage()
        {
            MockConsole mockConsole = new MockConsole();
            CalcProgram program = new CalcProgram();
            program.MyConsole = mockConsole;
            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
            mockConsole.Output.Enqueue("d");
            mockConsole.Output.Enqueue("3");
            mockConsole.Output.Enqueue("d");
            mockConsole.Output.Enqueue("3");
            mockConsole.Output.Enqueue("m");
            mockConsole.Output.Enqueue("n");
            program.RunCalculator();
            var expectedResult = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "This is not valid input. Please enter an integer value: " +
                                 "Type another number, and then press Enter: " +
                                 "This is not valid input. Please enter an integer value: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: 9" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";
            Assert.Equal(expectedResult, Regex.Replace(mockConsole.Inputs.ToString(), @"[\r\t\n]+", string.Empty));
        }

        [Fact]
        public void ShouldReturnMathError()
        {
            MockConsole mockConsole = new MockConsole();
            CalcProgram program = new CalcProgram();
            program.MyConsole = mockConsole;
            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
            mockConsole.Output.Enqueue("2");
            mockConsole.Output.Enqueue("0");
            mockConsole.Output.Enqueue("d");
            mockConsole.Output.Enqueue("n");
            program.RunCalculator();
            var expectedResult = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "This operation will result in a mathematical error." +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";
            Assert.Equal(expectedResult, Regex.Replace(mockConsole.Inputs.ToString(), @"[\r\t\n]+", string.Empty));

        }
    }
}
