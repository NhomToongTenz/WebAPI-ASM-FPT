using ASM.Models;

namespace ASM.Interface;

public interface IGameModeServices
{
    Task<List<Player>> GetPlayersByGameModeName(string gameModeName);
}
