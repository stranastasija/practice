// Игра Black Jack
using System;
using System.Collections.Generic;

namespace Black_Jack
{
    public class Deck
    {
        protected List <string> deck = new List <string> {"2", "2", "2", "2", "3", "3", "3", 
        "4", "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6", "7", "7", "7", "7", 
        "8", "8", "8", "8", "9", "9", "9", "9", 
        "j", "j", "j", "j", "q", "q", "q", "q", "k", "k", "k", "k", "a", "a", "a", "a", }; 
        protected string GiveCard()
        {
            Random rnd = new Random ();
            int cardIndex = rnd.Next(0, deck.Count);
            string card = deck [cardIndex];
            deck.RemoveAt (cardIndex);
            return card;
        }
    }
    public class Player : Deck 
    {
        private List <string> playershand = new List <string> ();
        private int playershandprice;
        private int balance = 1000;
        private int playersbet;

        public void Bet (int bet)
        {
            balance -= bet;
            playersbet = bet;
        }
        public int GetPlayerBet ()
        {
            return playersbet;
        }
        public void GivePrize (int prize)
        {
            balance += prize;
        }
        public void Hand ()
        {
            playershand.Add (GiveCard());
            playershand.Add (GiveCard());
            for (int i = 0; i < 2; i++)
            {
                int cardprice;
                if (int.TryParse(playershand[i], out cardprice))
                {
                    playershandprice += cardprice;
                }
                else 
                {
                    if (playershand[i] != "a")
                    {
                        playershandprice += 10;
                    }
                    else 
                    {
                        if (playershandprice == 11)
                        {
                            playershandprice = 2;
                        }
                        else 
                        {
                            playershandprice += 11;
                        }
                    }
                }
            }
        }
        public void ShowPlaersHandPrice ()
        {
            Console.WriteLine (playershandprice);
        }
        public void AddCard ()
        {
            playershand.Add (GiveCard());
            int cardprice;
            if (int.TryParse(playershand[playershand.Count -1], out cardprice))
            {
                playershandprice += cardprice;
            }
            else
            {
                if (playershand[playershand.Count -1] != "a")
                {
                    playershandprice += 10;
                }
                else 
                {
                    playershandprice += 11;
                }
            }
        }
        public int GetPlayersHandPrice ()
        {
            return playershandprice;
        }
        public int GetPlayersBalance ()
        {
            return balance;
        }
    }
    public class Dealer : Deck 
    {
        private string [] dealersHand = {"", ""};
        private int dealersHandPrice;
        private int dealersFirstCard;
        public void Hand ()
        {
            dealersHand[0] = GiveCard();
            dealersHand[1] = GiveCard();

            for (int i = 0; i < 2; i++)
            {
                int cardprice;
                if (int.TryParse(dealersHand[i], out cardprice))
                {
                    dealersHandPrice += cardprice;
                }
                else
                {
                    if (dealersHand[i] != "a")
                    {
                        dealersHandPrice += 10;
                    }
                    else
                    {
                        if (dealersHandPrice == 11)
                        {
                            dealersHandPrice = 2;
                        }
                        else 
                        {
                            dealersHandPrice += 11;
                        }
                    }
                }
                if (i == 0)
                {
                    dealersFirstCard = cardprice;
                }
            }
        }
        public void ShowDealersFirstCard ()
        {
            Console.WriteLine(dealersFirstCard);
        }
        public void ShowDealersHandPrice()
        {
            Console.WriteLine(dealersHandPrice);
        }
        public int GetDealersHandPrice ()
        {
            return dealersHandPrice;
        }
    }
    class Programm
    {
        static void Main (string [] args)
        {
            string flag = "";
            while (flag != "end")
            {
                Console.WriteLine("Добро пожаловать в Black Jack");
                Console.WriteLine("Введите start, чтобы начать играть");
                flag = Console.ReadLine();
                if (flag == "start")
                {
                    Deck deck = new Deck ();
                    Player player = new Player ();
                    Dealer dealer = new Dealer ();
                    Console.Write ("Ваш баланс: ");
                    Console.WriteLine (player.GetPlayersBalance());
                    Console.Write ("Введите вашу ставку: ");
                    player.Bet (int.Parse(Console.ReadLine()));
                    player.Hand();
                    Console.Write ("Ваша рука: ");
                    player.ShowPlaersHandPrice ();
                    dealer.Hand ();
                    Console.Write ("1 карта дилера: ");
                    dealer.ShowDealersFirstCard();
                    string flag1 = "";
                    while (flag1 != "no")
                    {
                        Console.WriteLine ("Введите yes, если хотите добавить карту, и no, если не хотите");
                        flag1 = Console.ReadLine();
                        if (flag1 == "yes")
                        {
                            player.AddCard();
                            Console.WriteLine("Ваша рука: ");
                            player.ShowPlaersHandPrice();
                        }
                    }
                    if (player.GetPlayersHandPrice() > 21)
                    {
                        Console.Write ("Ваша рука: ");
                        player.ShowPlaersHandPrice();
                        Console.Write ("Рука дилера: ");
                        dealer.ShowDealersHandPrice();
                        Console.WriteLine ("Вы проиграли, ваша рука больше 21.");
                    }
                    else
                    if (player.GetPlayersHandPrice() < dealer.GetDealersHandPrice())
                    {
                        Console.Write ("Ваша рука: ");
                        player.ShowPlaersHandPrice();
                        Console.Write ("Рука дилера: ");
                        dealer.ShowDealersHandPrice();
                        Console.WriteLine ("Вы проиграли, ваша рука меньше руки дилера.");
                    }
                    else
                    if (player.GetPlayersHandPrice() > dealer.GetDealersHandPrice())
                    {
                        if (player.GetPlayersHandPrice() != 21)
                        {
                            player.GivePrize(player.GetPlayerBet() * 2);
                        }
                        else
                        {
                            player.GivePrize(player.GetPlayerBet() * 3);
                        }
                        Console.Write ("Ваша рука: ");
                        player.ShowPlaersHandPrice();
                        Console.Write ("Рука дилера: ");
                        dealer.ShowDealersHandPrice();
                        Console.WriteLine ("Вы выиграли!");
                        Console.Write ("Ваш баланс: ");
                        Console.WriteLine(player.GetPlayersBalance());
                    }
                    else 
                    {
                        player.GivePrize(player.GetPlayerBet());
                        Console.Write ("Ваша рука: ");
                        player.ShowPlaersHandPrice();
                        Console.Write ("Рука дилера: ");
                        dealer.ShowDealersHandPrice();
                        Console.WriteLine ("Ничья.");
                        Console.Write ("Ваш баланс: ");
                        Console.WriteLine(player.GetPlayersBalance());
                    }
                }
                else 
                {
                    flag = "end";
                }
            }
        }
    }
}