using Core.DTOs.Album;
using Core.Interfaces;
using Core.Resources.ConstRoutes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumServices _services;

        public AlbumController(IAlbumServices services)
        {
            _services = services;
        }

        [HttpPost(AlbumRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] AlbumCreateDTO albumData)
        {
            await _services.CreateAsync(User.Claims.First().Value, albumData);
            return Ok();
        }

        [HttpPut(AlbumRoutes.Update)]
        public async Task<IActionResult> Update([FromBody] AlbumUpdateDTO albumData)
        {
            await _services.UpdateAsync(albumData);
            return Ok();
        }

        [HttpPost(AlbumRoutes.Recovery)]
        public async Task<IActionResult> Recovery([FromRoute] int id)
        {
            await _services.RecoveryAsync(id);
            return Ok();
        }

        [HttpDelete(AlbumRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _services.DeleteAsync(id);
            return Ok();
        }

        [HttpDelete(AlbumRoutes.DeleteWithoutRecovery)]
        public async Task<IActionResult> DeleteWithoutRecovery([FromRoute] int id)
        {
            await _services.DeleteWithoutRecoveryAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(AlbumRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet(AlbumRoutes.GetAllPublic)]
        public async Task<IActionResult> GetAllPublic()
        {
            return Ok(await _services.GetAllPublicAsync());
        }

        [AllowAnonymous]
        [HttpGet(AlbumRoutes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _services.GetByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet(AlbumRoutes.AllByGenreId)]
        public async Task<IActionResult> GetAllByGenreId([FromRoute] int genreId)
        {
            return Ok(await _services.GetAllByGenreIdAsync(genreId));
        }

        [AllowAnonymous]
        [HttpGet(AlbumRoutes.AllByPerformerId)]
        public async Task<IActionResult> GetAllByPerformerId([FromRoute] int performerId)
        {
            return Ok(await _services.GetAllByPerformerIdAsync(performerId));
        }

        [HttpGet(AlbumRoutes.AllMyOwnAlbums)]
        public async Task<IActionResult> GetAllMyAlbums()
        {
            return Ok(await _services.GetAllMyAlbumsAsync(User.Claims.First().Value));
        }
    }
}