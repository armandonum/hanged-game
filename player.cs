using System.Collections.Generic;

public class Player 
{
    public int AttemptsLeft { get; private set; }
    public List<char> GuessedLetters { get; private set; }

    public Player(int maxAttempts)
    {
        AttemptsLeft = maxAttempts;
        GuessedLetters = new List<char>();
    }

/// <summary>
/// this method add a letter to list 
/// </summary>
/// <param name="letter"></param>
    public void AddGuessedLetter(char letter)
    {
        GuessedLetters.Add(char.ToUpper(letter));
    }

/// <summary>
/// Decrement the number of attempts left
/// </summary>
    public void DecrementAttempts()
    {
        AttemptsLeft--;
    }
}
