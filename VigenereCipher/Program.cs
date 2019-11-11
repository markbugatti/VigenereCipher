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
            string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            int length = alphabet.Length + 1;
            
            char[][] vigenereMatrix = new char[length][];
            for (int i = 0; i < length; i++)
            {
                vigenereMatrix[i] = new char[length];
            }

            MatrixHandler matrixHandler = new MatrixHandler(vigenereMatrix, 3452, length);
            matrixHandler.CreateMatrix();

            Console.ReadKey();
        }
    }
}
