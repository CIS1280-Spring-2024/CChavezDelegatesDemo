using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace CChavezDelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Header();
            do 
            {
            //  3.3.Inside of the Main method add the following:
            //  Get a line of text to convert
            Console.Write("Please enter some text: ");
            String text = Console.ReadLine();

            //  Instantiate three delegate objects            
            DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
            DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
            DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

            //Call them one after the other
            saying1(text);
            saying2(text);
            saying3(text);

            //  3.4.Run the program. Notice that Capitalize, LowerCased and Writeline are called using the delegates. 

            //  4.1.Add the following code to Main():
            //  Get another text line
            Console.Write("Please enter some text: ");
            text = Console.ReadLine();

            //Make a new delegate object and concatenate delegates
            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += new DispStrDelegate(LowerCased);
            sayings += new DispStrDelegate(Console.WriteLine);

            //Call the one delegate and run all three methods
            Console.WriteLine("Running multi cast directly: ");
            sayings(text);

            //  4.2.Run the program. Notice that Capitalize, LowerCased and Writeline are called using the just one delegate now!

            //  5.2.Add the following to Main():
            //Pass delegate as a method argument
            Console.WriteLine("Running by passing delegate to another method: ");
            RunMyDelegate(sayings, text);

            //  Run the program.Notice that the sayings delegate is passed to RunMyDelegate and is run by it.

            //  6.1.Add the following to Main():
            //Create and run a lambda expression
            Console.WriteLine("Running by passing in a lambda expression: ");
            RunMyDelegate((string t) => { Console.WriteLine("Lambda: " + t); }, text);

            //  6.2.Run the program. Notice that the Lambda expression is passed in as a delegate and runs.

            //  6.3.Try the following variations on delegate syntax:
            //Remove the type and let it be infered
            Console.WriteLine("Lambda without type: ");
            RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);

            //Remove the parenthesis
            Console.WriteLine("Lambda without parenthesis: ");
            RunMyDelegate(t => { Console.WriteLine("Lambda2: " + t); }, text);

            //  6.4.	Notice that they all work the same.

            //  6.5.Try the following:
            //Add a lambda expression to our delegate
            sayings += t => { Console.WriteLine("Lambda3: " + t); };
            Console.WriteLine("Three Delegates and a lambda: ");
            RunMyDelegate(sayings, text);

            //  6.6.Notice that you can add a lambda to a multicast delegate and it also works.
            }while (DoAnother());
            Goodbye();

        }


        //  3.1.	Inside of program.cs add the following delegate definition inside of the program class:
        //  Delegate signature is return string, no arguments
        delegate void DispStrDelegate(string param);
        //  3.2.	Add the following method definitions:
        // Method that capatilizes a string.
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
        // Method that takes a delegate as an argument
        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }



        // Stock program running utilities

        const string PROGNAME = "CChavezDelegatesDemo";
        static bool DoAnother()
        {
            Console.WriteLine($"Do you want loop {PROGNAME} again? (y/n): ");
            string? answer = Console.ReadLine();
            if (string.IsNullOrEmpty(answer))
            {
                return false;
            }
            return answer.ToLower()[0] == 'y';
        }
    

    static void Header()
        {
            Console.WriteLine($".NET I/C SHARP (U01) Class Header\nProgramed by: Colby Chavez\nEmail:cchavez572@cnm.edu\nProgram name: {PROGNAME}Program goal: Demo of delegates \n\n");

        }
        static void Goodbye()
        {
            Console.WriteLine($"Thank you for grading {PROGNAME}. Have a nice day. \n\n");
        }
    }
}
