using ASM.Models;

namespace ASM.Interface;

public interface IItemsServices
{
    Task<List<Items>> GetWeaponsOver100();

    //4. Lấy thông tin các item mà người chơi có thể mua với số điểm kinh nghiệm tích lũy hiện tại của họ.
    Task<List<Items>> GetItemsCanBuy(int playerId);

    // 5. Lấy thông tin các item có tên chứa từ 'kim cương' và có giá trị dưới 500 điểm kinh nghiệm
    Task<List<Items>> GetItemsContainDiamondAndExpLessThan500();
}
