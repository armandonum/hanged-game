using System;
using System.Collections.Generic;


public class GameService
{
    private readonly DatabaseHelper databaseHelper;
    private string secretWord;
    private string secretDescription;
    private string guessedWord;
    private int attemptsLeft;
    private int hintsLeft;
    private HashSet<char> guessedLetters;
    //private Player player;

    public GameService(DatabaseHelper databaseHelper)
    {
        this.databaseHelper = databaseHelper;
        //hintsLeft = 2;
       //guessedLetters = new HashSet<char>();
       StarNewGame();
       
    }

    public void StarNewGame()
    {
        (secretWord, secretDescription) = databaseHelper.GetRandomWord();
        guessedWord=new string('*',secretWord.Length);
        attemptsLeft = 7;
        hintsLeft = 2;
        guessedLetters.Clear();
    }



    public string GetGuesseWord()=>guessedWord;
    public string GetSecretDescription()=>secretDescription;
    public int GetAttemptsLeft()=>attemptsLeft;
    public int GetHintsLeft()=>hintsLeft;


    public bool ProcessGuesess(char letter)
    {
        if(guessedLetters.Contains(letter))
        {
            return false;
        }

        guessedLetters.Add(letter);

        if(secretWord.IndexOf(letter,StringComparison.OrdinalIgnoreCase)>=0)
        {
            UpdateGuessedWord(letter);
            return true;
        }
        else
        {
            attemptsLeft--;
            return false;
        }
    }

    public void UpdateGuessedWord(char letter)
    {
        char[] secretChars=secretWord.ToCharArray();
        char[] guessedChars=guessedWord.ToCharArray();
        for(int i=0 ; i<secretChars.Length;i++)
        {
            if(char.ToUpper(secretChars[i])==char.ToUpper(letter))

            {
                guessedChars[i]=secretChars[i];
            }
        }
        guessedWord=new string(guessedChars);
    }

    public bool IsGameWon()=>guessedWord.Equals(secretWord,StringComparison.OrdinalIgnoreCase);
    public bool IsGameOver()=>attemptsLeft==0;
    public void UseHint()=>hintsLeft--;

}