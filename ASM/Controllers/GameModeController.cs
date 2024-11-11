using ASM.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers;

[ApiController]
public class GameModeController : ControllerBase
{
    private readonly IGameModeServices _gameModeServices;

    public GameModeController(IGameModeServices gameModeServices) => _gameModeServices = gameModeServices;

    [HttpGet]
    [Route("/api/get-players-by-game-mode-name")]
    public async Task<IActionResult> GetPlayersByGameModeName(string gameModeName)
    {
        try
        {
            var players = await _gameModeServices.GetPlayersByGameModeName(gameModeName);
            return Ok(
                new
                {
                    status = true,
                    data = players
                }
            );
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
