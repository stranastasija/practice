// Практикум 24.11 игра "Угадай загаданное число"

Console.Clear();
Console.WriteLine("Привет! Давай сыграем в игру? Сейчас компьютер загадает число, а твоя задача будет угадать его. :) ");


int ComputerNumber ()
{
    Console.WriteLine("Давай обозначим диапазон для числа. Назови минимальное число: ");
    string minNumber = Console.ReadLine();
    int min = Convert.ToInt32(minNumber);
    Console.WriteLine("А теперь максимальное число: ");
    string maxNumber = Console.ReadLine();
    int max = Convert.ToInt32(maxNumber);
    int number = new Random().Next (min, max+1);
    return number;
}
//Console.WriteLine(ComputerNumber());

int Count ()
{
    Console.WriteLine("Игра началась и число загадано. Сколько попыток тебе понадобится, чтобы угадать его?");
    string num = Console.ReadLine();
    int count = Convert.ToInt32(num);
    return count;
}
//Console.WriteLine(Count());

int UserNumber()
{
    string player = String.Empty;
    bool number = true;
    
    do
    {
        Console.WriteLine("Как думаешь, какое число загадал компьютер? Введи его:");
        player = Console.ReadLine()!;
        number = (String.IsNullOrEmpty(player)) || !(Int32.TryParse(player, out int outnumber));
        break;
    }

    while (number);
    return Convert.ToInt32(player);
}
//Console.WriteLine(UserNumber());

//bool Game ()
//{
    
//    bool result = false;
        int player = UserNumber();
        int Computer = ComputerNumber();
        int count = Count();
    do
    {
        
        if (player == Computer)
        {
            Console.WriteLine("Поздравляю! Ты угадал число!");
        }
        else 
        {
            count--;

            if (player > Computer)
            {
                Console.WriteLine("Загаданное число меньше. Попробуй еще. Количество попыток: " + count);
            } 
            else
            {
                Console.WriteLine("Загаданное число больше. Попробуй еще. Количество попыток: " + count);
            }
        }
    }
    while (count > 0 && player != Computer);
    if (count == 0)
    {
        Console.WriteLine("К сожалению, тебе не удалось угадать загаданное число. Не расстраивайся, попробуй сыграть еще раз!");
    }
//    return true;
//}
//Console.WriteLine(Game());


//Проверка кода

int CreateNumber (int min, int max)   //написанный код
{
    return new Random().Next (min, max+1);
}

// 1 вариант

Console.WriteLine(CreateNumber(4,10));

// 2 вариант

int min = 4;
int max = 10;
int result = CreateNumber(min, max);
if (result>min && result<=max)
{
    Console.WriteLine("good");
}
else
{
    Console.WriteLine("error");
}
