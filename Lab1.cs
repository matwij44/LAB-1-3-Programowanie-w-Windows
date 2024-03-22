using System;
using System.Security.Cryptography;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.exercise1();
            //program.exercise2();
            //program.exercise3();
            //program.exercise4();
            program.exercise5();
        }

        public void exercise1()
        {
            Console.WriteLine("Welcome to 'GUESS THE NUMBER' game !!!");

            Random random = new Random();
            int secretNumber = random.Next(1, 11);
            string userGuess = "0";
            while (userGuess != secretNumber.ToString())
            {

                Console.WriteLine("Enter your guess:");
                userGuess = Console.ReadLine();
                if (int.TryParse(userGuess, out int userGuessINT) && userGuessINT >= 1 && userGuessINT <= 10)
                {
                    if (userGuessINT < secretNumber)
                    {
                        Console.WriteLine("My secret number is greater !");
                    }
                    else if (userGuessINT > secretNumber)
                    {
                        Console.WriteLine("My secret number is smaller !");
                    }
                    else
                    {
                        Console.WriteLine("Yay, you guessed my secret number !");
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter a valid number between 1 and 10");
                }
            }

        }

        public void exercise2()
        {
            Console.WriteLine("Welcome, I will try to count unique values entered by you, press x and enter to end");
            HashSet<int> uniqueNumbers = new HashSet<int>();
            string enteredNumber = Console.ReadLine();
            while (enteredNumber != "x")
            {
                Console.WriteLine("Enter the number: ");
                if (int.TryParse(enteredNumber, out int enteredNumberINT))
                {
                    uniqueNumbers.Add(enteredNumberINT);
                    Console.WriteLine("I own " + uniqueNumbers.Count + " elements for now.");
                }
                else
                {
                    Console.WriteLine("Please, enter a number !");
                }
                enteredNumber = Console.ReadLine();
            }
            Console.WriteLine("You ended with " + uniqueNumbers.Count + " elements");
        }

        public void exercise3()
        {
            while (true)
            {
                Console.WriteLine("Please, enter binary number:");
                int countBinaryHoles = 0;
                string enteredBinaryNymber = Console.ReadLine();
                String trimmedBinaryNumber = enteredBinaryNymber.Trim('0');

                bool inHole = false;

                foreach (char digit in trimmedBinaryNumber)
                {
                    if (digit == '1')
                    {
                        if (inHole)
                        {
                            inHole = false;
                        }
                    }
                    else if (digit == '0')
                    {
                        if (!inHole)
                        {
                            countBinaryHoles++;
                            inHole = true;
                        }
                    }
                }
                Console.WriteLine("Your number got " + countBinaryHoles + " binary holes.");
            }
        }

        public void exercise4()
        {
            Console.WriteLine("Give me elements of set A, separate elements with space:");
            string[] elementOfA = Console.ReadLine().Split(' ');
            HashSet<string> setA = new HashSet<string>(elementOfA);

            Console.WriteLine("Give me elements of set B, separate elements with space:");
            string[] elementOfB = Console.ReadLine().Split(' ');
            HashSet<string> setB = new HashSet<string>(elementOfB);
            
            HashSet<string> unionAB = new HashSet<string>(setA);
            unionAB.UnionWith(setB);

            HashSet<string> differenceAB = new HashSet<string>(setA);
            differenceAB.ExceptWith(setB);

            HashSet<string> intersectionAB=new HashSet<string>(setA);
            intersectionAB.IntersectWith(setB);

            HashSet<string> symmetricDifferenceAB = new HashSet<string>(setA);
            symmetricDifferenceAB.SymmetricExceptWith(setB);
            Console.WriteLine("------------------->");
            Console.WriteLine("A u B:");
            showSet(unionAB);
            Console.WriteLine("------------------->");
            Console.WriteLine("A n B:");
            showSet(intersectionAB);
            Console.WriteLine("------------------->");
            Console.WriteLine("A - B:");
            showSet(differenceAB);
            Console.WriteLine("------------------->");
            Console.WriteLine("A ÷ B:");
            showSet(symmetricDifferenceAB);
        }

        static void showSet(HashSet<string> zbior)
        {
            foreach (string element in zbior)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        public bool isNumberPrime(int enteredNumberINT)
        {
            if (enteredNumberINT < 2)
            {
                return false;
            }
            for (int i = 2; i * i <= enteredNumberINT; i++)
            {
                if (enteredNumberINT % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public void exercise5()
        {
            Console.WriteLine("I will check if your number is prime!");

            Console.WriteLine("Number(enter X to exit):");
            string enteredNumber = Console.ReadLine();
            while (enteredNumber != "x")
            {
                if (int.TryParse(enteredNumber, out int enteredNumberINT))
                {
                    if (isNumberPrime(enteredNumberINT)) Console.WriteLine("Your number is prime number !");
                    else Console.WriteLine("Your number is not prime number !");
                }
                else
                {
                    Console.WriteLine("Please, enter a valid number!");
                }
                enteredNumber = Console.ReadLine();
            }
        }
    }
}