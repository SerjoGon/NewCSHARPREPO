using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCod
{
enum CommodityType
        {
            FrozenFood, Food, DomesticChemistry, BuildingMaterials, Petrol
        }
        enum TransportType
        {
            Semitrailer, Coupling, Refrigerator, OpenSidetruck, FuelTruck
        } 
        enum DistanceSun:ulong
        {
            sun = 0, Mercury = 57900000, Venus = 108200000, Earth = 149600000, Mars = 227900000, Jupiter = 7783000000,
            Saturn = 1427000000, Uranus = 2870000000, Neptune = 4496000000, Pluto = 5946000000
        }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Massive block 1
            //int[] myArr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //PrintArr("Массив myArr1", myArr1);
            //int[] tempArr = (int[])myArr1.Clone();
            //Array.Reverse(myArr1, 3, 4);
            //PrintArr("Массив myArr1 после реверсирования",myArr1);
            //myArr1 = tempArr;
            //PrintArr("Массив myArr1 после восстановления", myArr1);
            //int[] myArr2 = new int[20];
            //PrintArr("Массив myArr2 до копирования",myArr2);
            //myArr1.CopyTo(myArr2, 5);
            //PrintArr("Массив myArr2 после копирования", myArr2);
            //Array.Clear(myArr2, 0, myArr2.GetLength(0));
            //PrintArr("Массив myArr2 после очистки",myArr2);
            //Array.Resize(ref myArr2, 10);
            //PrintArr("Массив myArr2 после изменения размера",myArr2);
            //myArr2 = new[] {1,6,7,8,9,12,33,43,44,11};
            //PrintArr("Массив myArr2 несортированный",myArr2);
            //Array.Sort(myArr2);
            //PrintArr("Массив myArr2 сортированный",myArr2);
            //Console.WriteLine("Число 5 находится в массиве на " + Array.BinarySearch(myArr2, 6) + " позиции");
            //Console.WriteLine("Максимальный элемент в массиве myArr2: " + myArr2.Max());
            //Console.WriteLine("Минимальный элемент в массиве myArr2: " + myArr2.Min());
            //Console.WriteLine("Среднее арифметическое элементов myArr2: " + myArr2.Average());

            //int[,] myArr3 = { { 1, 2, 3 }, { 4, 5, 6 } };
            //Console.WriteLine("Количество измерений массива myArr3: " + myArr3.Rank);
            #endregion
            #region Massive block2
            /*
            int size = 5;
            int[][] arr = new int[size][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[i + 1];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = i + j + i;
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();

            }
            int[] myArr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in myArr1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            int[] mar1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int[,] mar2 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[][] mar3 = new int[3][] 
            {
                new int[3] {1, 2, 3 },
                new int[2] { 1, 2 },
                new int[4] { 1, 2,3,4 }
            };
            Console.WriteLine("Одномерный массив");
            foreach(int i in mar1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n Двумерный массив");
            foreach(int i in mar2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n Зубчатый массив");
            for(int i = 0; i < mar3.Length; i++)
            {
                foreach(int j in mar3[i])
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }*/

            #endregion

            #region Enum block3
            /*
            Console.WriteLine("Введите число от 1 до 5");
            int number = Int32.Parse(Console.ReadLine());
            if (number > 0 && number < 6)
            {
                CommodityType commodity = (CommodityType)Enum.GetValues(typeof(CommodityType)).GetValue(number - 1);
                TransportType transport = TransportType.Semitrailer;
                switch(commodity)
                {
                    case CommodityType.FrozenFood: transport = TransportType.Refrigerator; break;
                    case CommodityType.Food: transport = TransportType.Semitrailer; break;
                    case CommodityType.DomesticChemistry: transport = TransportType.Coupling; break;
                    case CommodityType.BuildingMaterials: transport = TransportType.OpenSidetruck;break;
                    case CommodityType.Petrol: transport = TransportType.FuelTruck;break;
                }
                Console.WriteLine($"Для товара - {commodity} необходим транспорт - {transport}. ");
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }*/
            #endregion
            #region Enum block2
            string moon = "Moon";
            if(!Enum.IsDefined(typeof(DistanceSun),moon))
            {
                Console.WriteLine($"\tЗначения {moon} нет в перечисдении DistanceSun. ");
            }
            #endregion

        }
        static void PrintArr(string text, int[] arr)
        {
            Console.Write(text + ": ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}