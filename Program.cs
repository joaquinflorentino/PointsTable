using System;
using System.Threading;

namespace PointsTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPlayerCount = "";
            int playerCount = 0;
            string name1 = "";
            string name2 = "";
            string name3 = "";
            int player1Score = 0;
            int player2Score = 0;
            int player3Score = 0;
            string dashes = "---------------------------------------------------------------";
            string command = "";
            string nameInput = "";

            Console.WriteLine(dashes);
            Console.WriteLine("Press enter.");
            Console.ReadKey();
            Console.WriteLine(dashes);
            Console.WriteLine("How many players are involved? (Max: 3)");
            inputPlayerCount = Console.ReadLine();

            if (inputPlayerCount != "1" && inputPlayerCount != "2" && inputPlayerCount != "3") {
                Console.WriteLine("Invalid input.");
                Environment.Exit(0);
            }
            else {
                playerCount = Int32.Parse(inputPlayerCount);
            }
            Console.WriteLine(dashes);
            Console.WriteLine("Enter the names of the players.");

            switch (inputPlayerCount) {
                case "1":
                    name1 = Console.ReadLine();
                    break;
                case "2":
                    name1 = Console.ReadLine();
                    Console.WriteLine("---");
                    name2 = Console.ReadLine();
                    break;
                case "3":
                    name1 = Console.ReadLine();
                    Console.WriteLine("---");
                    name2 = Console.ReadLine();
                    Console.WriteLine("---");
                    name3 = Console.ReadLine();
                    break;
            }
            Console.WriteLine(dashes);
            PrintDirectory();

            while (true) {
                command = Console.ReadLine();

                switch (command) {
                    case "/help":
                        PrintDirectory();
                        break;
                    case "/table":
                        PrintTable();
                        break;
                    case "/+p":
                        AddPoint();
                        break;
                    case "/-p":
                        MinusPoint();
                        break;
                    case "/exit":
                        Exit();
                        break;
                    default:
                        Console.WriteLine(dashes);
                        Console.WriteLine("That command does not exist. Type /help for commands.");
                        break;
                }
            }

            int MaxNumberOfThree() {
                int name1Length = name1.Length;
                int name2Length = name2.Length;
                int name3Length = name3.Length;
                int firstMax = Math.Max(name1Length, name2Length);

                return Math.Max(firstMax, name3Length);
            }

            void PrintDirectory() {
                Console.WriteLine("Welcome to the directory. Here is a list of commands.");
                Console.WriteLine("/table           /help           /exit\n/+p              /-p");
            }

            void PrintTable() {
                Console.WriteLine(dashes);

                if (playerCount == 1) {
                    Console.WriteLine(name1 + " | " + player1Score);
                }
                else {
                    int multiplier1 = MaxNumberOfThree() - name1.Length;
                    int multiplier2 = MaxNumberOfThree() - name2.Length;
                    int multiplier3 = MaxNumberOfThree() - name3.Length;
                    
                    string margin1 = new string(' ', multiplier1);
                    string margin2 = new string(' ', multiplier2);
                    string margin3 = new string(' ', multiplier3);

                    if (playerCount == 2) {
                        Console.WriteLine(name1 + margin1 + " | " + player1Score);
                        Console.WriteLine(name2 + margin2 + " | " + player2Score);
                    }
                    else {
                        Console.WriteLine(name1 + margin1 + " | " + player1Score);
                        Console.WriteLine(name2 + margin2 + " | " + player2Score);
                        Console.WriteLine(name3 + margin3 + " | " + player3Score);
                    }
                }
            }

            void AddPoint() {
                Console.WriteLine(dashes);
                Console.WriteLine("Increase whose score?");
                nameInput = Console.ReadLine();
                Console.WriteLine(dashes);
                
                if (nameInput == name1) {
                    player1Score++;
                    Console.WriteLine("Point has been added to " + name1 + '.');
                }
                else if (nameInput == name2) {
                    player2Score++;
                    Console.WriteLine("Point has been added to " + name2 + '.');
                }
                else if (nameInput == name3) {
                    player3Score++;
                    Console.WriteLine("Point has been added to " + name3 + '.');
                }
                else {
                    Console.WriteLine("Invalid input.");
                }
            }

            void MinusPoint() {
                Console.WriteLine(dashes);
                Console.WriteLine("Subtract whose score?");
                nameInput = Console.ReadLine();

                if (nameInput == name1) {
                    player1Score--;
                    Console.WriteLine("Taken point away from " + name1 + '.');
                }
                else if (nameInput == name2) {
                    player2Score--;
                    Console.WriteLine("Taken point away from " + name2 + '.');
                }
                else if (nameInput == name3) {
                    player3Score--;
                    Console.WriteLine("Taken point away from " + name3 + '.');
                }
                else {
                    Console.WriteLine("Invalid input.");
                }
            }

            void Exit() {
                Console.WriteLine("Terminating application...");

                for (int i = 3; i > 0; i--) {
                    Thread.Sleep(1000);

                    switch (i) {
                        default:
                            Console.WriteLine(i + "...");
                            break;
                        case 1:
                            Console.WriteLine(i);
                            break;
                    }
                }
                Environment.Exit(0);
            }
        }
    }
}