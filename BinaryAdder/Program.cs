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
                        Console.WriteLine("Nur 1 und 0 sind in Binärzahlen erlaubt!");
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
        /// Takes two binary numbers as strings and makes an addition with them.
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns>A string with the result of the binary addition</returns>
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

            //Building of the result string
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                if (increaseNextDigit)
                {
                    if(number1[i] == '1' && number2[i] == '1')
                    {
                        result = "1" + result;
                    }
                    else if(number1[i]=='0' && number2[i] == '0')
                    {
                        result = "1" + result;
                        increaseNextDigit = false;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }
                else
                {
                    if (number1[i] == '1' && number2[i] == '1')
                    {
                        result = "0" + result;
                        increaseNextDigit = true;
                    }
                    else if (number1[i] == '0' && number2[i] == '0')
                    {
                        result = "0" + result;
                    }
                    else
                    {
                        result = "1" + result;
                    }
                }
            }

            if (increaseNextDigit)
            {
                result = "1" + result;
            }
            return result;
        }

        /// <summary>
        /// Takes a string as a potential binary number and tries to make 32-bit-integer out of it. If the string is not a binary number the function returns zero.
        /// </summary>
        /// <param name="binaryNumber"></param>
        /// <returns>The integer value of the given binary number</returns>
        public static int ConvertBinaryNumberToInt32(string binaryNumber)
        {
            int result = 0, power = 2;

            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] < '0' || binaryNumber[i] > '1')
                {
                    result = 0;
                    break;
                }
                else if (binaryNumber[i] == '1' && i < binaryNumber.Length - 1)
                {
                    power = 2;
                    for (int j = 0; j < binaryNumber.Length-2-i; j++)
                    {
                        power *= 2;
                    }
                    result += power;
                }
                else if (binaryNumber[i] == '1' && i == binaryNumber.Length - 1)
                {
                    result += 1;
                }
            }
            return result;
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Binäraddierer");
            Console.WriteLine("=============");

            string binaryNumberOne = ReadBinaryNumber(1);
            string binaryNumberTwo = ReadBinaryNumber(2);
            string binaryNumberResult = AddBigBinaries(binaryNumberOne, binaryNumberTwo);
            Console.WriteLine("Addition im Binärsystem:");
            Console.WriteLine("{0} + {1} = {2}",binaryNumberOne,binaryNumberTwo,binaryNumberResult);
            Console.WriteLine();
            Console.WriteLine("Addition im Dezimalsystem:");
            Console.WriteLine("{0} + {1} = {2}", ConvertBinaryNumberToInt32(binaryNumberOne), ConvertBinaryNumberToInt32(binaryNumberTwo), ConvertBinaryNumberToInt32(binaryNumberResult));
        }
    }
}
