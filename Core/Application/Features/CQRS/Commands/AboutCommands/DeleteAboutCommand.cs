namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class DeleteAboutCommand
    {
        public int Id { get; set; }

        public DeleteAboutCommand(int id)
        {
            Id = id;
        }
    }
}
