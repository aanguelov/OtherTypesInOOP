using System;

namespace _02_FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long deNominator;

        public Fraction(long numerator, long deNominator) : this()
        {
            this.Numerator = numerator;
            this.DeNominator = deNominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long DeNominator
        {
            get { return this.deNominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero.");
                }
                this.deNominator = value;
            }
        }

        public double ResultedFraction
        {
            get
            {
                double resultedFraction = (double)this.numerator/this.deNominator;
                return resultedFraction;
            } 
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            long greater = Math.Max(a.DeNominator, b.DeNominator);
            long smaller = Math.Min(a.DeNominator, b.DeNominator);
            if (greater == smaller)
            {
                long returnedNumerator = a.Numerator + b.Numerator;
                return new Fraction(returnedNumerator, greater);
            }
            else
            {
                if (greater % smaller == 0)
                {
                    long addition = greater/smaller;
                    long returnedNumerator;
                    if (a.DeNominator > b.DeNominator)
                    {
                        returnedNumerator = addition*b.Numerator + a.Numerator;
                    }
                    else
                    {
                        returnedNumerator = addition*a.Numerator + b.Numerator;
                    }
                    return new Fraction(returnedNumerator, greater);
                }
                else
                {
                    if (greater % 2 != 0 || smaller % 2 != 0)
                    {
                        long common = greater*smaller;
                        long returnedNumerator = a.Numerator*b.DeNominator + b.Numerator*a.DeNominator;
                        return new Fraction(returnedNumerator, common);
                    }
                    else
                    {
                        long common = greater*smaller/2;
                        long returnedNumerator = (common/a.DeNominator)*a.Numerator + (common/b.DeNominator)*b.Numerator;
                        return new Fraction(returnedNumerator, common);
                    }
                }
            }
        }

        public override string ToString()
        {
            return this.ResultedFraction.ToString();
        }
    }
}
