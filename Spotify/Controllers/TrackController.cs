using Core.DTOs.Track;
using Core.Interfaces;
using Core.Resources.ConstRoutes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    [ApiController]
    [Authorize]
    public class TrackController : ControllerBase
    {
        private readonly ITrackServices _services;

        public TrackController(ITrackServices services)
        {
            _services = services;
        }

        [HttpPost(TrackRoutes.Create)]
        public async Task<IActionResult> Create([FromForm] TrackCreateDTO trackData)
        {
            await _services.CreateAsync(User.Claims.First().Value, trackData);
            return Ok();
        }

        [HttpPut(TrackRoutes.Update)]
        public async Task<IActionResult> Update([FromForm] TrackUpdateDTO trackData)
        {
            await _services.UpdateTrackDataAsync(trackData);
            return Ok();
        }

        [HttpPost(TrackRoutes.Recovery)]
        public async Task<IActionResult> Recovery([FromRoute] int id)
        {
            await _services.RecoveryAsync(id);
            return Ok();
        }

        [HttpDelete(TrackRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _services.DeleteAsync(id);
            return Ok();
        }

        [HttpDelete(TrackRoutes.DeleteWithoutRecovery)]
        public async Task<IActionResult> DeleteWithoutRecovery([FromRoute] int id)
        {
            await _services.DeleteWithoutRecoveryAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetAllActive)]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _services.GetAllActiveAsync());
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetAllDeleted)]
        public async Task<IActionResult> GetAllDeleted()
        {
            return Ok(await _services.GetAllDeletedAsync());
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetAllExplicit)]
        public async Task<IActionResult> GetAllExplicit()
        {
            return Ok(await _services.GetAllExplicitAsync());
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _services.GetByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetAllByGenreId)]
        public async Task<IActionResult> GetAllByGenreId([FromRoute] int genreId)
        {
            return Ok(await _services.GetAllByGenreIdAsync(genreId));
        }

        [AllowAnonymous]
        [HttpGet(TrackRoutes.GetAllByPerformertId)]
        public async Task<IActionResult> GetAllByPerformerId([FromRoute] int performerId)
        {
            return Ok(await _services.GetAllByPerformerIdAsync(performerId));
        }

        [HttpGet(TrackRoutes.GetAllMyOwnTracks)]
        public async Task<IActionResult> GetAllMyTracks()
        {
            return Ok(await _services.GetAllMyTracksAsync(User.Claims.First().Value));
        }
    }
}