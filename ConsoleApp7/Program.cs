using Lib;

//////////////////////////////// Task 1 ////////////////////////////////

//Console.Write("Введите название гос-ва: "); string statee = Console.ReadLine();
//Console.Write("Введите столицу гос-ва: "); string capital = Console.ReadLine();
//Console.Write("Введите числ-ть населения: "); int populationSize = Convert.ToInt32(Console.ReadLine());
//Console.Write("Введите площадь гос-ва: "); int square = Convert.ToInt32(Console.ReadLine());
//Console.Clear();
//try
//{
//    State state1 = new State(statee, capital, populationSize, square); //с параметрами
//    state1.Print();
//    State.CheckPopulationSize(state1);
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");
//}

//Console.Write("\n\n");

//State state2 = new State(); //по умолчанию
//state2.Print();
//State.CheckPopulationSize(state2);

//Console.ReadKey();

//////////////////////////////// Task 2 ////////////////////////////////

//ListQueue listqueue = new ListQueue();

//listqueue.Add(new State("RUSSIA", "Moscow", 10000001, 12345));
//listqueue.Add(new State("USA", "ASD", 10000000, 1745));
//listqueue.Add(new State("GERMANI", "RGH", 100000, 45));
//listqueue.Add(new State("JAPAN", "EDF", 10000, 1235));
//listqueue.Add(new State("CHINA", "ABC", 1000, 145));
//Console.WriteLine("\n\tДо сортировки\n");
//listqueue.GetMassive();
//listqueue.Sort();
//Console.WriteLine("\n\tПосле сортировки\n");
//listqueue.GetMassive();

//Console.ReadKey();

//string? search;
//Console.Write("\n\n\tВведите название гос-ва для поиска:"); search = Console.ReadLine(); search = search?.ToUpper();
//listqueue.Search(search);

//Console.ReadKey();

//Console.WriteLine("\n\n\tПосле удаления первого элемента\n");
//listqueue.Remove();
//listqueue.GetMassive();

//Console.ReadKey();

//Console.WriteLine("\n\n\tУдалили еще 3 элемента\n");
//listqueue.Remove();
//listqueue.Remove();
//listqueue.Remove();
//listqueue.GetMassive();

//Console.ReadKey();

//////////////////////////////// Task 3 ////////////////////////////////

//ListQueue listqueue = new ListQueue();

//listqueue.Add(new State("RUSSIA", "Moscow", 10000001, 12345));
//listqueue.Add(new State("USA", "ASD", 10000000, 1745));
//listqueue.Add(new State("GERMANI", "RGH", 100000, 45));
//listqueue.Add(new State("JAPAN", "EDF", 10000, 1235));
//listqueue.Add(new State("CHINA", "ABC", 1000, 145));
//listqueue.Add(new State("BRITAN", "GHF", 100230, 14125));
//listqueue.Add(new State("INDIA", "DSF", 10400, 1454));

//listqueue.GetMassive();
//Console.WriteLine();

//listqueue.NullData(2);//.1 Занулили Германию

//listqueue.GetMassive();
//Console.WriteLine();

//Console.ReadKey();
//////////////////////////////////////////////////
//listqueue.Add(new State("KAZAHSTAN", "FGD", 104200, 14544));//.2 Добавили в null Казахстан
//listqueue.GetMassive();
//Console.WriteLine();

//Console.ReadKey();
//////////////////////////////////////////////////
//State[] mas = new State[5]//.3 Добавили в список массив новых стран
//{
//    new State("State1", "ABC", 228, 145),
//    new State("State2", "WTF", 339, 144),
//    new State("State3", "CHZNH", 440, 454),
//    new State("State4", "PShNh", 123, 13454),
//    new State("State5", "Heh", 1337, 14554)
//};

//listqueue.Add(mas);
//listqueue.GetMassive();
//Console.WriteLine();

//Console.ReadKey();
//////////////////////////////////////////////////
//listqueue.NullData(1);
//listqueue.GetMassive();
//Console.WriteLine();

//listqueue.Sort();//.4 Изменили сортировку, теперь null в конце

//listqueue.GetMassive();
//Console.WriteLine();
//Console.ReadKey();
//////////////////////////////////////////////////
//listqueue.CountReturn();

//////////////////////////////// Lab 9 ////////////////////////////////

Console.ForegroundColor = ConsoleColor.Cyan;

void PrintEvent(string message) => Console.WriteLine(message);
Action CountingEve()
{
    int count = 1;
    void Inner()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Номер операции - [{count}]");
        Console.ResetColor();
        count++;
    }
    return Inner;
}

ListQueue listqueue = new ListQueue();
ListQueue obj = new ListQueue();

listqueue.Notify += PrintEvent;
var fn = CountingEve();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\t\tПРИ ДОБАВЛЕНИИ ЭЛЕМЕНТОВ\n");    //добваляем
Console.ResetColor();

fn();   listqueue.Add(new State("RUSSIA", "Moscow", 10000001, 12345));
fn();   listqueue.Add(new State("USA", "ASD", 10000000, 1745));
fn();   listqueue.Add(new State("GERMANI", "RGH", 100000, 45));

Console.WriteLine("");

State[] mas = new State[5]
{
    new State("State1", "ABC", 228, 145),
    new State("State2", "WTF", 339, 144),
    new State("State3", "CHZNH", 440, 454),
    new State("State4", "PShNh", 123, 13454),
    new State("State5", "Heh", 1337, 14554)
};

fn();   listqueue.Add(mas);
Console.ReadLine();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n\t\tПРИ УДАЛЕНИИ ЭЛЕМЕНТОВ\n");    //удаляем
Console.ResetColor();

fn();   listqueue.Remove();
Console.ReadLine();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n\t\tПРИ ЗАНУЛЕНИИ ЭЛЕМЕНТОВ\n");    //зануляем
Console.ResetColor();

fn();   listqueue.NullData(2);
Console.ReadLine();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n\t\tПРИ СОРТИРОВКЕ ЭЛЕМЕНТОВ\n");    //сортируем
Console.ResetColor();

fn();   listqueue.Sort();
Console.ReadLine();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n\t\tПРИ ПОИСКЕ ЭЛЕМЕНТОВ\n");    //ищем
Console.ResetColor();

fn();   listqueue.Search("USA");
Console.ReadLine();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n\t\tПРИ ВЫВОДЕ ЭЛЕМЕНТОВ\n");    //выводим
Console.ResetColor();

fn();   listqueue.GetMassive();
Console.ReadLine();