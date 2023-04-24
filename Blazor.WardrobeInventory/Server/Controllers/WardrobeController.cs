using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blazor.WardrobeInventory.Server.Data;
using Blazor.WardrobeInventory.Shared.Models;

namespace Blazor.WardrobeInventory.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WardrobeController : ControllerBase
{
    private readonly BlazorWardrobeInventoryServerContext _context;

    public WardrobeController(BlazorWardrobeInventoryServerContext context)
    {
        _context = context;
    }

    // GET: api/Wardrobe
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WardrobeItem>>> GetWardrobeItem()
    {
        if (_context.WardrobeItem == null)
        {
            return NotFound();
        }
        return await _context.WardrobeItem.ToListAsync();
    }

    // GET: api/Wardrobe/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WardrobeItem>> GetWardrobeItem(int id)
    {
        if (_context.WardrobeItem == null)
        {
            return NotFound();
        }
        var wardrobeItem = await _context.WardrobeItem.FindAsync(id);

        if (wardrobeItem == null)
        {
            return NotFound();
        }

        return wardrobeItem;
    }

    // PUT: api/Wardrobe/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWardrobeItem(int id, WardrobeItem wardrobeItem)
    {
        if (id != wardrobeItem.Id)
        {
            return BadRequest();
        }

        _context.Entry(wardrobeItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WardrobeItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Wardrobe
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<WardrobeItem>> PostWardrobeItem(WardrobeItem wardrobeItem)
    {
        if (_context.WardrobeItem == null)
        {
            return Problem("Entity set 'BlazorWardrobeInventoryServerContext.WardrobeItem'  is null.");
        }
        _context.WardrobeItem.Add(wardrobeItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWardrobeItem", new { id = wardrobeItem.Id }, wardrobeItem);
    }

    // DELETE: api/Wardrobe/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWardrobeItem(int id)
    {
        if (_context.WardrobeItem == null)
        {
            return NotFound();
        }
        var wardrobeItem = await _context.WardrobeItem.FindAsync(id);
        if (wardrobeItem == null)
        {
            return NotFound();
        }

        _context.WardrobeItem.Remove(wardrobeItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WardrobeItemExists(int id)
    {
        return (_context.WardrobeItem?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
