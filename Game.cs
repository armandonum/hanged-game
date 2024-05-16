using System.Net.NetworkInformation;

class Game
{

private string secretWord;
private string guessedWord;
private int maxAttempts;
private int attemptsLeft;
private List<char> guessedLetters;

    public  Game(int maxAttempts)

    {
            this.maxAttempts=maxAttempts;
            this.attemptsLeft=maxAttempts;
            this.guessedLetters=new List<char>();
    }
    public void Star()
    {
        Messages.ShowWelcome();
        Messages.ShowRules();
        WordBank wordBank = new WordBank();
        secretWord = wordBank.GetRandomWord().ToUpper();
        guessedWord = new string('_', secretWord.Length);
        PlayGame();
       
    }
        private void PlayGame()
    {
        while (attemptsLeft > 0 && !guessedWord.Equals(secretWord))
        {
            Console.WriteLine("Word: " + guessedWord);
            char letter = InputReader.ReadLetter();
            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("You already guessed that letter. Try again.");
                continue;
            }
            guessedLetters.Add(letter);
            if (secretWord.Contains(letter))
            {
                UpdateGuessedWord(letter);
                Messages.ShowSuccess();
            }
            else
            {
                attemptsLeft--;
                Messages.ShowFail(attemptsLeft);
                HangmanDisplay.DrawHangman(attemptsLeft);
            }
        }
        if (guessedWord.Equals(secretWord))
        {
            Console.WriteLine("Congratulations! You guessed the word: " + secretWord);
        }
        else
        {
            Console.WriteLine("Sorry, you ran out of attempts. The word was: " + secretWord);
            HangmanDisplay.DrawHangman(0);
        }
    }

    private void UpdateGuessedWord(char letter)
    {
        char[] secretChars = secretWord.ToCharArray();
        char[] guessedChars = guessedWord.ToCharArray();
        for (int i = 0; i < secretChars.Length; i++)
        {
            if (secretChars[i] == letter)
            {
                guessedChars[i] = letter;
            }
        }
        guessedWord = new string(guessedChars);
    }
}
 
