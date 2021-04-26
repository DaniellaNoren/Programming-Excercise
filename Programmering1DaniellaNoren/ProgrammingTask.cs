using System;
using System.IO;

namespace Programmering1DaniellaNoren
{ 
    public delegate void DoSomething();

    class ProgrammingTask
    {
       
        static void Main(string[] args)
        {
            var Menu = CreateMenu();
            ReadMenu(Menu);
        }

        static void GetUserInfo()
        {
            Console.WriteLine("First name?");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name?");
            string lastName = Console.ReadLine();
            Console.WriteLine("Age?");
            string age = Console.ReadLine();

            Console.WriteLine("Your name is {0} {1} and you are {2} years old.", firstName, lastName, age);
        }

        private static readonly ConsoleColor DEFAULT_COLOR = ConsoleColor.Gray;
        private static void ChangeConsoleColor()
        {
            if (Console.ForegroundColor == DEFAULT_COLOR)
            {
                Random r = new Random();
                Console.ForegroundColor = (ConsoleColor) r.Next(8, 15);
            }
            else
                Console.ForegroundColor = DEFAULT_COLOR;
        }

        private static void PrintTodaysDate()
        {
            Console.WriteLine("Todays date is " + GetTodaysDate());
        }

        private static string GetTodaysDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        private static void PrintBiggestNumber()
        {
            Console.WriteLine("Type a number: ");
            int number1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Type another number: ");
            int number2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Bigger number: " + GetBiggestNumber(number1, number2));
        }

        private static int GetBiggestNumber(int nr1, int nr2)
        {
            return Math.Max(nr1, nr2);
        }
        private static void GuessingGame()
        {
            Random r = new Random();
            int randomNumber = r.Next(1, 100);

            int guess = TakeGuess();

            while(guess != randomNumber)
            {
                if (guess > randomNumber)
                    ReactToGuess(2);
                else
                    ReactToGuess(1);
               
                guess = TakeGuess();

            }

            ReactToGuess(0);
        }

        private static int TakeGuess()
        {
            return Int32.Parse(Console.ReadLine());
        }
        private static void ReactToGuess(int guessResult)
        {
            switch (guessResult)
            {
                case 0: Console.WriteLine("Correct"); break;
                case 1: Console.WriteLine("Too low!"); break;
                case 2: Console.WriteLine("Too high!"); break;
            }
        }

        private static readonly string NameOfTextFile = "coolTextFile.txt";
        private static readonly string FilePath = Directory.GetCurrentDirectory() + "//" + NameOfTextFile;

        public static void SaveInputToFile()
        {
            Console.WriteLine("Type something to save to file: ");
            WriteToFile(Console.ReadLine(), FilePath);
            Console.WriteLine("File saved at " + FilePath);
        }

        public static void WriteToFile(string content, string filePath)
        {
            File.WriteAllText(FilePath, content);
        }

     
        public static void ReadFromFile()
        {
            Console.WriteLine("Reading from file: ");
            Console.WriteLine(GetTextFromFile(FilePath));
        }

        public static string GetTextFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static void NumberManipulation()
        {
            Console.WriteLine("Type a number: ");

            double number = Double.Parse(Console.ReadLine());

            Console.WriteLine("Squared: {0}\nPower of 2: {1}\nPower of 10: {2}", Math.Sqrt(number), number * number, Math.Pow(number, 10));
        }

