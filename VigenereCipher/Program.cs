using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            int length = alphabet.Length + 1;
            
            char[][] vigenereMatrix = new char[length][];
            for (int i = 0; i < length; i++)
            {
                vigenereMatrix[i] = new char[length];
            }

            Console.Write("Введіть ключ k1 для перестановки алфавіту: ");
            int k1 = Int32.Parse(Console.ReadLine());
            int[] keyArray = NumberHandler.NumberToArray(k1);
            
            int keyLength = keyArray.Length; 
            keyArray = NumberHandler.RemoveRepeatableInKey(keyArray);
            if (keyArray.Length < keyLength)
            {
                k1 = NumberHandler.ArrayToInt(keyArray);
                Console.WriteLine("Виправлений ключ: {0}", k1);
            }

            MatrixHandler matrixHandler = new MatrixHandler(vigenereMatrix, k1, length);
            matrixHandler.CreateMatrix();



            Console.ReadKey();
        }
    }
}
