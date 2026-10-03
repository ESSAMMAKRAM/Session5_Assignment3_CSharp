using System;

namespace Assignment4
{
    #region Enums & Structs Definitions

    // Part 02 - Q1: WeekDays Enum
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    // Part 02 - Q2 & Q7: Person Struct
    struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    // Part 02 - Q3: Season Enum
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    // Part 02 - Q4: Permissions Enum (Bitwise / Flags)
    [Flags]
    enum Permissions : byte
    {
        None = 0,
        Read = 1,      // 0001
        Write = 2,     // 0010
        Delete = 4,    // 0100
        Execute = 8    // 1000
    }

    // Part 02 - Q5: Colors Enum
    enum Colors
    {
        Red,
        Green,
        Blue
    }

    // Part 02 - Q6: Point Struct
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("      DEPI - C# Assignment 04 Solutions           ");
            Console.WriteLine("==================================================\n");

            #region Part 01 - Functions Testing

            Console.WriteLine("--- Part 01: Functions ---\n");

            // Q1: Value Type Passing
            Console.WriteLine("1. Passing Value Types (Value vs Ref):");
            int numA = 5, numB = 10;
            SwapByValue(numA, numB);
            Console.WriteLine($"   After SwapByValue: a = {numA}, b = {numB}");
            SwapByRef(ref numA, ref numB);
            Console.WriteLine($"   After SwapByRef:   a = {numA}, b = {numB}\n");

            // Q2: Reference Type Passing
            Console.WriteLine("2. Passing Reference Types (Value vs Ref):");
            int[] arr1 = { 1, 2, 3 };
            ModifyArrayByValue(arr1);
            Console.WriteLine($"   After ModifyArrayByValue (Index 0): {arr1[0]}");
            int[] arr2 = { 1, 2, 3 };
            ModifyArrayByRef(ref arr2);
            Console.WriteLine($"   After ModifyArrayByRef   (Index 0): {arr2[0]}\n");

            // Q3: Summation and Subtraction
            Console.WriteLine("3. Summation & Subtraction:");
            Calculate(15, 5, out int sum, out int sub);
            Console.WriteLine($"   Numbers (15, 5) -> Sum: {sum}, Subtraction: {sub}\n");

            // Q4: Sum of Digits
            Console.WriteLine("4. Sum of Individual Digits:");
            int testNum = 25;
            Console.WriteLine($"   The sum of the digits of {testNum} is: {SumOfDigits(testNum)}\n");

            // Q5: IsPrime Function
            Console.WriteLine("5. Prime Number Check:");
            int primeCandidate = 17;
            Console.WriteLine($"   Is {primeCandidate} Prime? {IsPrime(primeCandidate)}\n");

            // Q6: MinMaxArray Function
            Console.WriteLine("6. Min & Max in Array:");
            int[] sampleArr = { 12, 5, 87, 1, 43, 99, 23 };
            int minVal = 0, maxVal = 0;
            MinMaxArray(sampleArr, ref minVal, ref maxVal);
            Console.WriteLine($"   Array: [{string.Join(", ", sampleArr)}]");
            Console.WriteLine($"   Min: {minVal}, Max: {maxVal}\n");

            // Q7: Factorial Calculation
            Console.WriteLine("7. Factorial (Iterative):");
            int factNum = 5;
            Console.WriteLine($"   Factorial of {factNum} = {CalculateFactorial(factNum)}\n");

            // Q8: ChangeChar Function
            Console.WriteLine("8. Replace Character in String:");
            string originalText = "Hello World";
            string updatedText = ChangeChar(originalText, 6, 'W');
            Console.WriteLine($"   Original: {originalText} -> Updated: {updatedText}\n");

            #endregion

            #region Part 02 - Enum and Struct Testing

            Console.WriteLine("--- Part 02: Enum and Struct ---\n");

