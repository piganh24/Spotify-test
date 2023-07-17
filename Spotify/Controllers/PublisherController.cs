using Core.Interfaces;
using Core.DTOs.Publisher;
using Core.Resources.ConstRoutes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spotify.Controllers
{
    [ApiController]
    [Authorize]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherServices _services;

        public PublisherController(IPublisherServices services)
        {
            _services = services;
        }

        [HttpPost(PublisherRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] PublisherCreateDTO publisherData)
        {
            await _services.CreateAsync(publisherData);
            return Ok();
        }

        [HttpPut(PublisherRoutes.Update)]
        public async Task<IActionResult> Update([FromBody] PublisherUpdateDTO publisherData)
        {
            await _services.UpdateAsync(publisherData);
            return Ok();
        }

        [HttpPost(PublisherRoutes.Recovery)]
        public async Task<IActionResult> Recovery([FromRoute] int id)
        {
            await _services.RecoveryAsync(id);
            return Ok();
        }

        [HttpDelete(PublisherRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _services.DeleteAsync(id);
            return Ok();
        }

        [HttpDelete(PublisherRoutes.DeleteWithoutRecovery)]
        public async Task<IActionResult> DeleteWithoutRecovery([FromRoute] int id)
        {
            await _services.DeleteWithoutRecoveryAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(PublisherRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet(PublisherRoutes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _services.GetByIdAsync(id));
        }
    }
}