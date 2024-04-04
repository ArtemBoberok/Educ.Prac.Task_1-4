using System;

namespace BAA_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Шахматное поле\n\n A    B    C    D    E    F    G    H\n――――――――――――――――――――――――――――――――――――――――");
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (j == 9)
                    {
                        Console.Write("|" + i);
                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Console.Write($"{i}.{j}; ");
                        }
                        else
                        {
                            Console.Write($"{i}.{j}; ");
                        }
                    }
                }
                Console.WriteLine();
            }
            try
            {
                Console.Write("\nВведите координаты 1 поля (например a1): ");
                string p1 = Convert.ToString(Console.ReadLine());

                Console.Write("Введите координаты 2 поля (например c3): ");
                string p2 = Convert.ToString(Console.ReadLine());

                bool sameColor = CheckSameColor(p1, p2);
                Console.WriteLine(sameColor ? "\nПоля одного цвета!" : "\nПоля разного цвета!");
            }
            catch
            {
                Console.WriteLine("Введен неверный элемент, попробуйте заново!");
            }
        }
        static bool CheckSameColor(string pos1, string pos2)
        {
            int firstNum = pos1[1] - '0';
            char firstLetter = pos1[0];
            int secondNum = pos2[1] - '0';
            char secondLetter = pos2[0];

            return (firstNum + firstLetter) % 2 == (secondNum + secondLetter) % 2;
        }
    }
}
