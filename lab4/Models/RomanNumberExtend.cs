using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public RomanNumberExtend(string num) : base(1)
        {
            roman_str = num;
            number = 0;
                Dictionary<char, ushort> digits = new Dictionary<char, ushort>()
            {
              {'M', 1000},
              {'D', 500},
              {'C', 100},
              {'L', 50},
              {'X', 10},
              {'V', 5},
              {'I', 1}
            };

            int a = digits['M'];

            int n = number;
            if (num.Length > 1)
            {
                for (int i = 0; i < num.Length - 1; i++)
                {
                    int cur = 0;
                    int next = 0;
                    foreach (var digit in digits)
                    {
                        if (digit.Key == num[i])
                        {
                            cur = digit.Value;
                        }
                        if (digit.Key == num[i + 1])
                        {
                            next = digit.Value;
                        }
                    }
                    if (cur < next)
                        n -= cur;
                    else
                        n += cur;

                    if (i == num.Length - 2)
                        n += next;
                }
            }
            else
            {
                n = digits[num[0]];
            }

            if (n < 1 || n > 3999)
                throw new RomanNumberException("Uncorrectly number");
            else
                number = n;
        }

        public int Num()
        {
            return number;
        }
    }
}
