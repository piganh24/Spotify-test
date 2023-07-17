using Core.DTOs.Playlist;
using Core.Interfaces;
using Core.Resources.ConstRoutes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    [ApiController]
    [Authorize]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistServices _services;

        public PlaylistController(IPlaylistServices services)
        {
            _services = services;
        }

        [HttpPost(PlaylistRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] PlaylistCreateDTO playlistData)
        {
            await _services.CreateAsync(User.Claims.First().Value, playlistData);
            return Ok();
        }

        [HttpPut(PlaylistRoutes.Update)]
        public async Task<IActionResult> Update([FromBody] PlaylistUpdateDTO playlistData)
        {
            await _services.UpdateAsync(playlistData);
            return Ok();
        }

        [HttpPost(PlaylistRoutes.Recovery)]
        public async Task<IActionResult> Recovery([FromRoute] int id)
        {
            await _services.RecoveryAsync(id);
            return Ok();
        }

        [HttpDelete(PlaylistRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _services.DeleteAsync(id);
            return Ok();
        }

        [HttpDelete(PlaylistRoutes.DeleteWithoutRecovery)]
        public async Task<IActionResult> DeleteWithoutRecovery([FromRoute] int id)
        {
            await _services.DeleteWithoutRecoveryAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(PlaylistRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet(PlaylistRoutes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _services.GetByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet(PlaylistRoutes.GetAllByGenreId)]
        public async Task<IActionResult> GetAllByGenreId([FromRoute] int genreId)
        {
            return Ok(await _services.GetAllByGenreIdAsync(genreId));
        }

        [HttpGet(PlaylistRoutes.GetAllMyOwnPlaylists)]
        public async Task<IActionResult> GetAllMyPlaylists()
        {
            return Ok(await _services.GetAllMyPlaylistsAsync(User.Claims.First().Value));
        }
    }
}