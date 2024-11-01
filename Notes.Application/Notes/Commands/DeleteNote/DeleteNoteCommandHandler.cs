using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote;

/// <summary>
/// Обработчик команды для удаления заметки.
/// </summary>
public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
{
    private readonly INotesDbContext _context;

    public DeleteNoteCommandHandler(INotesDbContext context) => _context = context;

    /// <summary>
    /// Выполнение обработчика команды для удаления заметки.
    /// </summary>
    /// <param name="request">команда</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        _context.Notes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}