using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote;

/// <summary>
/// Обработчик команды для создания заметки.
/// </summary>
public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly INotesDbContext _context;

    public CreateNoteCommandHandler(INotesDbContext context) => _context = context;

    /// <summary>
    /// Выполнение обработчика команды для создания заметки.
    /// </summary>
    /// <param name="request">команда</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>guid</returns>
    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserId,
            Id = Guid.NewGuid(),
            Title = request.Title,
            Details = request.Details,
            CreationDate = DateTime.Now,
            EditDate = null
        };

        await _context.Notes.AddAsync(note, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}