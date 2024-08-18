using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
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
        var gameId = gameService.StartNewGame();
        return Ok(new { message = "Game Started", gameId, guessedWord = gameService.GetGuessedWord(gameId), hintsLeft = gameService.GetHintsLeft(gameId) });
    }

    [HttpGet("status/{gameId}")]
    public IActionResult GetGameStatus(Guid gameId)
    {
        return Ok(new { message = "Game Status", guessedWord = gameService.GetGuessedWord(gameId), hintsLeft = gameService.GetHintsLeft(gameId), attemptsLeft = gameService.GetAttemptsLeft(gameId),secretWord=gameService.GetSecretWord(gameId)});
    }

    [HttpPost("guess/{gameId}")]
    public IActionResult GuessWord(Guid gameId, [FromBody] GuessRequest guessRequest)
    {
        char letter = guessRequest.Letter;
        bool success = gameService.ProcessGuess(gameId, letter);
        if (gameService.IsGameWon(gameId))
        {
            return Ok(new { message = "Congratulations, you've won!", guessedWord = gameService.GetGuessedWord(gameId) });
        }
        if (gameService.IsGameOver(gameId))
        {
            return Ok(new { message = "Game Over", secretWord = gameService.GetSecretWord(gameId) });
        }
        if (success)
        {
            return Ok(new { message = "Good guess", guessedWord = gameService.GetGuessedWord(gameId), attemptsLeft = gameService.GetAttemptsLeft(gameId) });
        }
        else
        {
            return Ok(new { message = "Incorrect guess", guessedWord = gameService.GetGuessedWord(gameId), attemptsLeft = gameService.GetAttemptsLeft(gameId) });
        }
    }

    [HttpGet("hint/{gameId}")]
    public IActionResult GetHint(Guid gameId)
    {
        if (gameService.GetHintsLeft(gameId) > 0)
        {
            gameService.UseHint(gameId);
            return Ok(new { message = "Hint", hint = gameService.GetSecretDescription(gameId), hintsLeft = gameService.GetHintsLeft(gameId) });
        }
        else
        {
            return Ok(new { message = "No hints left" });
        }
    }

    public class GuessRequest
    {
        public char Letter { get; set; }
    }
}
