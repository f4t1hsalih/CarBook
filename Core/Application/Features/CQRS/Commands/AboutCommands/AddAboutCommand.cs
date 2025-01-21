namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class AddAboutCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
