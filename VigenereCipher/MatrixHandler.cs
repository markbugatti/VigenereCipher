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
            // Створити додатковий стовбець
            CreateExtraColumn();
            // Перетворити ключ, в масив.
            CreateKeyArray();
            // Виконати перетановку в алфавіті по першому ключу
            InitialPermutation();
            // Подальша перестановка матриці, передбачає циклічний 
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
                // циклічний зсув для кожного рядка matrix[i]
                char first = matrix[i][0];
                for (int j = 0; j < matrixLength - 1; j++)
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
            // заповнти matrix[1, ...] по ключу
            for (int i = 0, j = 1; i < keyArray.Length; i++, j++)
            {
                // индекс буквы в соответсвии с ключем
                int k = keyArray[i];
                // Изза того, что индексы нумеруються с 0, то нужно отнять 1.
                matrix[1][j] = alphabet[k]; 
            }

            //Predicate<int?> predicate = FindLatter;
            // заповнити matrix[1, ...] залишившимися в алфавіті літерами
            bool exist;
            for (int i = keyArray.Length + 1; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    // перевіряємо, чи є вже цей елемент в масиві

                    exist = existCharacter();
                    
                    exist = Array.Exists(matrix[1], x => x == alphabet[j]);


                    // якщо немає, тоді додаємо
                    if(!exist)
                    {
                        matrix[1][i] = alphabet[i]; 
                    }
                }
            }
        }

        //private bool FindLatter(int? obj)
        //{
        //    return obj;
        //}

        public void CreateKeyArray()
        {
            int tempKey = key;
            List<int> list = new List<int>();
            
            while(tempKey > 0)
            {
                list.Add(tempKey % 10);
                tempKey /= 10;
            }
            keyArray = list.ToArray();
            Array.Reverse(keyArray);

            // пользоватиель вводит числа, считая с 1, а программа, считает индексыс 0, нужно пользовательский вид преоброзовать в программный.
            for (int i = 0; i < keyArray.Length; i++)
            {
                keyArray[i] -= 1;
            }
        }
    }
}
