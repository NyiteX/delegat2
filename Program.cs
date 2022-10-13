
TextFix T = new();
T.Vvod();
if (T.Fix(x => Array.IndexOf(T.words, x) != -1))
    Console.WriteLine("Найдено.\n");
else
    Console.WriteLine("Ненайдено\n");

Console.WriteLine("Доступные цвета: желтый, красный, синий, голубой, фиолетовый, зеленый\n");
Operation Op = new Operation(RGB);

Op();

MyArrow A = new();
A.Print();
Console.Write("\nКратное 7: ");
A.Остаток(x => x % 7 == 0);
Console.WriteLine();

Console.WriteLine("Кол-во положительных: " + A.Остаток(x => x > 0));
Console.WriteLine();

Console.Write("Отрицательные уникальные в массиве: ");
A.Uniq(x => x < 0);

Console.WriteLine();
Рюкзак R = new(5);
Console.WriteLine();
Console.ReadLine();

void RGB()
{
    Console.Write("Выбор цвета: ");
    string? str = Console.ReadLine();
    string? str2 = str.ToLower();

    switch(str2)
    {
        case "красный":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
            break;
        case "желтый":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(str);
            Console.ResetColor();
            break;
        case "зеленый":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
            break;
        case "голубой":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(str);
            Console.ResetColor();
            break;
        case "синий":
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ResetColor();
            break;
        case "фиолетовый":
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(str);
            Console.ResetColor();
            break;
        default: Console.WriteLine("Такого цвета нет.");break;
    }
}

class Рюкзак
{
    string?[] Содержимое;
    double Объем;
    public Рюкзак(double объем)
    {
        Объем = объем;
        Содержимое = new string [Convert.ToInt32(объем)];
        Random r = new Random();
        if (r.Next(1, 2) == 2) Console.WriteLine("Рюкзак порвался и более не юзабелен.");
        else Console.WriteLine("Рюкзак уже и так заполнен, АЛО!");
    }
}
class MyArrow
{
    int[] mas;
    public MyArrow(int size = 10)
    {
        Random rand = new();
        mas = new int[size];
        for (int i = 0; i < mas.Length; i++)
            mas[i] = rand.Next(-25, 26);
    }
    public void Print()
    {
        Console.WriteLine("\nМассив: ");
        for (int i = 0; i < mas.Length; i++)
        {
            Console.Write(mas[i] + " ");
        }
        Console.WriteLine();
    }
    public int Остаток(Mas func)
    {
        int kol = 0;      
        for (int i = 0; i < mas.Length; i++)
            if (func(mas[i]))
            {
                Console.Write(mas[i] + " ");
                kol++;
            }
        Console.WriteLine();
        return kol;
    }
    public void Uniq(Mas func)
    {
        for (int i = 0; i < mas.Length; i++)
        {
            int kol = 0;
            if (func(mas[i]))
            {
                for (int u = 0; u < mas.Length; u++)
                    if (mas[i] == mas[u])
                        kol++;
                if (kol < 2)
                    Console.Write(mas[i] + " ");
            }
        }
        Console.WriteLine();
    }
}
class TextFix
{
    string? str;
    string? text;
    public string?[] words;
    public void Vvod()
    {
        Console.Write("Введите текст: ");
        text = Console.ReadLine();
        Console.Write("Введите слово для поиска: ");
        str = Console.ReadLine();
        words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        str = str.ToLower();
        text = text.ToLower();
    }
    public string? Str { get { return str; } }
    public string? Text { get { return text; } }
    public bool Fix(searchword func)
    {
        if (func(str))
            return true;
        else
            return false;
    }
}

delegate bool searchword(string str);
delegate bool Mas(int x);
delegate void Operation();