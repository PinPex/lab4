using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {

        protected int number;
        protected string roman_str;
        public RomanNumber(int n)
        {
            if (n < 1 || n > 3999)
                throw new RomanNumberException("Uncorrectly number");
            number = n;
            roman_str = "";
            int[] eqv = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] roman_symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 13; ++i)
            {
                while (number >= eqv[i])
                {
                    number -= eqv[i];
                    result.Append(roman_symbols[i]);
                }
            }
            roman_str = result.ToString();
            number = n;
        }

        public object Clone()
        {
            return new RomanNumber(number);
        }

        public int CompareTo(object? n)
        {
            if (n is RomanNumber num)
                return this.number.CompareTo(num.number);
            throw new RomanNumberException("Uncorrectly parameter");
        }
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null)
                throw new RomanNumberException("Adding these numbers is impossible");
            else
                return new RomanNumber(n1.number + n2.number);
        }
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null || n2.number - n1.number > 0)
                throw new RomanNumberException("Subtracting these numbers is impossible");
            else
                return new RomanNumber(n1.number - n2.number);
        }
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null)
                throw new RomanNumberException("Multiplying these numbers is impossible");
            else
                return new RomanNumber(n1.number * n2.number);
        }
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null || n2.number / n1.number > 1)
                throw new RomanNumberException("Dividing these numbers");
            else
                return new RomanNumber(n1.number / n2.number);
        }
        public override string ToString()
        {
            if (roman_str != "")
                return roman_str;
            else
                throw new RomanNumberException("Number has not found");
        }

    }
}
