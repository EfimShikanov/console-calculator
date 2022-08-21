using CalculatorLibrary;
using Xunit;

namespace CalculatorTests
{
    public class CalculatorLibraryTest
    {

        [Fact]
        public void ShouldDoAdditionTest()
        {
            Assert.Equal(3, Calculator.DoOperation(1, 2, "a"));
        }

        [Fact]
        public void ShouldDoSubstractionTest()
        {
            Assert.Equal(1, Calculator.DoOperation(2, 1, "s"));
        }

        [Fact]
        public void ShouldDoMultiplicationTest()
        {
            Assert.Equal(6, Calculator.DoOperation(2, 3, "m"));
        }

        [Fact]
        public void ShouldDoDivisionTest()
        {
            Assert.Equal(3, Calculator.DoOperation(6, 2, "d"));
        }

        [Fact]
        public void ShouldNotDoDivisionTest()
        {
            Assert.Equal(double.NaN, Calculator.DoOperation(2, 0, "d"));
        }

        [Fact]
        public void ShouldReturnInvalidOperationError()
        {
            Assert.Equal(double.NaN, Calculator.DoOperation(2, 2, "gg"));
        }
    }
}