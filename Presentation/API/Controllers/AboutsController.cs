using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly AddAboutCommandHandler _addAboutCommandHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;

        public AboutsController(AddAboutCommandHandler addAboutCommandHandler, GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, DeleteAboutCommandHandler deleteAboutCommandHandler)
        {
            _addAboutCommandHandler = addAboutCommandHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.HandleAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var value = await _getAboutByIdQueryHandler.HandleAsync(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(AddAboutCommand command)
        {
            await _addAboutCommandHandler.Handle(command);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _deleteAboutCommandHandler.Handle(new DeleteAboutCommand(id));
            return Ok("Kayıt Başarıyla Silindi");
        }
    }
}
