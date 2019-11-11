using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class MatrixHandler
    {
        private static string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        /// <summary>
        /// Довжина алфавіту
        /// </summary>
        private static int length;
        private static char?[,] matrix = null;
        private static int? key = null;
        private static int[] keyArrey;
        public static void CreateMatrix(char?[,] matrix, int key)
        {
            // Розмірність матриці = довжині алфавіта + 1, 
            // тому що додатковий рядок та стовпець для алфавіту
            length = alphabet.Length + 1;
            matrix = new char?[length, length];

            // ініціалізація матриці
            if(MatrixHandler.matrix == null)
            {
                MatrixHandler.matrix = matrix;
            }
            if(MatrixHandler.key == null)
            {
                MatrixHandler.key = key;
            }

            // Створити додатковий рядок
            CreateExtraRow();
            // Створити додатковий стовбець
            CreateExtraColumn();
            // Перетворити ключ, в масив.
            
            // Виконати перетановку в алфавіті по першому ключу
            
            // Виконати циклічний зсув для всіх інших рядків
        }

        public static void CreateExtraRow()
        {
            for (int i = 0; i < length; i++)
            {
                matrix[0, i] = alphabet[i];
            }
        }

        public static void CreateExtraColumn()
        {
            for (int i = 0; i < length; i++)
            {
                matrix[i, 0] = alphabet[i];
            }
        }

        public void InitialPermutation()
        {
            // заповнти matrix[1, ...] по ключу
            for (int i = 0; i < length; i++)
            {
                if()
            }

            // заповнити matrix[1, ...] залишившимися в алфавіті літерами
        }
    }
}
