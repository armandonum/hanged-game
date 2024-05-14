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


    public static void ShowRules ()
    {
        Console.WriteLine("THIS IS A RULES OF GAMES :");

    }

    public static void ShowLoss()
    {
        Console.WriteLine("you loss");
    }

    public static void ShowError(String var)
    {
        Console.WriteLine("created the "+var);
    }


}

