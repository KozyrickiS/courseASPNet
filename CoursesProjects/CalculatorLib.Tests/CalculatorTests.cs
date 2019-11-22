using NUnit.Framework;
using System;

namespace CalculatorLib.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(4, 5, ExpectedResult = 9)]
        [TestCase(-8, 10, ExpectedResult = 2)]
        [TestCase(3, -15, ExpectedResult = -12)]
        [TestCase(-6, -2, ExpectedResult = -8)]
        public double Test_Sum_Numbers(double x, double y)
        {
            Calculator calc = new Calculator();
            return calc.Sum(x, y);
        }

        [TestCase(double.MaxValue, double.MaxValue)]
        [TestCase(double.MaxValue, 3)]
        [TestCase(5, double.MaxValue)]
        [TestCase(double.MinValue, -10)]
        [TestCase(-6, double.MinValue)]
        [TestCase(double.MinValue, double.MinValue)]
        public void Test_Sum_Exception(double x, double y)
        {
            Calculator calc = new Calculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.Sum(x, y));
        }

        [TestCase(7, 3, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = -12)]
        [TestCase(1, -6, ExpectedResult = 7)]
        [TestCase(-4, -7, ExpectedResult = 3)]
        public double Test_Subtraction_Numbers(double x, double y)
        {
            Calculator calc = new Calculator();
            return calc.Subtraction(x, y);
        }

        [TestCase(double.MinValue, double.MaxValue)]
        [TestCase(double.MaxValue, -4)]
        [TestCase(-1, double.MaxValue)]
        [TestCase(double.MinValue, 2)]
        [TestCase(-6, double.MaxValue)]
        [TestCase(double.MaxValue, double.MinValue)]
        public void Test_Subtraction_Exception(double x, double y)
        {
            Calculator calc = new Calculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.Subtraction(x, y));
        }

        [TestCase(5, 8, ExpectedResult = 40)]
        [TestCase(-2, -6, ExpectedResult = 12)]
        [TestCase(-1, 4, ExpectedResult = -4)]
        [TestCase(3, -6, ExpectedResult = -18)]
        public double Test_Multiplication_Numbers(double x, double y)
        {
            Calculator calc = new Calculator();
            return calc.Multiplication(x, y);
        }

        [TestCase(8, 2, ExpectedResult = 4)]
        [TestCase(-10, -5, ExpectedResult = 2)]
        [TestCase(48, -5, ExpectedResult = -9.6)]
        [TestCase(-121, 5, ExpectedResult = -24.2)]
        public double Test_Divide_Numbers(double x, double y)
        {
            Calculator calc = new Calculator();
            return calc.Divide(x, y);
        }

        [Test]
        public void Test_Divide_By_Zero()
        {
            Calculator calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }

        [TestCase(4, ExpectedResult = 16)]
        [TestCase(-5, ExpectedResult = 25)]
        public double Test_Square_Numbers(int x)
        {
            Calculator calc = new Calculator();
            return calc.Square(x);
        }

        [TestCase(3, 5, ExpectedResult = 243)]
        [TestCase(-2, 8, ExpectedResult = 256)]
        [TestCase(5, -4, ExpectedResult = 0.0016)]
        [TestCase(-8, -2, ExpectedResult = 0.015625)]
        public double Test_Degree_Numbers(double x, double y)
        {
            Calculator calc = new Calculator();
            return calc.Degree(x, y);
        }

        [TestCase(3, ExpectedResult = 1000)]
        [TestCase(-2, ExpectedResult = 0.01)]
        [TestCase(0, ExpectedResult = 1)]
        public double Test_TenDegree_Numbers(double x)
        {
            Calculator calc = new Calculator();
            return calc.TenDegree(x);
        }

        [Test]
        public void Test_Sqrt_Positive_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Sqrt(17);
            Assert.AreEqual(4.1231, actual, delta);
        }

        [Test]
        public void Test_Sqrt_Negative_Numbers()
        {
            Calculator calc = new Calculator();
            Assert.Throws<Exception>(() => calc.Sqrt(-5));
        }

        [Test]
        public void Test_Logarithm_Positive_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Logarithm(15);
            Assert.AreEqual(1.176, actual, delta);
        }

        [TestCase(0)]
        [TestCase(-1000)]
        [TestCase(-1.156)]
        public void Test_Logarithm_Negative_Numbers(double x)
        {
            Calculator calc = new Calculator();
            Assert.Throws<Exception>(() => calc.Logarithm(x));
        }

        [Test]
        public void Test_NaturalLogarithm_Positive_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.NaturalLogarithm(10);
            Assert.AreEqual(2.3026, actual, delta);
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-2.34)]
        public void Test_NaturalLogarithm_Negative_Numbers(double x)
        {
            Calculator calc = new Calculator();
            Assert.Throws<Exception>(() => calc.Logarithm(x));
        }

        [Test]
        public void Test_Sin_Positive_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Sin(45);
            Assert.AreEqual(0.707, actual, delta);
        }

        [Test]
        public void Test_Sin_Negative_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Sin(-70);
            Assert.AreEqual(-0.939, actual, delta);
        }

        [Test]
        public void Test_Cos_Positive_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Cos(63);
            Assert.AreEqual(0.454, actual, delta);
        }

        [Test]
        public void Test_Cos_Negative_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Cos(-80);
            Assert.AreEqual(0.173, actual, delta);
        }

        [Test]
        public void Test_Tan_Positive_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Tan(245);
            Assert.AreEqual(2.144, actual, delta);
        }

        [Test]
        public void Test_Tan_Negative_Numbers()
        {
            const double delta = 0.05;
            Calculator calc = new Calculator();
            double actual = calc.Tan(-12);
            Assert.AreEqual(-0.212, actual, delta);
        }

        [TestCase(90)]
        [TestCase(-270)]
        public void Test_Tan_Exception(double x)
        {
            Calculator calc = new Calculator();
            Assert.Throws<Exception>(() => calc.Tan(x));
        }

        [TestCase(10, ExpectedResult = 3628800)]
        [TestCase(4, ExpectedResult = 24)]
        [TestCase(0, ExpectedResult = 1)]
        public int Test_Factorial_Int_Positive_Numbers(int x)
        {
            Calculator calc = new Calculator();
            return calc.IntFactorial(x);
        }

        [TestCase(-1)]
        [TestCase(-156)]
        public void Test_Factorial_Exception(int x)
        {
            Calculator calc = new Calculator();
            Assert.Throws<Exception>(() => calc.IntFactorial(x));
        }

        [Test]
        public void Test_Factorial_Double_Positive_Numbers()
        {
            const double delta = 0.3;
            Calculator calc = new Calculator();
            double actual = calc.Factorial(2.5);
            Assert.AreEqual(3.32, actual, delta);
        }

        [TestCase(-0.3)]
        [TestCase(-3.8)]
        public void Test_Factorial_Double_Exception(double x)
        {
            Calculator calc = new Calculator();
            Assert.Throws<Exception>(() => calc.Factorial(x));
        }
    }
}
