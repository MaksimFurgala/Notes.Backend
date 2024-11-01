using MediatR;

namespace Notes.Application.Notes.Commands.DeleteNote;

/// <summary>
/// Команда для удаления заметки.
/// </summary>
public class DeleteNoteCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}