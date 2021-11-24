// Практикум 24.11 игра "Угадай загаданное число"


int ComputerNumber ()
{
    Console.WriteLine("Супер! Игра началась. Давай обозначим диапазон для числа. Назови минимальное число: ");
    string minNumber = Console.ReadLine();
    int min = Convert.ToInt32(minNumber);
    Console.WriteLine("А теперь максимальное число: ");
    string maxNumber = Console.ReadLine();
    int max = Convert.ToInt32(maxNumber);
    int number = new Random().Next (min, max+1);
    return number;
}


int Count ()
{
    Console.WriteLine("Число загадано. Сколько попыток тебе понадобится, чтобы угадать его? Введи это число: ");
    string num = Console.ReadLine();
    int count = Convert.ToInt32(num);
    return count;
}

int UserNumber()
{
    string player = String.Empty;
    bool number = true;
    
    do
    {
        Console.WriteLine("Игра началась. Введи число, которое загадал компьютер:");
        player = Console.ReadLine()!;
        number = (String.IsNullOrEmpty(player)) || !(Int32.TryParse(player, out int outnumber));
    }
    while (number);
    return Convert.ToInt32(player);
}

bool Game ()
{
    int player = UserNumber();
    int Computer = ComputerNumber();
    int count = Count();
    bool result = false;

    do
    {
        if (player == Computer)
        {
            Console.WriteLine("Поздравляю! Ты угадал число!");
            result = true;
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
    return true;
}




Console.Clear();
Console.WriteLine("Привет! Давай сыграем в игру? Сейчас компьютер загадает число, а твоя задача будет угадать его. :) ");
Console.WriteLine(ComputerNumber());
Console.WriteLine(Count());
Console.WriteLine(UserNumber());
Console.WriteLine(Game());
