public class GameService
{
    private readonly DatabaseHelper databaseHelper;
    private string secretWord;
    private string secretDescription;
    private string guessedWord;
    private int attemptsLeft;
    private int hintsLeft;
    private HashSet<char> guessedLetters;

    public GameService(DatabaseHelper dbHelper)
    {
        databaseHelper = dbHelper;
        guessedLetters = new HashSet<char>();
    }

    public void StartNewGame()
    {
        var wordData = databaseHelper.GetRandomWord();
       //var secredWord=databaseHelper.GetRandomWord();
        
        secretWord = wordData.word ?? string.Empty;
        secretDescription = wordData.description ?? string.Empty;
        guessedWord = new string('*', secretWord.Length);
        attemptsLeft = 6; 
        hintsLeft = 2; 
        guessedLetters.Clear();
    }

    public bool ProcessGuess(char letter)
    {
        if (guessedLetters.Contains(letter) || string.IsNullOrEmpty(secretWord))
        {
            return false;
        }

        guessedLetters.Add(letter);
        if (secretWord.Contains(letter))
        {
            var newGuessedWord = guessedWord.ToCharArray();
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == letter)
                {
                    newGuessedWord[i] = letter;
                }
            }
            guessedWord = new string(newGuessedWord);
            return true;
        }
        else
        {
            attemptsLeft--;
            return false;
        }
    }

    public bool IsGameWon() => guessedWord.Equals(secretWord);

    public bool IsGameOver() => attemptsLeft <= 0;

    public string GetGuessedWord() => guessedWord;

    public string GetSecretWord() => secretWord;

    public string GetSecretDescription() => secretDescription;

    public int GetAttemptsLeft() => attemptsLeft;

    public int GetHintsLeft() => hintsLeft;

    public void UseHint()
    {
        if (hintsLeft > 0)
        {
            hintsLeft--;
        }
    }
}
