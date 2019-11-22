using System;

namespace CalculatorLib
{
    public class Calculator
    {
        public double Sum(double x, double y)
        {
            if ((x == double.MaxValue && y > 0) || (x > 0 && y == double.MaxValue))
                throw new ArgumentOutOfRangeException("Sum are more then double.MaxValue");
            if ((x == double.MinValue && y < 0) || (x < 0 && y == double.MinValue))
                throw new ArgumentOutOfRangeException("Sum are less then double.MinValue");
            return x + y;
        }
        public double Subtraction(double x, double y)
        {
            if ((x == double.MinValue && y > 0) || (x < 0 && y == double.MaxValue))
                throw new ArgumentOutOfRangeException("Subtraction are less then double.MinValue");
            if ((x == double.MaxValue && y < 0) || (x > 0 && y == double.MinValue))
                throw new ArgumentOutOfRangeException("Subtraction are more then double.MaxValue");
            return x - y;
        }
        public double Multiplication(double x, double y)
        {
            return x * y;
        }
        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("Сannot be divided by zero");
            return x / y;
        }
        public double Square(double x)
        {
            return Math.Pow(x, 2);
        }
        public double Degree(double x, double y)
        {
            return Math.Pow(x, y);
        }
        public double TenDegree(double x)
        {
            return Math.Pow(10, x);
        }
        public double Sqrt(double x)
        {
            if (x < 0)
                throw new Exception("cannot take the square root of a negative number");
            return Math.Sqrt(x);
        }
        public double Logarithm(double x)
        {
            if (x <= 0)
                throw new Exception("cannot take the logarithm of a negative number or zero");
            return Math.Log10(x);
        }
        public double NaturalLogarithm(double x)
        {
            if (x <= 0)
                throw new Exception("cannot take the logarithm of a negative number or zero");
            return Math.Log(x);
        }
        public double Sin(double x)
        {
            double angle = Math.PI * x / 180.0;
            return Math.Sin(angle);
        }
        public double Cos(double x)
        {
            double angle = Math.PI * x / 180.0;
            return Math.Cos(angle);
        }
        public double Tan(double x)
        {
            if (((x - 90) % 180 == 0))
                throw new Exception("cannot take the tan from 90, 270...");

            double angle = Math.PI * x / 180.0;
            return Math.Tan(angle);
        }
        public int IntFactorial(int x)
        {
            int a = 1;
            if (x < 0)
                throw new Exception($"{x} must be > 0");
            for (int i = 1; i <= x; i++)
            {
                a *= i;
            }
            return a;
        }

        public double Factorial(double x)
        {
            if (Convert.ToInt32(x) == x)
            {
                return IntFactorial(Convert.ToInt32(x));
            }
            else
            {
                int a = (int)Math.Floor(x);
                double b = x - a;
                double logF = Math.Log10(IntFactorial(a)) + (b * Math.Log10(a + 1));
                double c = Math.Pow(10, logF);
                return c;
            }
        }
    }
}
