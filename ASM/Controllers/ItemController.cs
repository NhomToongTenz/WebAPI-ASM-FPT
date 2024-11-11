using ASM.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers;

[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemsServices _itemsServices;

    public ItemController(IItemsServices itemsServices) => _itemsServices = itemsServices;

    [HttpGet("api/items/weapons-over-100")]
    public async Task<IActionResult> GetWeaponsOver100()
    {
        try
        {
            var weapons = await _itemsServices.GetWeaponsOver100();

            if (weapons == null || weapons.Count == 0)
            {
                return NotFound(new { status = false, message = "No weapons found with experience value over 100." });
            }

            return Ok(new { status = true, data = weapons });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = false, message = e.Message });
        }
    }

    [HttpGet("api/items/can-buy/{playerId}")]
    public async Task<IActionResult> GetItemsCanBuy(int playerId)
    {
        try
        {
            var items = await _itemsServices.GetItemsCanBuy(playerId);

            if (items == null || items.Count == 0)
            {
                return NotFound(new { status = false, message = "No items found that the player can buy." });
            }

            return Ok(new { status = true, data = items });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = false, message = e.Message });
        }
    }


    [HttpGet("api/items/contain-diamond-and-exp-less-than-500")]
    public async Task<IActionResult> GetItemsContainDiamondAndExpLessThan500()
    {
        try
        {
            var items = await _itemsServices.GetItemsContainDiamondAndExpLessThan500();

            if (items == null || items.Count == 0)
            {
                return NotFound(new { status = false, message = "No items found that contain 'kim cương' and have experience value less than 500." });
            }

            return Ok(new { status = true, data = items });
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = false, message = e.Message });
        }
    }
}
