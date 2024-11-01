using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote;

/// <summary>
/// Обработчик команды для обновления заметки.
/// </summary>
public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
{
    private readonly INotesDbContext _context;

    public UpdateNoteCommandHandler(INotesDbContext context) => _context = context;

    /// <summary>
    /// Выполнение обработчика команды для обновления заметки.
    /// </summary>
    /// <param name="request">команда</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.Details = request.Details;
        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}