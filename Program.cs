// See https://aka.ms/new-console-template for more information
using System;
using System.Net.NetworkInformation;
//Console.WriteLine("Hello, World oop!");

class MainClass
{
    public static void Main(string[] args)
    {
      Messages.ShowWelcome();
      Messages.ShowRules();

      //  Console.WriteLine("Hello World!");


        welcome welcome = new welcome();
        welcome.show();

    }
}