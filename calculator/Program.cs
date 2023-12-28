using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace calculator; 

class Program
{
    static void Main()
    {
        double firstNum = 0;
        double secondNum = 0;
        string menyVal = "";
        bool checkNum = false;
        int cursorTop = 0;
        // En lista för att spara historik för räkningar
        string resultat = "";
        List<string> resultatLista = new List<string>();

        titel();
        calcMeny:
            Console.WriteLine("\nChoose an option below:\n" +
                "1. Start the calculator\n" +
                "2. Show earlier results\n" +
                "3. Shut down the calculator");
            //menyVal = int.Parse(Console.ReadLine());
            menyVal = (Console.ReadLine());
            Console.Clear();

    // Användaren matar in tal och matematisk operation
    // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
    raknemeny:
        switch (menyVal)
        {
            case "1":
                while (!checkNum)
                {
                    Console.WriteLine("\n\nType the first number: ");
                    Console.WriteLine("                                                              "); //Rensa raden från tidigare input
                    Console.SetCursorPosition(0, 3);
                    checkNum = double.TryParse(Console.ReadLine(), out firstNum);
                    if (!checkNum)
                        error();
                        Console.SetCursorPosition(0, 0); //bugfix, markör på fel rad
                }
                rensa();    //Radera felmeddelandet
                checkNum = false;
                while (!checkNum)
                {
                    Console.SetCursorPosition(0, 4); //bugfix, markör på fel rad
                    Console.WriteLine("Type the second number: ");
                    Console.WriteLine("                                                              "); //Rensa raden från tidigare input
                    Console.SetCursorPosition(0, 5);
                    checkNum = double.TryParse(Console.ReadLine(), out secondNum);
                    if (!checkNum)
                        error();
                        Console.SetCursorPosition(0, 6); //bugfix, markör på fel rad
                }
                rensa();    //Radera felmeddelandet
                checkNum = false;
                Console.SetCursorPosition(0, 6); //bugfix, markör på fel rad
                goto chooseOperator;
                break;
            case "2": // Visa tidigare resultat
                if (resultatLista.Count == 0)
                {
                    Console.WriteLine("You have no saved results.");
                }
                else
                {
                    Console.WriteLine(String.Join("\n", resultatLista));
                }
                Console.WriteLine("\nPress ENTER to return to the menu.");
                Console.ReadKey();
                Console.Clear();
                goto calcMeny;
                break;
            case "3":
                avsluta();
                break;
            case "":
                Console.WriteLine("Congrats, you have found a secret. Scan the QR code below.\n");
                qrcode();
                Console.WriteLine("\n\nThere is another secret to discover.\nTo find it you " +
                    "need to type the correct password in the menu.\nHere's a hint:\n" +
                    "The loggo shown at startup is made up of symbols instead of images.\n" +
                    "What is this kind of graphic called?\n\n" +
                    "Press ENTER to return to the menu.");
                Console.ReadKey();
                Console.Clear();
                goto calcMeny;
                break;
            case "consoleart":
                consoleart();
                break;
            default:
                Console.WriteLine("| INVALID MENUCHOICE! PLEASE TRY AGAIN |");
                goto calcMeny;
                break;
        }

        //Välj operator och utför beräkningarna
        chooseOperator:
            cursorTop = Console.CursorTop; //Spara markörens position
            Console.WriteLine("Choose an operand (+ - / *):");
            Console.WriteLine("                                                              "); //Rensa raden från tidigare input
            Console.SetCursorPosition(0, cursorTop+1);
            string valOperator = Console.ReadLine();
            if ( valOperator=="+" || valOperator=="-" || valOperator=="/" || valOperator=="*")
            {
                switch (valOperator)
                {
                    case "+":
                        resultat = $"{firstNum} + {secondNum} = {firstNum + secondNum}";
                        resultatLista.Add(resultat); // Lägg resultatet till listan
                        Console.WriteLine(resultat);
                        rensa();
                        goto fortsattLRavslut;
                        break;
                    case "-":
                        resultat = $"{firstNum} - {secondNum} = {firstNum - secondNum}";
                        resultatLista.Add(resultat);
                        Console.WriteLine(resultat);
                        rensa();
                        goto fortsattLRavslut;
                        break;
                    case "/":
                        if (firstNum <= 0 || secondNum <= 0)
                        {
                            goto default;
                        }
                        else 
                        {
                            resultat = $"{firstNum} / {secondNum} = {firstNum / secondNum}";
                            resultatLista.Add(resultat);
                            Console.WriteLine(resultat);
                            rensa();
                            goto fortsattLRavslut;
                        }
                        break;
                    case "*":
                        resultat = $"{firstNum} * {secondNum} = {firstNum * secondNum}";
                        resultatLista.Add(resultat);
                        Console.WriteLine(resultat);
                        rensa();
                        goto fortsattLRavslut;
                        break;
                    default:    // Ifall användaren skulle dela med 0 visa Ogiltig inmatning!
                        while (!checkNum && firstNum <= 0)
                        {
                            Console.WriteLine("Type a number bigger than 0:");
                            checkNum = double.TryParse(Console.ReadLine(), out firstNum);
                            if (!checkNum)
                                Console.WriteLine("Wrong input, type a number.");
                        }
                        checkNum = false; //ändra till false för att gå in i loopen nedan
                        while (!checkNum && secondNum <= 0)
                        {
                            Console.WriteLine("Type a number bigger than 0:");
                            checkNum = double.TryParse(Console.ReadLine(), out secondNum);
                            if (!checkNum)
                                Console.WriteLine("Wrong input, type a number.");
                        }
                        checkNum = false;
                        goto case "/";
                        break;
                }
            }
            else 
            {
                error();
                goto chooseOperator;
            }

        // Fråga användaren om den vill avsluta eller fortsätta.
        fortsattLRavslut:
            Console.WriteLine("\nDo you want to do some more calculations? (Y/N)");
            string val = Console.ReadLine().ToLower();
            if (val == "y" || val == "yes")
            {
                menyVal = "1";
                Console.Clear();
                goto raknemeny;
            }
            if (val == "n" || val == "no") 
            {
                Console.Clear();
                goto calcMeny;
            }
            else 
            {
                error();
                Console.SetCursorPosition(0, 9); //Återställ markörens plats efter error
                goto fortsattLRavslut;
            }

        void avsluta() //Visa ett meddelande innan programmet avslutas och avsluta programmet
        {
            Console.WriteLine("Shutting off the calculator");
            Thread.Sleep(2000);
            System.Environment.Exit(0);
        }
        
        void titel()
        {
            Console.WriteLine(@" ________          ________          ___               ________");
            Console.WriteLine(@"|\   ____\        |\   __  \        |\  \             |\   ____\  ");
            Console.WriteLine(@"\ \  \___|        \ \  \|\  \       \ \  \            \ \  \___|  ");
            Console.WriteLine(@" \ \  \            \ \   __  \       \ \  \            \ \  \    ");
            Console.WriteLine(@"  \ \  \____        \ \  \ \  \       \ \  \____        \ \  \____  ");
            Console.WriteLine(@"   \ \_______\       \ \__\ \__\       \ \_______\       \ \_______\");
            Console.WriteLine(@"    \|_______|        \|__|\|__|        \|_______|        \|_______|");
            // Välkomnande meddelande
            Console.WriteLine("\n---------------------------   WELCOME   ---------------------------");
            Thread.Sleep(4000);
            Console.Clear();
        }

        void rensa() //Rensa bort felmeddelande
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                              ");
            Console.SetCursorPosition(0, cursorTop);
        }

        void error()
        {
            Console.SetCursorPosition(0, 0);    //Visa felmeddelande högst upp
            Console.WriteLine("|#|  ERROR! TRY AGAIN.  |#|");
            Console.SetCursorPosition(0, cursorTop);   //Flytta tillbaka markören till sin plats
        }

        void consoleart() 
        {
            Console.WriteLine(@"          _____                    _____  ");
            Console.WriteLine(@"         /\    \                  /\    \ ");
            Console.WriteLine(@"        /::\    \                /::\____\");
            Console.WriteLine(@"       /::::\    \              /:::/    /");
            Console.WriteLine(@"      /::::::\    \            /:::/    / ");
            Console.WriteLine(@"     /:::/\:::\    \          /:::/    /  ");
            Console.WriteLine(@"    /:::/  \:::\    \        /:::/    /   ");
            Console.WriteLine(@"   /:::/    \:::\    \      /:::/    /    ");
            Console.WriteLine(@"  /:::/    / \:::\    \    /:::/    /     ");
            Console.WriteLine(@" /:::/    /   \:::\ ___\  /:::/    /      ");
            Console.WriteLine(@"/:::/____/  ___\:::|    |/:::/____/       ");
            Console.WriteLine(@"\:::\    \ /\  /:::|____|\:::\    \       ");
            Console.WriteLine(@" \:::\    /::\ \::/    /  \:::\    \      ");
            Console.WriteLine(@"  \:::\   \:::\ \/____/    \:::\    \     ");
            Console.WriteLine(@"   \:::\   \:::\____\       \:::\    \    ");
            Console.WriteLine(@"    \:::\  /:::/    /        \:::\    \   ");
            Console.WriteLine(@"     \:::\/:::/    /          \:::\    \  ");
            Console.WriteLine(@"      \::::::/    /            \:::\    \ ");
            Console.WriteLine(@"       \::::/    /              \:::\____\");
            Console.WriteLine(@"        \::/____/                \::/    /");
            Console.WriteLine(@"                                  \/____/ ");
            Thread.Sleep(3000);
            Console.WriteLine("\n\n\nCongratulations! You have found a secret part of the Calc.\n" +
                "G.L. Are my initials, here in Console art, also known as ASCII art.");
            Thread.Sleep(15000);
            Console.WriteLine("\nAs a reward I have made your computer a little faster by " +
                "deleting some files in the System32 folder.");
            Thread.Sleep(3000);
            Console.WriteLine("Enjoy a faster computer :)");
            Thread.Sleep(4000);
            System.Environment.Exit(0);
        }

        void qrcode()
        {
            Console.WriteLine(@"   ▄▄▄▄▄▄▄   ▄ ▄ ▄ ▄▄ ▄  ▄▄▄▄▄▄▄  ");
            Console.WriteLine(@"   █ ▄▄▄ █ ▀ ▀ ▄▀▄█▀ ▀▄█ █ ▄▄▄ █  ");
            Console.WriteLine(@"   █ ███ █ ▀█▀ ▀█▄█▄  ▄█ █ ███ █  ");
            Console.WriteLine(@"   █▄▄▄▄▄█ █▀▄▀█ ▄▀█▀▄ ▄ █▄▄▄▄▄█  ");
            Console.WriteLine(@"   ▄▄▄▄▄ ▄▄▄█▀█▄ ▄▀▄▄  █▄ ▄ ▄ ▄   ");
            Console.WriteLine(@"   ▄▄▀  █▄ ▄ █ ▀▄██▀▄▀▀▄ ▀▀█   ▀  ");
            Console.WriteLine(@"   ▀▀▀█▀▄▄  ▄▄▄█ ▄▀▄  ▀█▄ █▀█▄▀   ");
            Console.WriteLine(@"   █▄▄  ▄▄ ▄  ▀ ▄▄▄█▀▄▀█▀███▄▄ ▀  ");
            Console.WriteLine(@"    █▄▄ ▀▄▄▄ █▀▀▄▀  ▄▀ ▄▀▀█▀▄▄▀   ");
            Console.WriteLine(@"   █ █▄▄▄▄██▀█▀▀▀▀██▄█ ▀█▀█▀ █ ▀  ");
            Console.WriteLine(@"   █  ██▄▄█▀ ▀██▄█▀█   ████▄ ▄█▄  ");
            Console.WriteLine(@"   ▄▄▄▄▄▄▄ █▄▄▀▄ ▄▄▄ ▄▄█ ▄ ███▀▀  ");
            Console.WriteLine(@"   █ ▄▄▄ █ ▄▄▀▀▀ █▀ ▄▄▀█▄▄▄█ ▄█   ");
            Console.WriteLine(@"   █ ███ █ █▄▀▀▀▀▀▄██ ██▄▄▄▄██▄▀  ");
            Console.WriteLine(@"   █▄▄▄▄▄█ █▀█▄▄▄ ▄▄▄  ▀  ▀▀█▄▀   ");
        }
    }
}