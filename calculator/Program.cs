﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace calculator; 

class Program
{
    static void Main()
    {
        double firstNum = 0;
        double secondNum = 0;
        int menyVal = 0;
        bool checkNum = false;
        // En lista för att spara historik för räkningar

        // Välkomnande meddelande
        Console.WriteLine("Välkommen till miniräknaren. Du kan utföra beräkningar med operatorerna + - / och *\n");
        calcMeny:
            Console.WriteLine("Välj ett av alternativen nedan:\n" +
                "1. Starta miniräknaren\n" +
                "2. Visa tidigare resultat\n" +
                "3. Avsluta");
            menyVal = int.Parse(Console.ReadLine());

        // Användaren matar in tal och matematiska operation
        // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
        raknemeny:
        switch (menyVal)
        {
            case 1:
                while (!checkNum)
                {
                    Console.WriteLine("Skriv in det första talet: ");
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
            case 2:
                Console.WriteLine("Resultat"); // Visa tidigare resultat
                goto calcMeny;
                break;
            case 3:
                goto avsluta;
                break;
            default:
                Console.Write("Felaktigt menyval. Försök igen.\n");
                goto calcMeny;
                break;
        }
        
        //Välj operator och utför beräkningarna
        chooseOperator:
            Console.WriteLine($"Välj en operator (+ - / *): ");
            string valOperator = Console.ReadLine();
            if ( valOperator=="+" || valOperator=="-" || valOperator=="/" || valOperator=="*")
            {
                switch (valOperator)
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
                        if (firstNum <= 0 || secondNum <= 0)
                        {
                            goto default;
                        }
                        else 
                        {
                            Console.WriteLine(firstNum / secondNum);
                            goto fortsattLRavslut;
                        }
                        break;
                    case "*":
                        Console.WriteLine(firstNum * secondNum);
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
                Console.Write("Felaktig inmatning. Försök igen.\n");
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
            Console.WriteLine("Vill du forstätta(F) eller avsluta?(A)");
            string val = Console.ReadLine().ToLower();
            if (val == "f")
            {
                menyVal = 1;
                goto raknemeny;
            }
            if (val == "a") 
            {
                goto avsluta;
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
    }
}