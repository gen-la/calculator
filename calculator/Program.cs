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
    static void Main()
    {
        double firstNum = 0;
        double secondNum = 0;
        string menyVal = "";
        bool checkNum = false;
        //int cursorTop = Console.CursorTop; //Markörens position
        // En lista för att spara historik för räkningar
        string resultat = "";
        List<string> resultatLista = new List<string>();

        titel();
        calcMeny:
            Console.WriteLine("\n\nVälj ett av alternativen nedan:\n" +
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
                    checkNum = double.TryParse(Console.ReadLine(), out firstNum);
                    if (!checkNum)
                        Console.WriteLine("Fel input, skriv en siffra.");
                }
                checkNum = false;
                while (!checkNum)
                {
                    Console.WriteLine("Skriv in det andra talet: ");
                    checkNum = double.TryParse(Console.ReadLine(), out secondNum);
                    if (!checkNum)
                        Console.WriteLine("Fel input, skriv en siffra.");
                }
                checkNum = false;
                //firstNum = Convert.ToDouble(Console.ReadLine());
                //secondNum = Convert.ToDouble(Console.ReadLine());
                goto chooseOperator;
                break;
            case "2": // Visa tidigare resultat
                if (resultatLista.Count == 0)
                {
                    //Console.WriteLine(String.Join(", ", resultatLista));
                    Console.WriteLine("Du har inga sparade resultat.");
                }
                else
                {
                    //Console.WriteLine("Du har inga sparade resultat.");
                    Console.WriteLine(String.Join(",   ", resultatLista));
                }
                Console.WriteLine("\nTryck på enter för att återvända till menyn.");
                Console.ReadKey();
                Console.Clear();
                goto calcMeny;
                break;
            case "3":
                goto avsluta;
                break;
            case "art":
                art();
                break;
            default:
                Console.WriteLine("| FELAKTIGT MENYVAL! FÖRSÖK IGEN |");
                goto calcMeny;
                break;
        }
        
        //Välj operator och utför beräkningarna
        chooseOperator:
            int cursorTop = Console.CursorTop;
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
                Console.SetCursorPosition(0, 0);    //Visa felmeddelande högst upp
                Console.WriteLine("| FELAKTIG INMATNING! FÖRSÖK IGEN. |");
                Console.SetCursorPosition(0, 6);   //Flytta tillbaka markören till sin plats
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
                Console.WriteLine("Felaktigt val, försök igen.\n");
                goto fortsattLRavslut;
            }


    //Visa ett meddelande innan programmet avslutas
    avsluta:
        Console.WriteLine("Avslutar miniräknaren");

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
            Thread.Sleep(5000);
            Console.Clear();
        }

        void rensa() //Rensa bort felmeddelande
        {
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                              ");
            Console.SetCursorPosition(0, cursorTop);
        }

        void art() { }

    }
}