using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]// se reemplaza por Game
public class GameController : ControllerBase
{
    private readonly GameService gameService;

    public GameController(GameService _gameService)
    {
        gameService = _gameService;
    }

    [HttpGet("start")]
    public IActionResult StartGame()
    {
        gameService.StartNewGame();
        return Ok(new { message = "Game Started", guessedWord = gameService.GetGuessedWord(), hintsLeft = gameService.GetHintsLeft() });
    }

    [HttpGet("status")]
    public IActionResult GetGameStatus()
    {
        return Ok(new { message = "Game Status", guessedWord = gameService.GetGuessedWord(), hintsLeft = gameService.GetHintsLeft() });
    }

   [HttpPost("guess")]
public IActionResult GuessWord([FromBody] GuessRequest guessRequest)
{
    char letter = guessRequest.Letter;
    bool success = gameService.ProcessGuess(letter);
    if (gameService.IsGameWon())
    {
        return Ok(new { message = "Congratulations, you've won!", guessedWord = gameService.GetGuessedWord() });
    }
    if (gameService.IsGameOver())
    {
        return Ok(new { message = "Game Over", secretWord = gameService.GetSecretWord() });
    }
    if (success)
    {
        return Ok(new { message = "Good guess", guessedWord = gameService.GetGuessedWord(), attemptsLeft = gameService.GetAttemptsLeft() });
    }
    else
    {
        return Ok(new { message = "Incorrect guess", guessedWord = gameService.GetGuessedWord(), attemptsLeft = gameService.GetAttemptsLeft() });
    }
}

public class GuessRequest
{
    public char Letter { get; set; }
}

    [HttpGet("hint")]
    public IActionResult GetHint()
    {
        if (gameService.GetHintsLeft() > 0)
        {
            gameService.UseHint();
            return Ok(new { message = "Hint", hint = gameService.GetSecretDescription(), hintsLeft = gameService.GetHintsLeft() });
        }
        else
        {
            return Ok(new { message = "No hints left" });
        }
    }
}
