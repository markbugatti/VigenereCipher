using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class MatrixHandler
    {
        private string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        /// <summary>
        /// Довжина алфавіту
        /// </summary>
        private int matrixLength;
        private char[][] matrix;
        private int key;
        private int[] keyArray;

        public MatrixHandler(char[][] matrix, int key, int matrixLength)
        {
            this.matrix = matrix;
            this.key = key;
            this.matrixLength = matrixLength;
        }
        public void CreateMatrix()
        {

            // Створити додатковий рядок
            CreateExtraRow();
            // Перетворити ключ, в масив.
            CreateKeyArray();
            // Виконати перетановку в алфавіті по першому ключу
            InitialPermutation();
            // Створити додатковий стовбець
            CreateExtraColumn();
            // Необхідно склонувати алфавіт із matrix[1] на всі інші рядки [2 - matrixLength]
            // зсув на 1 вліво для кожного наступного рядка
            SubsequentPermutation();
            Check();
        }

        private void Check()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void SubsequentPermutation()
        {
            for (int i = 2; i < matrixLength; i++)
            {
                // Скопіювати попередній [i-1] рядок матриці у поточний i-й, та виконати циклычний зсув ліворуч
                Array.Copy(matrix[i-1], 1, matrix[i], 1, alphabet.Length);
                char first = matrix[i][1];
                // циклічний зсув для кожного рядка matrix[i]
                for (int j = 1; j < matrixLength - 1; j++)
                {
                    matrix[i][j] = matrix[i][j + 1];
                }
                matrix[i][matrixLength - 1] = first;
            }
        }


        public void CreateExtraRow()
        {
            for (int i = 1, j = 0; i < matrixLength; i++, j++)
            {
                matrix[0][i] = alphabet[j];
            }
        }

        public void CreateExtraColumn()
        {
            for (int i = 1, j = 0; i < matrixLength; i++, j++)
            {
                matrix[i][0] = alphabet[j];
            }
        }

        public void InitialPermutation()
        {
            // заповнти matrix[1 -- keyArray.Length] cимволами з алфавіту, які відповідають цифрам в ключі
            int i = 0;
            for (int j = 1; i < keyArray.Length; i++, j++)
            {
                // индекс буквы в соответсвии с ключем
                int k = keyArray[i];
                // Изза того, что индексы нумеруються с 0, то нужно отнять 1.
                matrix[1][j] = alphabet[k]; 
            }

            // заповнити matrix[1, ...] залишившимися в алфавіті літерами
            bool exist;
            // початок визначається довжиною масива ключа, оскільки по ключу були заповнені перші літери алфавіту
            // +1, оскікльки необхідно відступити від 0-го символа matrix[i], 0-й стовпцець - для додаткового алфавіту стовпця.
            i = keyArray.Length + 1;
            
            // Поки рядок matrix[1] не закінчиться
            while (i < matrixLength)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    // перевіряємо, чи є j-й символ із алфавіту в масиві matrix[1]
                    exist = Array.Exists(matrix[1], x => x == alphabet[j]);
                    // якщо немає, тоді додаємо j-й символ у масив matrix[1]
                    if (!exist)
                    {
                        // Заповнюэмо i-ту комірку символом, якого ще немає в в масиві matrix[1]
                        matrix[1][i] = alphabet[j];
                        // переходимо до наступної комарки масиву matrix[1] -- i+1
                        i++;
                    }
                }
            }
        }

        public void CreateKeyArray()
        {
            keyArray = NumberHandler.NumberToArray(key);
            // пользоватиель вводит числа, считая с 1, а программа, считает индексыс 0, нужно пользовательский вид преоброзовать в программный.
            for (int i = 0; i < keyArray.Length; i++)
            {
                keyArray[i] -= 1;
            }
        }
    }
}
