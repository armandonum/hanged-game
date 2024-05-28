using System;

public class InputReader
{
    /// <summary>
    /// read a word from the user and return it
    /// </summary>
    /// <returns>The letter entered by the user </returns>
    public static char ReadLetter()
    {
        while (true)
        {
            Console.Write("Enter a letter: ");
            string input = Console.ReadLine();

            if (input.Length != 1)
            {
                Console.WriteLine("Please enter only one letter.");
                continue;
            }

            if (!char.IsLetter(input[0]))
            {
                Console.WriteLine("Please enter a valid letter.");
                continue;
            }

            return char.ToUpper(input[0]);
        }
    }
}
