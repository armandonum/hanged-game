using System;
using System.Collections.Generic;

public class GameService
{
    private readonly DatabaseHelper databaseHelper;
    private readonly Dictionary<Guid, GameData> games;

    public GameService(DatabaseHelper dbHelper)
    {
        databaseHelper = dbHelper;
        games = new Dictionary<Guid, GameData>();
    }

    public Guid StartNewGame()
    {
        var wordData = databaseHelper.GetRandomWord();
        var gameId = Guid.NewGuid();
        var newGame = new GameData
        {
            SecretWord = wordData.word ?? string.Empty,
            SecretDescription = wordData.description ?? string.Empty,
            GuessedWord = new string('*', wordData.word?.Length ?? 0),
            AttemptsLeft = 6,
            HintsLeft = 2,
            GuessedLetters = new HashSet<char>()
        };
        games[gameId] = newGame;
        return gameId;
    }

    public bool ProcessGuess(Guid gameId, char letter)
    {
        if (!games.ContainsKey(gameId))
            throw new ArgumentException("Invalid game ID.");

        var game = games[gameId];
        if (game.GuessedLetters.Contains(letter) || string.IsNullOrEmpty(game.SecretWord))
        {
            return false;
        }

        game.GuessedLetters.Add(letter);
        if (game.SecretWord.Contains(letter))
        {
            var newGuessedWord = game.GuessedWord.ToCharArray();
            for (int i = 0; i < game.SecretWord.Length; i++)
            {
                if (game.SecretWord[i] == letter)
                {
                    newGuessedWord[i] = letter;
                }
            }
            game.GuessedWord = new string(newGuessedWord);
            return true;
        }
        else
        {
            game.AttemptsLeft--;
            return false;
        }
    }

    public bool IsGameWon(Guid gameId) => games.ContainsKey(gameId) && games[gameId].GuessedWord.Equals(games[gameId].SecretWord);

    public bool IsGameOver(Guid gameId) => games.ContainsKey(gameId) && games[gameId].AttemptsLeft <= 0;

    public string GetGuessedWord(Guid gameId) => games.ContainsKey(gameId) ? games[gameId].GuessedWord : null;

    public string GetSecretWord(Guid gameId) => games.ContainsKey(gameId) ? games[gameId].SecretWord : null;

    public string GetSecretDescription(Guid gameId) => games.ContainsKey(gameId) ? games[gameId].SecretDescription : null;

    public int GetAttemptsLeft(Guid gameId) => games.ContainsKey(gameId) ? games[gameId].AttemptsLeft : 0;

    public int GetHintsLeft(Guid gameId) => games.ContainsKey(gameId) ? games[gameId].HintsLeft : 0;

    public void UseHint(Guid gameId)
    {
        if (games.ContainsKey(gameId) && games[gameId].HintsLeft > 0)
        {
            games[gameId].HintsLeft--;
        }
    }

    private class GameData
    {
        public string SecretWord { get; set; }
        public string SecretDescription { get; set; }
        public string GuessedWord { get; set; }
        public int AttemptsLeft { get; set; }
        public int HintsLeft { get; set; }
        public HashSet<char> GuessedLetters { get; set; }
    }
}
