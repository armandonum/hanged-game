// using System;

// class Game
// {
//     private string secretWord;
//     private string secretDescription;
//     private string guessedWord;
//     private Player player;
//     private DatabaseHelper databaseHelper;
//     private int hintsLeft;

//     public Game(int maxAttempts, string server, string database, string user, string password)
//     {
//         player = new Player(maxAttempts);
//         databaseHelper = new DatabaseHelper(server, database, user, password);
//         hintsLeft = 2; // Number of hints available
//     }

//     public void Start()
//     {
//         Messages.ShowWelcome();
//         Messages.ShowRules();
//         (secretWord, secretDescription) = databaseHelper.GetRandomWord();
//         if (secretWord == null)
//         {
//             Console.WriteLine("Error: No word found in the database.");
//             return;
//         }
//         guessedWord = new string('_', secretWord.Length);
//         PlayGame();
//     }

//     private void PlayGame()
//     {
//         while (player.AttemptsLeft > 0 && !guessedWord.Equals(secretWord, StringComparison.OrdinalIgnoreCase))
//         {
//             Console.WriteLine("Word: " + guessedWord);
//             Console.WriteLine($"You have {hintsLeft} hints left.");
//             char letter = InputReader.ReadLetter();
//             if (player.GuessedLetters.Contains(letter))
//             {
//                 Messages.letterRepeated();
                
//                 continue;
//             }
//             player.AddGuessedLetter(letter);
//             if (secretWord.IndexOf(letter, StringComparison.OrdinalIgnoreCase) >= 0)
//             {
//                 UpdateGuessedWord(letter);
//                 Messages.ShowSuccess();
//             }
//             else
//             {
//                 player.DecrementAttempts();
//                 Messages.ShowFail(player.AttemptsLeft);
//                 HangmanDisplay.DrawHangman(player.AttemptsLeft);
//                 if (hintsLeft > 0)
//             {
//                 Console.Write("Would you like a hint? (y/n): ");
//                 string hintResponse = Console.ReadLine().ToLower();
//                 if (hintResponse == "y")
//                 {
//                     ProvideHint();
//                     hintsLeft--;
//                 }
//             }
//             }

            
//         }
//         GameFinish();
//     }

//     private void GameFinish()
//     {
//         if (guessedWord.Equals(secretWord, StringComparison.OrdinalIgnoreCase))
//         {
//             Messages.win(secretWord);
//         }
//         else
//         {
//             Messages.lose(secretWord);
//             HangmanDisplay.DrawHangman(0);
//         }
//     }

//     private void UpdateGuessedWord(char letter)
//     {
//         char[] secretChars = secretWord.ToCharArray();
//         char[] guessedChars = guessedWord.ToCharArray();
//         for (int i = 0; i < secretChars.Length; i++)
//         {
//             if (char.ToUpper(secretChars[i]) == char.ToUpper(letter))
//             {
//                 guessedChars[i] = secretChars[i];
//             }
//         }
//         guessedWord = new string(guessedChars);
//     }

//     private void ProvideHint()
//     {
//         Console.WriteLine($"Hint: {secretDescription}");
//     }
// }
