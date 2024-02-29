using Microsoft.AspNetCore.Mvc;
using Wardrobe.Model;
using Wardrobe.Service;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardrobeController : ControllerBase
    {
        private readonly IWardrobeService _wardrobeService;
        public WardrobeController(IWardrobeService wardrobeService)
        {
            _wardrobeService = wardrobeService;
        }

        [HttpGet]
        public async Task<List<WardrobeViewModel>> GetAll()
        {
            return await _wardrobeService.GetAllClothes();
        }

        [HttpGet("{id}")]
        public async Task<WardrobeViewModel> Get(int id)
        {
            return await _wardrobeService.GetClothe(id);
        }

        [HttpPost]
        public async Task<WardrobeViewModel> AddClothe( [FromBody] WardrobeViewModel clothe)
        {
            return await _wardrobeService.AddClothe(new WardrobeViewModel
            {
                Color = clothe.Color,
                Name = clothe.Name,
                ImagePath = "",
            });
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteClothe(int id)
        {
            await _wardrobeService.DeleteClothe(id);
            return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateClothe(int id, [FromBody] WardrobeViewModel clothe)
        {
            await _wardrobeService.UpdateClothe(id, clothe);
            return true;
        }
    }
}
