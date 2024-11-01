using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Команда для создания заметки.
    /// </summary>
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}