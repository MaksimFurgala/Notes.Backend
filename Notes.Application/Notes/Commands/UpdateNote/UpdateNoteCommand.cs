using MediatR;

namespace Notes.Application.Notes.Commands.UpdateNote;

/// <summary>
/// Команда для обновления заметки.
/// </summary>
public class UpdateNoteCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
}