using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class DeleteAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public DeleteAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAboutCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null)
            {
                throw new Exception("The about does not exist.");
            }
            await _repository.DeleteAsync(value);
        }
    }
}
