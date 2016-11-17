using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxCore.Mathematics.Util
{
    class Hashing
    {
        public double HashAlgorithm(string input)
        {
            if (input != "")
            {
                string inputLower = input.ToLower();
                double hash = 0;
                char[] c = inputLower.ToCharArray();
                byte[] unicodebytes = Encoding.Unicode.GetBytes(c);
                List<int> num = new List<int>();
                for (int j = 0; j < unicodebytes.Length; j++)
                {
                    num.Add(unicodebytes[j] + (256 * unicodebytes[j + 1]));
                    j++;
                }
                double x = num.OrderBy(nums => nums).Reverse().ToList()[0];
                for (int i = 0; i < num.Count; i++)
                {
                    double l = (double)x / (double)unicodebytes.Length;
                    hash += (((double)num[i] * (1.0 / (i + 1))) + ((double)num[num.Count - (i + 1)] * (1.0 / (i + 1))) * (l * 0.0001));
                    x = (double)hash;
                }
                return hash;
            }
            return 0;
        }
    }
}