        public static void PrintNumberTable()
        {
            var nrTable = NumberTable(10);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(nrTable[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static int[,] NumberTable(int to)
        {
            int[,] numberTables = new int[to, to];

            for (int i = 1; i <= to; i++)
            {
                for (int j = 1; j <= to; j++)
                {
                    numberTables[i - 1, j - 1] = i * j; 
                }
            }

            return numberTables;
        }

        private static void FillArrays()
        {
            int[] RandomArray = new int[10];
            int[] SortedArray = new int[10];

            Random r = new Random();

            RandomArray[0] = r.Next(-100, 100);
            SortedArray[0] = RandomArray[0];

            for (int i = 1; i < 10; i++)
            {
                RandomArray[i] = r.Next(-100, 100);
                SortedArray[i] = RandomArray[i];

                if (RandomArray[i] < SortedArray[i - 1])
               
                {
                    int k = i;
                    while (k >= 1 && SortedArray[k] < SortedArray[k - 1])
                    {
                        int temp = SortedArray[k - 1];
                        SortedArray[k - 1] = SortedArray[k];
                        SortedArray[k] = temp;

                        k--;
                    }
    
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write(SortedArray[i] + "\t");
            }

            Console.WriteLine();
        }

       
        private static void CheckForPalindrome() 
        {
            Console.WriteLine("Type a word: ");

            string PossiblePalindrome = Console.ReadLine();

            if(IsAPalindrome(PossiblePalindrome))
                Console.WriteLine("Word is a palindrome");
            else
                Console.WriteLine("Word is not a palindrome");

        }

        private static bool IsAPalindrome(string wordToBeChecked)
        {
            int lengthOfWord = wordToBeChecked.Length;
            wordToBeChecked = wordToBeChecked.ToLower();

            if (lengthOfWord % 2 == 0)
            {
                for(int i = 0; i < lengthOfWord; i++)
                {
                    if (wordToBeChecked[i] != wordToBeChecked[lengthOfWord - 1 - i])
                        return false;
                }
            }
            else return false;

            return true;
        }

        private static void PrintNumbersBetweenTwoNumbers()
        {
            Console.WriteLine("Type a number: ");
            int number1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Type a higher number: ");
            int number2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine(GetNumbersBetweenTwoNumbers(number1, number2));
        }

        private static string GetNumbersBetweenTwoNumbers(int number1, int number2)
        {
            string numbers = "";
            for (int i = number1; i <= number2; i++)
            {
               numbers += i + " ";
            }
            return numbers;
        }

        private static void SortAndPrintNumbers()
        {
            Console.WriteLine("Type numbers seperated by a ',' :");

            var numbers = Console.ReadLine().Split(",");
            var intNumbers = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                intNumbers[i] = Int32.Parse(numbers[i]);
            }

            QuickSort(intNumbers, 0, intNumbers.Length - 1);

            string oddNumbers = "";
            string evenNumbers = "";

            for (int i = 0; i < intNumbers.Length; i++)
            {
                if (intNumbers[i] % 2 == 0)
                    evenNumbers += intNumbers[i] + " ";
                else
                    oddNumbers += intNumbers[i] + " ";
            }

            Console.WriteLine("Odd numbes in order: " + oddNumbers);
            Console.WriteLine("Even numbers in order: " + evenNumbers);
           
        }

        private static void AddNumbersConsoleGame()
        {
            Console.WriteLine("Type numbers seperated by a ',' :");
            var numbers = Console.ReadLine().Split(",");

            Console.WriteLine("Sum of numbers: " + AddStringNumbers(numbers)); ;
        }

        private static int AddStringNumbers(string[] arrayOfNumbers)
        {
            int sum = 0;

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                sum += Int32.Parse(arrayOfNumbers[i]);
            }
            
            return sum;
        }

        private static void CreateCharacters()
        {
            Console.WriteLine("Create two characters!");

            Random r = new Random();
            Console.WriteLine("Your name: ");
            Character Hero = new Character(Console.ReadLine(), r.Next(50, 100), r.Next(1, 20), r.Next(1, 20));
            Console.WriteLine("Enemy name: ");
            Character Enemy = new Character(Console.ReadLine(), r.Next(50, 100), r.Next(1, 20), r.Next(1, 20));

            Console.WriteLine(Hero.ToString());
            Console.WriteLine(Enemy.ToString());

        }

        public static void QuickSort(int[] arrayToBeSorted, int low, int high)
        {

            int pivot = arrayToBeSorted[low];

            int i = low;
            int j = high;

            while (i < j)
            {

                while (i <= j && arrayToBeSorted[i] < pivot)
                {
                    i++;
                }
                while (j >= i && arrayToBeSorted[j] > pivot)
                {
                    j--;
                }
                

                if (i < j)
                {
                    int temp = arrayToBeSorted[i];
                    arrayToBeSorted[i] = arrayToBeSorted[j];
                    arrayToBeSorted[j] = temp;

                    if (arrayToBeSorted[i] == pivot && arrayToBeSorted[j] == pivot) i++;
                }

            }

      
            if (low < i - 1)
                QuickSort(arrayToBeSorted, low, i - 1);
            if (high > j + 1)
                QuickSort(arrayToBeSorted, j + 1, high);


        }

        private static void ReadMenu(MenuItem[] MenuItems)
        {
            int Choice = 1;
            while(Choice > 0)
            {
                for(int i = 0; i < 16; i++)
                {
                    Console.WriteLine(i + 1 + ". " + MenuItems[i].MenuText);
                }

                Choice = Int32.Parse(Console.ReadLine());
                
                if(Choice > 0 && Choice <= 16)
                    MenuItems[Choice - 1].MenuAction();
            }
        }

        private static MenuItem[] CreateMenu()
        {
            return new MenuItem[] { 
                new MenuItem("Hello World", () => Console.WriteLine("Hello World!")),
                new MenuItem("User information", () => GetUserInfo()),
                new MenuItem("Change color", () => ChangeConsoleColor()),
                new MenuItem("Todays date", () => PrintTodaysDate()),
                new MenuItem("Compare numbers", () => PrintBiggestNumber()),
                new MenuItem("Guessing game", () => { Console.WriteLine("Guess the number: ");
                                                      GuessingGame(); }),
                new MenuItem("Write to file", () => SaveInputToFile()),
                new MenuItem("Read from file", () => ReadFromFile()),
                new MenuItem("Number math", () => NumberManipulation()),
                new MenuItem("Number tables", () => PrintNumberTable()),
                new MenuItem("Generate and sort Array", () => FillArrays()),
                new MenuItem("Palindrome check", () => CheckForPalindrome()),
                new MenuItem("Print numbers between two numbers", () => PrintNumbersBetweenTwoNumbers()),
                new MenuItem("Sort array and print odd/even numbers", () => SortAndPrintNumbers()),
                new MenuItem("Add numbers", () => AddNumbersConsoleGame()),
                new MenuItem("Create characters", () => CreateCharacters())
            };
        }

       
    }

    class MenuItem
    {
        public string MenuText { get; set; }
        public DoSomething MenuAction { get; set; }

        public MenuItem(string MenuText, DoSomething MenuAction)
        {
            this.MenuText = MenuText;
            this.MenuAction = MenuAction;
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Hp { get; set; }

        public int Strength { get; set; }

        public int Luck { get; set; }

        public Character(string Name, int Hp, int Strength, int Luck)
        {
            this.Name = Name;
            this.Hp = Hp;
            this.Strength = Strength;
            this.Luck = Luck;
        }

        public override string ToString()
        {
            return $"Name: {Name}\tHP: {Hp}\tStrength: {Strength}\tLuck: {Luck}";
        }



    }

    
}
