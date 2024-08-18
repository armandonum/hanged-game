public static class HangmanDisplay
{
    /// <summary>
    /// Draws the hangman based on the number of attempts left.
    /// </summary>
    /// <param name="attemptsLeft">The number of attempts left.</param>
    public static void DrawHangman(int attemptsLeft)
    {
        switch (attemptsLeft)
        {
            case 6:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            case 5:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine(" O   |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            case 4:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine(" O   |");
                Console.WriteLine(" |   |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            case 3:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|   |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            case 2:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            case 1:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/    |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            case 0:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
            default:
                Console.WriteLine(" +---+");
                Console.WriteLine(" |   |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("=====");
                break;
        }
    }
}
