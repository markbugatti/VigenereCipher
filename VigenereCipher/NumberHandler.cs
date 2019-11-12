using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class NumberHandler
    {
        public static int [] NumberToArray(int number)
        {
            int[] array;
            int temp = number;
            List<int> list = new List<int>();

            while (temp > 0)
            {
                list.Add(temp % 10);
                temp /= 10;
            }

            array = list.ToArray();
            Array.Reverse(array);
            return array;
        }

        internal static int[] RemoveRepeatableInKey(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length-1; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if(array[j] == array[i])
                    {
                        array = array.Where((source, index) => index != j).ToArray();
                        length--;
                        // якщо символ видалений, то на його місце потрапить інший, він може бути такий самий, і його теж необхідно буде видалити
                        j--;
                    }
                }
            }
            return array;
        }

        internal static int ArrayToInt(int[] array)
        {
            string str = string.Join("", array);
            return Int32.Parse(str);
        }
    }
}
