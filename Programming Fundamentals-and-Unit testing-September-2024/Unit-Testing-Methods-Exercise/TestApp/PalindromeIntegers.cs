using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class PalindromeIntegers
    {
        public List<int> FindPalindromes(List<int> numbers)
        {
            List<int> palindromes = new List<int>();

            foreach (int num in numbers)
            {
                if (IsPalindrome(num))
                {
                    palindromes.Add(num);
                }
            }

            return palindromes;
        }

        private bool IsPalindrome(int num)
        {
            string original = num.ToString();
            string reversed = new string(original.Reverse().ToArray());
            return original == reversed;
        }
    }
}
