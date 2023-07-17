using Core.DTOs.Genre;
using Core.Interfaces;
using Core.Resources.ConstRoutes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IGenreServices _services;

        public GenreController(IGenreServices services)
        {
            _services = services;
        }

        [HttpPost(GenreRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] GenreCreateDTO genreData)
        {
            await _services.CreateAsync(genreData);
            return Ok();
        }

        [HttpPut(GenreRoutes.Update)]
        public async Task<IActionResult> Update([FromBody] GenreUpdateDTO genreData)
        {
            await _services.UpdateAsync(genreData);
            return Ok();
        }

        [HttpPost(GenreRoutes.Recovery)]
        public async Task<IActionResult> Recovery([FromRoute] int id)
        {
            await _services.RecoveryAsync(id);
            return Ok();
        }

        [HttpDelete(GenreRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _services.DeleteAsync(id);
            return Ok();
        }

        [HttpDelete(GenreRoutes.DeleteWithoutRecovery)]
        public async Task<IActionResult> DeleteWithoutRecovery([FromRoute] int id)
        {
            await _services.DeleteWithoutRecoveryAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(GenreRoutes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _services.GetByIdAsync(id));
        }

        [HttpGet(GenreRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet(GenreRoutes.GetAllActive)]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _services.GetAllActiveAsync());
        }

        [AllowAnonymous]
        [HttpGet(GenreRoutes.GetAllDeleted)]
        public async Task<IActionResult> GetAllDeleted()
        {
            return Ok(await _services.GetAllDeletedAsync());
        }
    }
}