﻿using System;

namespace _02_FractionCalculator
{
    class FractionCalculatorMain
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.DeNominator);
            Console.WriteLine(result);
        }
    }
}
