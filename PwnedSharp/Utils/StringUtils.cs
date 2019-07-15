using System;
using System.Collections.Generic;
using System.Linq;

namespace PwnedSharp.Utils
{
    public static class StringUtils
    {
        private const ushort FIRST_UPPER = 0x0041;
        private const ushort LAST_UPPER = 0x005A;

        private const ushort FIRST_LOWER = 0x0061;
        private const ushort LAST_LOWER = 0x007A;

        private const ushort FIRST_NUMBER = 0x0030;
        private const ushort LAST_NUMBER = 0x0039;

        public static int CountUpperCaseLetters(this string value)
        {
            return value.Count(c => c >= FIRST_UPPER && c <= LAST_UPPER);
        }

        public static int CountLowerCaseLetters(this string value)
        {
            return value.Count(c => c >= FIRST_LOWER && c <= LAST_LOWER);
        }

        public static int CountNumbers(this string value)
        {
            return value.Count(c => c >= FIRST_NUMBER && c <= LAST_NUMBER);
        }

        public static int CountSymbols(this string value)
        {
            return value.Count(c => (c < FIRST_NUMBER || c > LAST_NUMBER)
                                    && (c < FIRST_UPPER || c > LAST_UPPER)
                                    && (c < FIRST_LOWER || c > LAST_LOWER));
        }

        public static bool ContainsOnlyLetters(this string value)
        {
            return value.All(c => (c >= FIRST_UPPER && c <= LAST_UPPER)
                                  || (c >= FIRST_LOWER && c <= LAST_LOWER));
        }

        public static bool ContainsOnlyNumbers(this string value)
        {
            return value.CountNumbers() == value.Length;
        }

        public static Dictionary<char, int> CountCharacters(this string value)
        {
            var count = new Dictionary<char, int>();

            foreach (var c in value)
                count.Add(c, count.TryGetValue(c, out int total) ? total++ : 1);

            return count;
        }

        public static Dictionary<char, int> CountConsecutive(this string value, Func<char, bool> predicate = null)
        {
            if (predicate is null)
                predicate = (c) => true;

            var dic = new Dictionary<char, int>();

            int count = 0;
            char current = value[0];

            for (int i = 1; i < value.Length; i++)
            {
                if (current == value[i] && predicate(value[i]))
                    count++;
                else
                {
                    dic.Add(current, count);

                    count = 0;
                    current = value[i];
                }
            }

            return dic;
        }
    }
}
