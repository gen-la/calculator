using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator; 

class Program
{
    static void Main()
    {
        //Pseudo kod
        // Välkomnande meddelande
        Console.WriteLine($"Välkommen till miniräknaren. Du kan utföra beräkningar med operatorerna + - / och *");
        // En lista för att spara historik för räkningar
        // Användaren matar in tal och matematiska operation
        // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
        Console.WriteLine("Skriv in det första talet: ");
        double firstNum = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Skriv in det andra talet: ");
        double secondNum = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Välj en operator (+ - / *): ");
        string val = Console.ReadLine();

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
                Console.Write("Felaktig inmatning. Försök igen.\n");
                Main();
                break;
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
        // Ifall användaren skulle dela med 0 visa Ogiltig inmatning!
        // Lägga resultat till listan
        // Visa resultat
        // Fråga användaren om den vill visa tidigare resultat.
        // Visa tidigare resultat
        // Fråga användaren om den vill avsluta eller fortsätta.



    }
}