using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Threading.Channels;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            string lastWinner = "Ingen har vunnit ännu";

            bool shutdowm = false;
            while (shutdowm != true)
            {
                Console.WriteLine("Välkommen till Blackjack!");
                Console.WriteLine();
                Console.WriteLine("Välj något utav alternativen nedan genom att skriva dess nummer.");
                Console.WriteLine("1. Spela Blackjack");
                Console.WriteLine("2. Spelregler");
                Console.WriteLine("3. Senaste vinnaren");
                Console.WriteLine("4. Avsluta programmet.");

                string menuChoice = Console.ReadLine();
                Console.Clear();

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("Nu dras 2 kort per spelare.");
                        Console.WriteLine();
                        Random cardsDraw = new Random();
                        int playerPoints = 0;
                        int computerPoints = 0;
                        int points = 0;

                        for (int i = 0; i < 2; i++)
                        {
                            points = cardsDraw.Next(1, 11);
                            playerPoints = playerPoints + points;
                            Console.WriteLine($"Ditt {i + 1}a kort: {points}");
                            points = 0;

                        }
                        Console.WriteLine($"Dina poäng: {playerPoints}");
                        Console.WriteLine();

                        for (int i = 0; i < 2; i++)
                        {
                            points = cardsDraw.Next(1, 11);
                            computerPoints = computerPoints + points;
                            Console.WriteLine($"Datorns {i + 1}a kort: {points}");
                            points = 0;

                        }
                        Console.WriteLine($"Datorns poäng: {computerPoints}");
                        Console.WriteLine();

                        bool gameLoop = true;

                        while (gameLoop != false)
                        {

                            Console.WriteLine("Vill du dra ett till kort? (j/n)");
                            string playerChoice = Console.ReadLine().ToLower();
                            Console.Clear();
                            bool playersTurn = true;

                            if (playerChoice == "j")
                            {
                                points = cardsDraw.Next(1, 11);
                                playerPoints = playerPoints + points;
                                Console.Clear();
                                Console.WriteLine($"Ditt kort: {points}");
                                Console.WriteLine();
                                Console.WriteLine($"Dina poäng: {playerPoints}");
                                Console.WriteLine($"Datorns poäng: {computerPoints}");
                                points = 0;

                                if (playerPoints > 21)
                                {
                                    Console.WriteLine("Datorn vann!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    lastWinner = "Datorn";
                                    gameLoop = false;

                                }

                            }
                            else if (playerChoice == "n")
                            {
                                while (computerPoints <= playerPoints && computerPoints < 21)
                                {
                                    playersTurn = false;
                                    points = cardsDraw.Next(1, 11);
                                    computerPoints = computerPoints + points;
                                    Console.WriteLine("Datorn valde att dra mer kort:");
                                    Console.WriteLine($"Datorns kort: {points}");
                                    Console.WriteLine($"Dina poäng: {playerPoints}");
                                    Console.WriteLine($"Datorns poäng: {computerPoints}");
                                    Console.WriteLine();

                                    if (computerPoints > 21)
                                    {
                                        Console.WriteLine("Du vann!");
                                        Console.WriteLine();
                                        Console.WriteLine("Skriv vad du vill bli kallad på leaderboarden");
                                        lastWinner = Console.ReadLine();
                                        gameLoop = false;
                                        Console.Clear();

                                    }
                                    else if (computerPoints <= 21 && computerPoints > playerPoints && playersTurn == false)
                                    {
                                        Console.WriteLine("Datorn vann!");
                                        Console.ReadLine();
                                        Console.Clear();
                                        lastWinner = "Datorn";
                                        gameLoop = false;

                                    }

                                }
                            }
                            else
                            {

                            }
                        }

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Spelet går ut på att få poäng så nära 21 som möjligt utan att överstiga det.");
                        Console.WriteLine();
                        Console.WriteLine("Det börjar med att både datorn och du får 2 kort var, varje kort är värt mellan 1 och 10.");
                        Console.WriteLine();
                        Console.WriteLine("Sedan kommer du få dra mer kort om du vill, när du är nöjd med dina poäng är det datorns tur att dra kort.");
                        Console.WriteLine();
                        Console.WriteLine("Den spelare som får högst poäng utan att överstiga 21 vinner, du ska försöka tvinga datorn att få över 21 helt enkelt.");
                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case "3":
                        Console.WriteLine($"Den senaste vinnaren är: {lastWinner}");
                        Console.ReadLine();
                        Console.Clear();

                        break;

                    case "4":
                        shutdowm = true;
                        break;

                    default:
                        Console.WriteLine("Skriv ett tal mellan 1 och 4");
                        break;

                }
            }
        }

    }

}
