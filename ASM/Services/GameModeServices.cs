using ASM.Appdatacontext;
using ASM.Interface;
using ASM.Models;

namespace ASM.Services;

public class GameModeServices : IGameModeServices
{
    private readonly AppDataContext _context;

    public GameModeServices(Appdatacontext.AppDataContext context) => _context = context;

    public Task<List<Player>> GetPlayersByGameModeName(string gameModeName) {
        try {
            var gameMode =  _context.Game_Modes.FirstOrDefault(g => g.GameMode_name.Equals(gameModeName));
            if(gameMode == null) {
                throw new Exception("Game mode not found");
            }

            var players = _context.Player_GameMode
                                  .Where(pg => pg.GameMode_id == gameMode.GameMode_id)
                                  .Select(pg => pg.Player_id)
                                  .ToList();

            var playerList = _context.Player
                                     .Where(p => players.Contains(p.Player_id))
                                     .ToList();

            return Task.FromResult(playerList);
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }


}
