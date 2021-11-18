using System;
using System.Collections.Generic;
using System.Linq;

namespace Rozgrzewka
{
    class Program
    {
        static void Main(string[] args)
        {

            
            //Rozgrzewka

            //Zad2.

            Console.WriteLine("Podaj swoje imię:");
            var name = Console.ReadLine();
            Console.WriteLine("Hello " + name);


            //Zad3.
            int result = 5 + 9;
            //Błędem był brak średnika

            //Operatory
            //Zad1.

            Console.WriteLine("\n");

            int number = 2;
            float money = 2.123456789101112131415F;
            string text = "dwa";
            bool isLogged = true;
            char myChar = 'D';
            decimal price = 2.123456789101112131415M;

            Console.WriteLine(number);
            Console.WriteLine(money);
            Console.WriteLine(text);
            Console.WriteLine(isLogged);
            Console.WriteLine(myChar);
            Console.WriteLine(price);


            //Zad2.
            Console.WriteLine("\n");

            string myAge = "Age: ";
            int wifeAge = 18;
            var result1 = myAge + wifeAge;
            Console.WriteLine(result1);

            /*Wnioski: Operator dodawania działa w różny sposób w zależności od typów zmiennych - 
             w przypadku dwóch liczb faktycznie dodaje je do siebie, a w przypadku, gdy chociaż jedna zmienna jest stringiem,
            to wykonuje łączenie stringów.*/

            //Zad3.

            Console.WriteLine("\n");

            bool isTrue = true;
            bool isFalse = false;
            bool isReallyTrue = true;

            bool and = isTrue && isFalse;
            bool or = isTrue || isReallyTrue;
            bool negative = !isFalse;

            Console.WriteLine(and);
            Console.WriteLine(or);
            Console.WriteLine(negative);



            //Zad4.
            Console.WriteLine("\n");

            double a = 5;
            double b = 12;

            double add = a + b;
            double sub = a - b;
            double div = a / b;
            double mul = a * b;
            double mod = a % b;

            Console.WriteLine(add);
            Console.WriteLine(sub);
            Console.WriteLine(div);
            Console.WriteLine(mul);
            Console.WriteLine(mod);



            //Zad5.

            Console.WriteLine("\n");

            string a1 = "Ala ";
            string b1 = "ma ";
            string c1 = "kota.";

            string result2 = a1 + b1 + c1;
            Console.WriteLine(result2);
            //Spostrzeżenie - operator + w przypadku stringów służy do ich łączenia.

            //Instrukcje sterujące i pętle

            //Zad1.

            Console.WriteLine("\n");

            int n1 = 10;
            int n2 = 20;

            if (n1 > n2)
            {
                Console.WriteLine("n1 jest większe od n2");
            }
            else if(n1 < n2)
            {
                Console.WriteLine("n1 jest mniejsze od n2");
            }
            else
            {
                Console.WriteLine("n1 jest równe n2");
            }

            //Zad2. 

            Console.WriteLine("\n");

            for (int i2 = 0; i2<10; i2++)
            {
                Console.WriteLine("C#");
            }

            Console.WriteLine("\n");

            int j = 0;
            while (j < 10)
            {
                Console.WriteLine("C#");
                j++;
            }

            //Zad3.

            Console.WriteLine("\n");

            int n = 10;
            int kmod;

            for (int k = 0; k < n+1; k++)
            {
                kmod = k % 2;
                if(kmod == 0)
                {
                    Console.WriteLine(k + " - jest parzysta");
                }
                else
                {
                    Console.WriteLine(k + " - jest nieparzysta");
                }

            }

            //Zad4. *dodatkowe

            Console.WriteLine("\n");

            int n3 = 5;
            int i = 1;

            while(i < n3+1)
            {
                Console.WriteLine(String.Concat(Enumerable.Repeat("*", i)));
                i++;
            }

            //Zad5. *dodatkowe
            Console.WriteLine("\n");

            int exam=57;

            switch (exam)
            {
                case int s when (s >= 0 && s <= 39):
                    Console.WriteLine("Ocena niedostateczna");
                    break;
                case int s when (s >= 40 && s <= 54):
                    Console.WriteLine("Ocena dopuszczająca");
                    break;
                case int s when (s >= 55 && s <= 69):
                    Console.WriteLine("Ocena dostateczna");
                    break;
                case int s when (s >= 70 && s <= 84):
                    Console.WriteLine("Ocena dobra");
                    break;
                case int s when (s >= 85 && s <= 98):
                    Console.WriteLine("Ocena bardzo dobra");
                    break;
                case int s when (s >= 99 && s <= 100):
                    Console.WriteLine("Ocena celująca");
                    break;
                default:
                    Console.WriteLine("Wartość poza zakresem");
                    break;
            }

            //Kolekcje
            //Zad1.
            Console.WriteLine("\n");

            var colors = new string[4]
            { 
            "czerwony",
            "niebieski",
            "zielony",
            "biały"
            };

            Console.WriteLine("Mój pierwszy kolor to: " + colors[0]);
            Console.WriteLine("Mój ostatni kolor to: " + colors[3]);


            //Zad2. 
            Console.WriteLine("\n");

            var numbers = new int[10]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };

            for(int i3 = 0; i3<10; i3++)
            {
                Console.WriteLine("Liczba: "+ numbers[i3]);
            }

            Console.WriteLine("\n");

            foreach (int number1 in numbers)
            {
              Console.WriteLine("Liczba: " + number1);
            }

            Console.WriteLine("\n");

            int l = 0;

            while (l < numbers.Length){
                Console.WriteLine("Liczba: " + numbers[l]);
                l++;
            }

            
            //Zad.3

            Console.WriteLine("\n");

            List<string> fruits = new List<string>();

            fruits.Add("Jabłko");
            fruits.Add("Banan");
            fruits.Add("Pomarańcza");
            fruits.Add("Mandarynka");
            
            foreach(string fruit in fruits)
            {
                Console.WriteLine(fruit + ", ");
            }

            fruits.Remove("Jabłko");
            fruits.RemoveAt(fruits.Count-1);

            Console.WriteLine("\n");

            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit + ", ");
            }
            


        }
    }
}
