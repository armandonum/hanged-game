using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
public static class Messages
{

    /// <summary>
    /// this method show a message of welcome
    /// </summary>
    public static void ShowWelcome()
    {
        Console.WriteLine(" !welcome to the handGame");
        Console.WriteLine(" ADIVINA LA PALABRA");
    }

    /// <summary>
    /// this method show a message of rules of the game 
    /// </summary>
    public static void ShowRules()
    {
        Console.WriteLine("THIS IS A RULES OF GAMES :");
        Console.WriteLine("Select one letter at a time to guess the word. ");
        Console.WriteLine("You have a limited number of attempts. ");
        Console.WriteLine("If you guess the word, you win. ");
        Console.WriteLine("If you run out of attempts, you lose. ");
        Console.WriteLine("*************************************************");

    }
    /// <summary>
    /// this method show a message of success
    /// </summary>
    /// <param name="attemptsLeft">number of attempts</param>
    public static void ShowFail(int attemptsLeft)
    {
        Console.WriteLine("you have {0} attempts left", attemptsLeft);

    }

    /// <summary>
    /// this method show a message of success
    /// </summary>
    public static void ShowSuccess()
    {
        Console.WriteLine(" you have guessed the word");
    }

    /// <summary>
    /// this method show a message of win when you finished of full the letters
    /// </summary>
    /// <param name="secretWord"></param>
    public static void win(string secretWord)
    {
        Console.Write("Congratulations! You guessed the word: " + secretWord);
    }

    /// <summary>
    /// this method show a message of lose when you run out of attempts
    /// </summary>
    /// <param name="secretWord"></param>
    public static void lose(string secretWord)
    {
        Console.WriteLine("Sorry, you ran out of attempts. The word was: " + secretWord);
    }


    /// <summary>
    /// this method show a message of letter repeated when repeat the letter
    /// </summary>
    public static void letterRepeated()
    {
        Console.WriteLine("You already guessed that letter. Try again.");

    }

    public static void  hint()
    {

     Console.Write("Would you like a hint? (y/n): ");
}


}

