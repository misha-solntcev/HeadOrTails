using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  5.19. Бросаются три монеты.Требуется задать случайную величину X, 
    равную числу выпавших "решеток"("решек"), построить ряд распределения 
    и функцию распределения величины X, если вероятность 
    выпадения "герба" равна 0,5. */

namespace HeadOrTails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Возможные элементарные события: 0 - орел, 1 - решка;            
            Console.WriteLine("Возможные элементарные события (0 - орел, 1 - решка): ");
            for (int i = 0; i <= 1; i++)            
                for (int j = 0; j <= 1; j++)                
                    for (int k = 0; k <= 1; k++)                                            
                        Console.Write($"{i}{j}{k}, ");                    
            Console.WriteLine();

            // Список количества выпавших решек;
            List<int> Amount = new List<int>();
            for (int i = 0; i <= 1; i++)            
                for (int j = 0; j <= 1; j++)
                {
                    int amount = 0;
                    for (int k = 0; k <= 1; k++)
                    {
                        amount = i + j + k;
                        Amount.Add(amount);
                    }
                }
            // Вывод в консоль:
            Console.WriteLine("Количество выпавших решек: ");
            foreach(int amount in Amount)
                Console.Write($"{amount},   ");
            Console.WriteLine();            
                        
            /* Возможные значения случайной величины X - 0,1,2,3;
            Подсчет количества каждого из событий: */
            List<int> X = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int x = 0;
                for (int j = 0; j < Amount.Count; j++)
                {
                    if (Amount[j] == i)                    
                        x += 1;                    
                }
                X.Add(x);
            }
            // Вывод в консоль:
            Console.WriteLine("Количество случайных событий X:");
            for(int i = 0; i < X.Count; i++)
                Console.WriteLine($"{i} - {X[i]}");
            Console.WriteLine($"Общее количество событий n = {Amount.Count}");

            // Вероятности событий:
            Console.WriteLine("Вероятности событий X: ");
            List<float> P = new List<float>();
            for (int i = 0; i < 4; i++)
            {
                float p = (float) X[i] / Amount.Count;
                P.Add(p);
                Console.WriteLine(P[i]);
            }

            double M = Mantissa(X, P);
            Console.WriteLine($"M[X] = {M}");

            double D = Dispersion(X, P, M);
            Console.WriteLine($"D[X] = {D}");

            Console.ReadKey();
        }

        // Функция расчета мантиссы M[X]:
        static double Mantissa(List<int> X, List<float> P)
        {
            double sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += X[i] * P[i];
            }
            return sum;
        }

        // Функция расчета дисперсии D[X]:
        static double Dispersion (List<int> X, List<float> P, double M)
        {
            double sum = 0;
            for (int i = 0; i < 4; i++)
            {
                sum += Math.Pow((X[i] - M), 2) * P[i];
            }
            return sum;
        }
    }
}
