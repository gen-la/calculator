using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace calculator; 

class Program
{
    static void Main() //test
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
            Console.WriteLine("\nVälj ett av alternativen nedan:\n" +
                "1. Starta miniräknaren\n" +
                "2. Visa tidigare resultat\n" +
                "3. Avsluta");
            //menyVal = int.Parse(Console.ReadLine());
            menyVal = (Console.ReadLine());
            Console.Clear();

    // Användaren matar in tal och matematiska operation
    // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
    raknemeny:
        switch (menyVal)
        {
            case "1":
                while (!checkNum)
                {
                    Console.WriteLine("\n\nSkriv in det första talet: ");
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
                    Console.WriteLine("Skriv in det andra talet: ");
                    Console.WriteLine("                                                              "); //Rensa raden från tidigare input
                    Console.SetCursorPosition(0, 5);
                    checkNum = double.TryParse(Console.ReadLine(), out secondNum);
                    if (!checkNum)
                        //Console.WriteLine("Fel input, skriv en siffra.");
                        error();
                        Console.SetCursorPosition(0, 6); //bugfix, markör på fel rad
                }
                rensa();    //Radera felmeddelandet
                checkNum = false;
                Console.SetCursorPosition(0, 6); //bugfix, markör på fel rad
                //firstNum = Convert.ToDouble(Console.ReadLine());
                //secondNum = Convert.ToDouble(Console.ReadLine());
                goto chooseOperator;
                break;
            case "2": // Visa tidigare resultat
                if (resultatLista.Count == 0)
                {
                    Console.WriteLine("Du har inga sparade resultat.");
                }
                else
                {
                    Console.WriteLine(String.Join("\n", resultatLista));
                }
                Console.WriteLine("\nTryck på enter för att återvända till menyn.");
                Console.ReadKey();
                Console.Clear();
                goto calcMeny;
                break;
            case "3":
                avsluta();
                break;
            case "":
                Console.WriteLine("Grattis, du har hittat en hemlighet. Skanna koden nedan.\n");
                qrcode();
                Console.WriteLine("\n\nDet finns en till " +
                    "hemlighet att upptäcka.\nFör att hitta den behöver du skriva in rätt " +
                    "lösenord i menyn.\nHär har du en ledtråd:\n" +
                    "Loggan som visades när programmet startade är gjord med symboler " +
                    "istället för bilder.\nVad heter denna sorts grafik på engelska?\n\n" +
                    "Tryck på enter för att återvända till menyn.");
                Console.ReadKey();
                Console.Clear();
                goto calcMeny;
                break;
            case "consoleart":
                consoleart();
                break;
            default:
                Console.WriteLine("| FELAKTIGT MENYVAL! FÖRSÖK IGEN |");
                goto calcMeny;
                break;
        }

        //Välj operator och utför beräkningarna
        chooseOperator:
            cursorTop = Console.CursorTop; //Markörens position
            Console.WriteLine("Välj en operator (+ - / *):");
            Console.WriteLine("                                                              "); //Rensa raden från tidigare input
            Console.SetCursorPosition(0, cursorTop+1);
            string valOperator = Console.ReadLine();
            if ( valOperator=="+" || valOperator=="-" || valOperator=="/" || valOperator=="*")
            {
                switch (valOperator)
                {
                    case "+":
                        resultat = $"{firstNum} + {secondNum} = {firstNum + secondNum}";
                        resultatLista.Add(resultat);
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
                            Console.WriteLine("Skriv in ett tal större än 0:");
                            checkNum = double.TryParse(Console.ReadLine(), out firstNum);
                            if (!checkNum)
                                Console.WriteLine("Fel input, skriv en siffra.");
                            //firstNum = Convert.ToDouble(Console.ReadLine());
                        }
                        checkNum = false;
                        while (!checkNum && secondNum <= 0)
                        {
                            Console.WriteLine("Skriv in ett tal större än 0:");
                            checkNum = double.TryParse(Console.ReadLine(), out secondNum);
                            if (!checkNum)
                                Console.WriteLine("Fel input, skriv en siffra.");
                            //secondNum = Convert.ToDouble(Console.ReadLine());
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

        /*switch (valOperator)
        {
            case "+":
                Console.WriteLine(firstNum + secondNum);
                goto fortsattLRavslut;
                break;
            case "-":
                Console.WriteLine(firstNum - secondNum);
                goto fortsattLRavslut;
                break;
            case "/":
                Console.WriteLine(firstNum / secondNum);
                goto fortsattLRavslut;
                break;
            case "*":
                Console.WriteLine(firstNum * secondNum);
                goto fortsattLRavslut;
                break;
            default:
                //Console.Write("Felaktig inmatning. Försök igen.\n");
                //Main();
                //goto chooseOperator;
                break;
        }*/

        // Fråga användaren om den vill avsluta eller fortsätta.
        fortsattLRavslut:
            Console.WriteLine("\nVill du utföra fler beräkningar? (Ja/Nej)");
            string val = Console.ReadLine().ToLower();
            if (val == "j" || val == "ja")
            {
                //menyVal = 1;
                menyVal = "1";
                Console.Clear();
                goto raknemeny;
            }
            if (val == "n" || val == "nej") 
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


        //Visa ett meddelande innan programmet avslutas
        //avsluta:
        void avsluta()
        {
            Console.WriteLine("Avslutar miniräknaren");
            Thread.Sleep(2000);
            System.Environment.Exit(0);
        }
        

    /*if (val == "+" || val == "-" || val == "/" || val == "*")
    {
        switch (val)
        {
            case "+":
                Console.WriteLine(firstNum + secondNum);
                break;
            case "-":
                Console.WriteLine(firstNum - secondNum);
                break;
            case "/":
                Console.WriteLine(firstNum / secondNum);
                break;
            case "*":
                Console.WriteLine(firstNum * secondNum);
                break;
            default:
                Console.Write("Felaktigt menyval, försök igen.");
                break;
        }
    }
    else
    {
        Console.WriteLine($"Felaktig inmatning. Välj en operator (+ - / *): ");
        val = Console.ReadLine();
        switch (val)
        {
            case "+":
                Console.WriteLine(firstNum + secondNum);
                break;
            case "-":
                Console.WriteLine(firstNum - secondNum);
                break;
            case "/":
                Console.WriteLine(firstNum / secondNum);
                break;
            case "*":
                Console.WriteLine(firstNum * secondNum);
                break;
            default:
                Console.Write("Felaktigt menyval, försök igen.");
                break;
        }
    }*/
    // Lägga resultat till listan
    // Visa resultat
    // Fråga användaren om den vill visa tidigare resultat.
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
            Console.WriteLine("\n---------------------------   VÄLKOMMEN   ---------------------------");
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
            Console.WriteLine("|#|  ERROR! FÖRSÖK IGEN.  |#|");
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
            Console.WriteLine("\n\n\nGrattis! Du har hittat en hemlig del av miniräknaren.\n" +
                "G.L. Är mina initialer, här i Console art, också känt som ASCII art.");
            Thread.Sleep(15000);
            Console.WriteLine("\nSom belöning har jag gjort din dator lite snabbare genom " +
                "att rensa lite i System32 mappen.");
            Thread.Sleep(3000);
            Console.WriteLine("Njut av en snabbare dator :)");
            Thread.Sleep(4000);
            System.Environment.Exit(0);
            //Console.Clear();
            //Main();
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