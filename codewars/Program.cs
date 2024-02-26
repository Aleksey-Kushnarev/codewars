using System;
using System.Drawing;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {

        static int ReadIntNumber(int left, int right, string msg)
        {
            bool OK;
            int number;
            do
            {
                Console.WriteLine(msg);
                OK = Int32.TryParse(Console.ReadLine(), out number);
                if (number < left && number >= right)
                {
                    Console.WriteLine("Error");
                    OK = false;
                }
            } while (OK != true);
            return number;

        }



        static void FormMas(int size, out int[] arr)
        {
            arr = new int[size];
            int j = 0;
            for (int i = 0; i < size; i++)
            {
                j++;
                arr[i] = ReadIntNumber(-100, 100, "Введите " + j + " элемент массива");
            }
            Console.WriteLine();

        }



        static int[] Randomize(int[] arr, int size)
        {
            arr = new int[size]; //рандом
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(-100, 100);
                Console.Write(arr[i] + "  ");  //вывод
            }
            Console.WriteLine();
            return arr;
        }



        static void PrintMas(int[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Пустая последовательность");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + "  ");

        }



        static void PrintMenu()
        {
            Console.WriteLine(".............................................МЕНЮ.............................................");
            Console.WriteLine("1 - удаление элементов с нечетными индексами");
            Console.WriteLine("2 - добавление k элементов в начало");
            Console.WriteLine("3 - сдвинуть циклически на M элементов влево");
            Console.WriteLine("4 - поиск первого четного элемента");
            Console.WriteLine("5 - сортировка простым выбором");
            Console.WriteLine("6 - бинарный поиск");
            Console.WriteLine("7 - закончить");
            Console.WriteLine();
        }



        static int[] Delete(int size, int[] arr)          //удаление элементов с неетными индексами
        {
            int[] newArray = new int[arr.Length / 2];
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    newArray[j] = arr[i];
                    j++;
                }
            }

            return newArray;
        }



        static int[] AddNum(int[] arr, int k)        //добавление элемента в начало
        {
            int i = 0;
            int[] dopmas = new int[k + arr.Length];
            for (i = k; i < dopmas.Length; i++)
            {
                dopmas[i] = arr[i - k];
            }
            for (i = 0; i < k; i++)
            {
                dopmas[i] = ReadIntNumber(0, 100, $"Введите {i + 1}-ый элемент");
            }

            return dopmas;
        }



        static int[] ChangeElem(int[] array, int m)     //циклический сдвиг
        {

            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }


            for (int i = m, q = 0; i < array.Length; i++, q++)
            {
                newArray[q] = array[i];
            }

            for (int i = 0, q = array.Length - m; q < newArray.Length; i++, q++)
            {
                newArray[q] = array[i];
            }

            return newArray;
        }



        static void FindEven(int[] arr)
        {
            int i = 0;
            int comparisons = 0;
            do
            {
                comparisons++;
                if (Math.Abs(arr[i]) % 2 == 0)
                {
                    Console.WriteLine(arr[i] + ": Понадобилось " + comparisons + " сравнение(ия)");
                    return;
                }
                i++;
            } while (i < arr.Length);

            Console.WriteLine("Отсутствует");
        }



        static int[] Sort(int[] arr, ref int size)
        {
            for (int i = 0; i < size - 1; i++)  //сортировка
            {
                int min = arr[i];
                int min1 = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        min1 = j;
                    }
                }
                arr[min1] = arr[i];
                arr[i] = min;
            }
            return arr;
        }

        static void Binar(ref int[] arr, ref int size)
        {
            Console.WriteLine();
            int NumForFind = ReadIntNumber(-100, 100, "Введите число, которое необходимо найти:");
            int left = 0;
            int right = size - 1;
            int sred = 0;
            if (size == 0) Console.WriteLine("Такого элемента нет в массиве, так как это пустая последовательность");
            else
            {
                do
                {
                    sred = (left + right) / 2;
                    if (arr[sred] < NumForFind)
                        left = sred + 1;
                    else right = sred;
                } while (left != right);
                if (arr[left] == NumForFind)
                {
                    left++;
                    Console.WriteLine("Номер элемента - " + left);
                }
                else Console.WriteLine("Такого элемента нет в массиве");
            }
        }

        static void Main(string[] args)
        {
            int caseSwitch = 0, newcase = 0;
            int size = 0;
            bool OK = true;
            int[] arr = null;
            //int[] dopmas = null;

            Console.WriteLine("Если вы хотите ввести элементы массива самостоятельно, введите 1. Если нет - введите 2");

            do
            {
                OK = Int32.TryParse(Console.ReadLine(), out caseSwitch);
                if ((caseSwitch <= 0) | (caseSwitch >= 3))
                {
                    Console.WriteLine("Введите снова");
                    OK = false;
                }
            } while (OK != true);

            switch (caseSwitch)
            {
                case 1:
                    do
                    {
                        size = ReadIntNumber(0, 100, "Введите количество элементов массива");
                    } while (size < 0);

                    FormMas(size, out arr);
                    PrintMas(arr);
                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case 2:
                    do
                    {
                        size = ReadIntNumber(0, 100, "Введите количество элементов массива");
                    } while (size < 0);
                    arr = Randomize(arr, size);                                                             //рандом
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }


            do
            {
                PrintMenu();
                do
                {
                    OK = Int32.TryParse(Console.ReadLine(), out newcase);
                    if ((newcase <= 0) && (newcase > 7))
                    {
                        Console.WriteLine("Попробуй ввести снова");
                        OK = false;
                    }
                } while (OK != true);
                switch (newcase)
                {
                    case 1:
                        Console.WriteLine("Удаление элементов с нечетными индексами:");           //удаление неч индексов                    
                        arr = Delete(size, arr);
                        PrintMas(arr);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("Добавление K элементовв начало:");
                        int k = ReadIntNumber(0, 100, "Введите K");
                        arr = AddNum(arr, k);
                        PrintMas(arr);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("Перестановка элементов:"); // Сдвинуть циклически на M элементов влево
                        int m = ReadIntNumber(0, 100, "Введите M");
                        arr = ChangeElem(arr, m);
                        PrintMas(arr);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("Поиск первого четного элемента:");  //поиск нечетного
                        FindEven(arr);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("Сортировка простым выбором:");
                        arr = Sort(arr, ref size);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 6:
                        arr = Sort(arr, ref size);
                        Binar(ref arr, ref size);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    default:
                        if (newcase != 7)
                            Console.WriteLine("Error");
                        Console.WriteLine();
                        break;
                }
            } while (newcase != 7);
            Console.WriteLine("THE END");
        }
    }
}