            // Q1: Print WeekDays
            Console.WriteLine("1. Days of the Week (Enum):");
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine($"   - {day}");
            }
            Console.WriteLine();

            // Q2: Person Struct Array
            Console.WriteLine("2. Persons Array Details (Struct):");
            Person[] personsList = new Person[3]
            {
                new Person("Essam", 22),
                new Person("Ahmed", 25),
                new Person("Mina", 28)
            };
            foreach (var p in personsList)
            {
                Console.WriteLine($"   Name: {p.Name}, Age: {p.Age}");
            }
            Console.WriteLine();

            // Q3: Season Month Range
            Console.WriteLine("3. Season Month Range:");
            DisplaySeasonRange(Season.Summer);
            Console.WriteLine();

            // Q4: Enum Permissions Flags
            Console.WriteLine("4. Permissions Operations (Bitwise Enum):");
            Permissions myPerms = Permissions.None;
            myPerms |= Permissions.Read;
            myPerms |= Permissions.Write;
            Console.WriteLine($"   Added Read & Write: {myPerms}");
            bool hasRead = (myPerms & Permissions.Read) == Permissions.Read;
            Console.WriteLine($"   Has Read Permission? {hasRead}");
            myPerms &= ~Permissions.Write;
            Console.WriteLine($"   Removed Write Permission: {myPerms}\n");

            // Q5: Primary Color Check
            Console.WriteLine("5. Primary Color Check:");
            CheckPrimaryColor("Green");
            CheckPrimaryColor("Yellow");
            Console.WriteLine();

            // Q6: Distance Between 2 Points
            Console.WriteLine("6. Distance Between Two 2D Points:");
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);
            double dist = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"   Distance between (0,0) and (3,4) = {dist}\n");

            // Q7: Oldest Person
            Console.WriteLine("7. Find Oldest Person:");
            Person oldest = personsList[0];
            for (int i = 1; i < personsList.Length; i++)
            {
                if (personsList[i].Age > oldest.Age)
                {
                    oldest = personsList[i];
                }
            }
            Console.WriteLine($"   Oldest Person: {oldest.Name} ({oldest.Age} years old)\n");

            #endregion
        }

        #region Part 01 - Functions Logic Implementation

        // Q1: Value Type (Passing by Value vs Ref)
        public static void SwapByValue(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void SwapByRef(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // Q2: Reference Type (Passing by Value vs Ref)
        public static void ModifyArrayByValue(int[] arr)
        {
            arr[0] = 99;
            arr = new int[] { 100, 200, 300 };
        }

        public static void ModifyArrayByRef(ref int[] arr)
        {
            arr[0] = 99;
            arr = new int[] { 100, 200, 300 };
        }

        // Q3: Summation & Subtraction Function
        public static void Calculate(int num1, int num2, out int sum, out int sub)
        {
            sum = num1 + num2;
            sub = num1 - num2;
        }

        // Q4: Sum of Digits Function
        public static int SumOfDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        // Q5: IsPrime Function
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Q6: MinMaxArray Function
        public static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            if (arr == null || arr.Length == 0) return;

            min = arr[0];
            max = arr[0];

            foreach (int item in arr)
            {
                if (item < min) min = item;
                if (item > max) max = item;
            }
        }

        // Q7: Calculate Factorial (Iterative)
        public static long CalculateFactorial(int number)
        {
            if (number < 0) throw new ArgumentException("Factorial is undefined for negative numbers.");
            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        // Q8: ChangeChar Function
        public static string ChangeChar(string str, int index, char newChar)
        {
            if (string.IsNullOrEmpty(str)) return str;
            if (index < 0 || index >= str.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            char[] chars = str.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

        #endregion

        #region Part 02 - Helper Methods

        // Part 02 - Q3 Helper
        public static void DisplaySeasonRange(Season season)
        {
            switch (season)
            {
                case Season.Spring:
                    Console.WriteLine("   Spring range: March to May");
                    break;
                case Season.Summer:
                    Console.WriteLine("   Summer range: June to August");
                    break;
                case Season.Autumn:
                    Console.WriteLine("   Autumn range: September to November");
                    break;
                case Season.Winter:
                    Console.WriteLine("   Winter range: December to February");
                    break;
            }
        }

        // Part 02 - Q5 Helper
        public static void CheckPrimaryColor(string inputColor)
        {
            if (Enum.TryParse(inputColor, true, out Colors color))
            {
                Console.WriteLine($"   '{inputColor}' IS a primary color ({color}).");
            }
            else
            {
                Console.WriteLine($"   '{inputColor}' IS NOT a primary color.");
            }
        }

        #endregion
    }
}
