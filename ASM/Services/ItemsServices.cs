using ASM.Appdatacontext;
using ASM.Interface;
using ASM.Models;

namespace ASM.Services;

public class ItemsServices : IItemsServices
{
    private readonly AppDataContext _context;

    public ItemsServices(AppDataContext context) => _context = context;

    public Task<List<Items>> GetWeaponsOver100() {
        try {
            var weapons = _context.Items
                .Where(x => x.Item_type == "Weapon" && x.Exp > 100)
                .ToList();
            return Task.FromResult(weapons);
        }
        catch (Exception exception) {
            Console.WriteLine(exception);
            throw;
        }
    }

    public Task<List<Items>> GetItemsCanBuy(int playerId) {
        try {
            var player = _context.Player.FirstOrDefault(x => x.Player_id == playerId);

            if (player == null) {
                return Task.FromResult(new List<Items>());
            }

            var items = _context.Items
                .Where(x => x.Exp <= player.Exp)
                .ToList();

            return Task.FromResult(items);
        }catch (Exception exception) {
            Console.WriteLine(exception);
            throw;
        }
    }

    public Task<List<Items>> GetItemsContainDiamondAndExpLessThan500() {
        try {
            var items = _context.Items
                .Where(x => x.Item_name.Contains("kim cương") && x.Exp < 500)
                .ToList();

            return Task.FromResult(items);
        }catch (Exception exception) {
            Console.WriteLine(exception);
            throw;
        }
    }
}
