using System;

class Game
{
    private string secretWord;
    private string secretDescription;
    private  string guessedWord;
    private Player player;
    private DatabaseHelper databaseHelper;
    private int hintsLeft;
string server, database, user, password;
    public Game(int maxAttempts)
    { 
        conection(out server, out database, out user, out password);
        player = new Player(maxAttempts);
        //databaseHelper = new DatabaseHelper(server, database, user, password);
        hintsLeft = 2; 
    }

    private static void conection(out string server, out string database, out string user, out string password)
    {
        server = "localhost";
        database = "hangman_db";
        user = "root";
        password = "";
        
    }

    public void Start()
    {
        Messages.ShowWelcome();
        Messages.ShowRules();
        (secretWord, secretDescription) = databaseHelper.GetRandomWord();
        if (secretWord == null)
        {
            Console.WriteLine("Error: No word found in the database.");
            return;
        }
        guessedWord = new string('*', secretWord.Length);
        PlayGame();
    }

    private void PlayGame()
    {
        while (player.AttemptsLeft > 0 && !guessedWord.Equals(secretWord, StringComparison.OrdinalIgnoreCase))
        {
            DisplayGameStatus();
            char letter = InputReader.ReadLetter();
            if (player.GuessedLetters.Contains(letter))
            {
                Messages.letterRepeated();
                continue;
            }
            ProcessGussedLetter(letter);
        }
        GameFinish();
    }

    private void ProcessGussedLetter(char letter)
    {
        player.AddGuessedLetter(letter);
        if (secretWord.IndexOf(letter, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            UpdateGuessedWord(letter);
            Messages.ShowSuccess();
        }
        else
        {
            player.DecrementAttempts();
            Messages.ShowFail(player.AttemptsLeft);
            HangmanDisplay.DrawHangman(player.AttemptsLeft);
            if (hintsLeft > 0 &&AskForHint() )
            {
                    ProvideHint();
                    hintsLeft--;
            }
        }
    }

    private bool AskForHint(){
       Messages.hint();
       char option = InputReader.ReadLetter();
        return option.ToString().Trim().ToLower() == "y";
    }

    public void DisplayGameStatus()
    {
        Console.WriteLine("Word: " + guessedWord);
        Console.WriteLine($"You have {hintsLeft} hints left.");
    }

    private void GameFinish()
    {
        if (guessedWord.Equals(secretWord, StringComparison.OrdinalIgnoreCase))
        {
            Messages.win(secretWord);
        }
        else
        {
            Messages.lose(secretWord);
            HangmanDisplay.DrawHangman(0);
        }
    }

    private void UpdateGuessedWord(char letter)
    {
        char[] secretChars = secretWord.ToCharArray();
        char[] guessedChars = guessedWord.ToCharArray();
        for (int i = 0; i < secretChars.Length; i++)
        {
            if (char.ToUpper(secretChars[i]) == char.ToUpper(letter))
            {
                guessedChars[i] = secretChars[i];
            }
        }
        guessedWord = new string(guessedChars);
    }

    private void ProvideHint()
    {
        Console.WriteLine($"Hint: {secretDescription}");
    }


}
