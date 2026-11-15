using System;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
namespace prg;
//Math.Round(Math.Pow(Math.Log(b, Math.Round(Math.E, 2)), 2) / (Math.Cos(alpha) - 1), 2)
class Program3
{
  static void OutputArray(int[] a)
  {
    foreach (int i in a)
      Console.Write("{0} ", i);
  }
  public static int[] ShellsSort(int[] array)
  {
    int n = array.Length;
    for (int gap = n / 2; gap > 0; gap /= 2)
    {
      for (int i = gap; i < n; i++)
      {
        int temp = array[i];
        int j;
        for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
        {
          array[j] = array[j - gap];
        }
        array[j] = temp;
      }
    }
    return array;
  }
  public static int[] SelectionSort(int[] array) //O(n^2)
  {
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
      int minIndex = i;
      for (int j = i + 1; j < n; j++)
      {
        if (array[j] < array[minIndex])
        {
          minIndex = j;
        }
      }
      int temp = array[minIndex];
      array[minIndex] = array[i];
      array[i] = temp;
    }
    return array;
  }
  public static void ExitOrContinue()
  {
    Console.Write("Подтвердите выход(д/н): ");
    char exitChar;
    while (!char.TryParse(Console.ReadLine(), out exitChar))
    {
      Console.Write("\n Введите валидное значение: ");
    }
    if (exitChar == 'д' || exitChar == 'Д')
    {
      Environment.Exit(0);
    }
    else
    {
      Console.WriteLine("Вы вернулись в главное меню.");
    }
  }
  public static void AuthorInfo()
  {
    Console.WriteLine("Автор: Wiz1X");
  }
  public static void SortArray()
  {
    Console.WriteLine("Введите длину массива: ");
    int length;
    while (!int.TryParse(Console.ReadLine(), out length))
    {
      Console.Write("\n Введите валидное значение: ");
    }
    int[] firstArray = new int[length];
    Random rnd = new();
    for (int i = 0; i < length; i++)
    {
      firstArray[i] = rnd.Next(1, 100);
    }
    int[] secondArray = (int[])firstArray.Clone();
    int[] Array = (int[])firstArray.Clone();
    Stopwatch stopwatch = Stopwatch.StartNew();
    ShellsSort(firstArray);
    stopwatch.Stop();
    double timeShells = stopwatch.Elapsed.TotalMilliseconds;
    stopwatch.Restart();
    SelectionSort(secondArray);
    stopwatch.Stop();
    double timeSelection = stopwatch.Elapsed.TotalMilliseconds;
    if (length > 10)
    {
      Console.WriteLine("Нельзя вывести массив из-за того, что он слишком большой");
    }
    else
    {
      Console.Write($"Исходный массив: ");
      OutputArray(Array);
      Console.Write($"\nОтсортированный массив: ");
      OutputArray(firstArray);
    }
    Console.WriteLine($"\nВремя выполнения сортировки Шелла: {timeShells} мс");
    Console.WriteLine($"Время выполнения сортировки выбором: {timeSelection} мс");
  }
  public static void AnswerGuess()
  {
    double beta, alpha, yourResult;
    Console.WriteLine("В данной программе записана математическая формула \n сокращённая до двух знаков после запятой. \n Ваша задача отгадать ответ, введя значения переменных.");
    Console.Write("\n Введите значение переменной альфа: ");
    while (!double.TryParse(Console.ReadLine(), out alpha))
    {
      Console.Write("\n Введите валидное значение: ");
    }
    Console.Write("\n Введите значение переменной бета: ");
    while (!double.TryParse(Console.ReadLine(), out beta))
    {
      Console.Write("\n Введите валидное значение: ");
    }
    double result = Math.Round(Math.Pow(Math.Log(beta, Math.Round(Math.E, 2)), 2) / (Math.Cos(alpha) - 1), 2);
    Console.WriteLine("\n У вас есть три попытки отгадать ответ.");
    byte attempts = 0;
    while (attempts < 3)
    {
      while (!double.TryParse(Console.ReadLine(), out yourResult))
      {
        Console.Write("\n Введите валидное значение: ");
      }
      if (yourResult == result)
      {
        Console.WriteLine("\n Вы угадали!");
        return;
      }
      attempts++;
    }
    Console.WriteLine("\n Вы не угадали. Правильный ответ: " + result);
  }
  static void Main(string[] args)
  {
    short choosen = 0;
    bool exitChoose = false;
    while (!exitChoose)
    {
      do
      {
        Console.WriteLine("\nВведите число от 1 до 4");
        Console.WriteLine("1. Отгадай ответ");
        Console.WriteLine("2. Об авторе");
        Console.WriteLine("3. Сортировка массива");
        Console.WriteLine("4. Выход");
        Console.Write("Ваш выбор: ");
      } while (!short.TryParse(Console.ReadLine(), out choosen) || choosen > 4 || choosen < 1);

      switch (choosen)
      {
        case 1:
          Program3.AnswerGuess();
          break;
        case 2:
          Program3.AuthorInfo();
          break;
        case 3:
          Program3.SortArray();
          break;
        case 4:
          Program3.ExitOrContinue();
          break;
      }
    }
  }
}
