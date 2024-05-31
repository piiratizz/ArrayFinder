using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya.Model
{
    public static class StringExtensions
    {
        public static int[] ParseToIntArray(this string s, string str)
        {
            List<int> numbers = new List<int>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (char.IsNumber(c))
                {
                    sb.Append(c);
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        if (int.TryParse(sb.ToString(), out var res))
                        {
                            numbers.Add(res);
                        }
                        sb.Clear();
                    }
                }
            }

            if (sb.Length > 0)
            {
                if(int.TryParse(sb.ToString(), out var res))
                {
                    numbers.Add(res);
                }
            }
                

            return numbers.ToArray();
        }
    }
}
