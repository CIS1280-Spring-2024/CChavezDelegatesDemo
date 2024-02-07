using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace CChavezDelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Header();
                do
                {
                    //  3.3.Inside of the Main method add the following:
                    //  Get a line of text to convert
                    Console.Write($"\n{PROFFNAME}, please enter some text: ");
                    String text = Console.ReadLine();
                    string lText = text.ToLower();
                    if (lText == "some text")
                    {
                        Console.WriteLine("\nVery funny Groucho...\n\n");
                    }
                    //  Instantiate three delegate objects            
                    DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
                    DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
                    DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

                    //  Call them one after the other
                    saying1(text);
                    saying2(text);
                    saying3(text);

                    //  3.4.Run the program. Notice that Capitalize, LowerCased and Writeline are called using the delegates. 
                    Console.Write($"\nNotice that Capitalize, LowerCased and Writeline are called using the delegates.\n\n{PROFFNAME}, press any key to contine.");
                    Console.ReadKey();
                    //  4.1.Add the following code to Main():
                    //  Get another text line
                    Console.Write($"\n\n{PROFFNAME}, please enter some text: ");
                    text = Console.ReadLine();
                    lText = text.ToLower();
                    if (lText == "some text")
                    {
                        Console.WriteLine("\nVery funny again Groucho...\n\n");
                    }
                    //  Make a new delegate object and concatenate delegates
                    DispStrDelegate sayings = new DispStrDelegate(Capitalize);
                    sayings += new DispStrDelegate(LowerCased);
                    sayings += new DispStrDelegate(Console.WriteLine);

                    //  Call the one delegate and run all three methods
                    Console.WriteLine("\nRunning multi cast directly: ");
                    sayings(text);

                    //  4.2.Run the program. Notice that Capitalize, LowerCased and Writeline are called using the just one delegate now!
                    Console.Write($"\nNotice that Capitalize, LowerCased and Writeline are called using the just one delegate now!\n{PROFFNAME}, press any key to contine.");
                    Console.ReadKey();
                    //  5.2.Add the following to Main():
                    //  Pass delegate as a method argument
                    Console.WriteLine("Running by passing delegate to another method: ");
                    RunMyDelegate(sayings, text);

                    //  Run the program.Notice that the sayings delegate is passed to RunMyDelegate and is run by it.
                    Console.Write($"\n{PROFFNAME}, press any key to contine.");
                    Console.ReadKey();

                    //  6.1.Add the following to Main():
                    //  Create and run a lambda expression
                    Console.WriteLine("\nRunning by passing in a lambda expression: ");
                    RunMyDelegate((string t) => { Console.WriteLine("Lambda: " + t); }, text);

                    //  6.2.Run the program. Notice that the Lambda expression is passed in as a delegate and runs.
                    Console.Write($"\nNotice that the Lambda expression is passed in as a delegate and runs.\n{PROFFNAME}, press any key to contine.");
                    Console.ReadKey();
                    //  6.3.Try the following variations on delegate syntax:
                    //  Remove the type and let it be infered
                    Console.WriteLine("\nLambda without type: ");
                    RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

                    //  Remove the parenthesis
                    Console.WriteLine("\nLambda without parenthesis: ");
                    RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);

                    //  6.4.	Notice that they all work the same.
                    Console.Write($"\nNotice that they all work the same.\n{PROFFNAME}, press any key to contine.");
                    Console.ReadKey();
                    //  6.5.Try the following:
                    //  Add a lambda expression to our delegate
                    sayings += t => { Console.WriteLine("Lambda3: " + t); };
                    Console.WriteLine("\nThree Delegates and a lambda: ");
                    RunMyDelegate(sayings, text);

                    //  6.6.Notice that you can add a lambda to a multicast delegate and it also works.

                    //  Array and List<T>.Find(Predicate<T>) Method
                    //  using lambda expresions in a find
                    string[] firstWord = { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
                    List <string> allWords = new List<string>{ "Sphinx", "of", "black", "Quartz","Judge","my","vow" };
                    //  Find method syntaxt with array
                    

                    string result = Array.Find(firstWord, HasMoreThanThreeChars);
                    Console.WriteLine($"{result}");
                    Console.Write($"\nNotice the output of the .Find method with an array\n{PROFFNAME}, press any key to contine.\n\n");
                    Console.ReadKey();

                    //  Find All method syntaxt with List
                    List<string> results = allWords.FindAll(s => s.Length > 3); 
                    foreach (var word in results)
                    {
                        Console.WriteLine($"{word}");
                    }
                    Console.Write($"\nNotice the output of the .FindAll method with a List \n{PROFFNAME}, press any key to contine.\n\n");
                    Console.ReadKey();
                } while (DoAnother());
            }
            catch
            {
                Console.WriteLine("\nAn error has occured");
            }
            Goodbye();

        }


        //  3.1.	Inside of program.cs add the following delegate definition inside of the program class:
        //  Delegate signature is return string, no arguments
        //  Lecture Notes: Delegate declatarion
        delegate void DispStrDelegate(string param);
        //  3.2.	Add the following method definitions:
        //  Method that capatilizes a string.
        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capatilized --> " + text.ToUpper());
        }

        // Method that lower cases a string.
        static void LowerCased(string text)
        {
            Console.WriteLine("Your input lower cased --> " + text.ToLower());
        }

        //  5.1.	 Add the following method to the program class:
        //  Method that takes a delegate as an argument
        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }

        // Lecture notes
        static bool HasMoreThanThreeChars(string s)
        {
            return s.Length > 3;
        }

        // Stock C# class program running utilities

        const string PROGNAME = "CChavezDelegatesDemo";
        const string PROGBY = "Colby Chavez";
        const string CLASSNAME = "NET I/C SHARP (U01)";
        const string PROFFNAME = "Rob Garner";

        static bool DoAnother()
        {
            Console.WriteLine($"{PROFFNAME}, Do you want loop {PROGNAME} again? (y/n): ");
            string? answer = Console.ReadLine();
            if (string.IsNullOrEmpty(answer))
            {
                return false;
            }
            return answer.ToLower()[0] == 'y';
        }
    

        static void Header()
        {
            Console.WriteLine($"\nClass Header: {CLASSNAME} \nProgramed by: {PROGBY}\nEmail:cchavez572@cnm.edu\nProgram name: {PROGNAME}Program goal: Demo of delegates \n\n");

        }
        static void Goodbye()
        {
            Console.WriteLine($"\nThank you for grading {PROGNAME}, {PROFFNAME}. Have a nice day. \n\n");
        }
    }
}
