using AppleStore.Context;
using AppleStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppleStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppleShopController : ControllerBase
    {
        // Обработка запроса на получение всех данных
        // Processing request to get all data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppleShop>>> GetAppleShop()
        {
            try
            {
                using (var db = new DbAppleTechnicStoreContext())
                {
                    return await db.AppleShops.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Обработка запроса добавления данных в базу данных
        // Processing a request to add data to the database
        [HttpPost]
        public async Task<ActionResult<AppleShop>> PostAppleShop(AppleShop appleShop)
        {
            try
            {
                if (appleShop == null || appleShop.Price < 0)
                    return BadRequest("Incorrect data");

                using (var db = new DbAppleTechnicStoreContext())
                {
                    db.AppleShops.Add(appleShop);
                    await db.SaveChangesAsync();
                }

                return CreatedAtAction(nameof(GetAppleShop), new { id = appleShop.Id }, appleShop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Обработка запроса удаления данных из базы данных
        // Processing a request to delete data from a database
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id == 0 || id < 0)
                    return BadRequest("Incorrect ID");

                using (var db = new DbAppleTechnicStoreContext())
                {
                    var product = await db.AppleShops.FindAsync(id);

                    if (product == null)
                        return NotFound();

                    db.AppleShops.Remove(product);
                    await db.SaveChangesAsync();

                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Обработка запроса на поиск по имени
        // Processing a search request by name
        [HttpGet("search/byname")]
        public async Task<ActionResult<IEnumerable<AppleShop>>> GetAppleShopByName(string productname)
        {
            try
            {
                if (string.IsNullOrEmpty(productname))
                    return BadRequest("Name parametr is required");

                using (var db = new DbAppleTechnicStoreContext())
                {
                    var gameShop = await db.AppleShops.Where(c => c.ProductName.Contains(productname)).ToListAsync();
                    if (gameShop.Any())
                        return Ok(gameShop);
                    else

                        return NotFound($"Product with name: {productname} not found!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internall server error");
            }
        }

        // Обработка запроса на поиск по диапазону цен
        // Processing a price range seacrh request
        [HttpGet("search/byprice")]
        public async Task<ActionResult<IEnumerable<AppleShop>>> GetAppleShopByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                if (minPrice > maxPrice)
                    return BadRequest("Minimum price cannot be greater than maximum price.");

                if (minPrice < 0 && maxPrice < 0)
                    return BadRequest("Incorrect value price");

                if (minPrice == 0 && maxPrice == 0)
                    return BadRequest("Value minPrice and maxPrice required");

                using (var db = new DbAppleTechnicStoreContext())
                {
                    var gameShop = await db.AppleShops.Where(k => k.Price >= minPrice && k.Price <= maxPrice).ToListAsync();

                    return Ok(gameShop);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internall server error");
            }
        }
    }
}
