using System;

namespace BinaryAdder
{
    class Program
    {

        /// <summary>
        /// Asks for an Input-String and checks if it is a binary number or not, when not a new number is prompted
        /// </summary>
        /// <param name="counter">Number of input</param>
        /// <returns>The Input-String</returns>
        public static string ReadBinaryNumber(int counter)
        {
            string inputNumber;
            bool isNumber;

            do
            {
                Console.Write("Geben Sie die {0}. Dualzahl ein: ", counter);
                inputNumber = Console.ReadLine();
                isNumber = true;

                for (int i = 0; i < inputNumber.Length; i++)
                {
                    if (inputNumber[i] < '0' || inputNumber[i] > '1')
                    {
                        isNumber = false;
                        break;
                    }
                }
            } while (!isNumber);

            return inputNumber;
        }

        /// <summary>
        /// Takes an Input-String and adds a specified character a named number of times at the lead
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="character"></param>
        /// <param name="numberOfTimes"></param>
        /// <returns>The new string with the leading characters</returns>
        public static string AddLeadingChars(string inputString, string character, int numberOfTimes)
        {
            string outputString = "";

            for (int i = 0; i < numberOfTimes; i++)
            {
                outputString += character;
            }

            outputString += inputString;

            return outputString;
        }

        /// <summary>
        /// Takes two integer numbers as strings and makes an addition with them.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>A string with the result of the integer addition</returns>
        public static string AddBigBinaries(string number1, string number2)
        {
            string result = "";
            bool increaseNextDigit = false;


            //Adds leading zeros if needed
            if (number1.Length != number2.Length)
            {
                int timesToAddZero = number1.Length - number2.Length;
                if (timesToAddZero < 0)
                {
                    timesToAddZero *= -1;
                    number1 = AddLeadingChars(number1, "0", timesToAddZero);
                }
                else
                {
                    number2 = AddLeadingChars(number2, "0", timesToAddZero);
                }
            }

            //TODO Umschreiben auf Dualzahl
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                
            }

            return result;
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
