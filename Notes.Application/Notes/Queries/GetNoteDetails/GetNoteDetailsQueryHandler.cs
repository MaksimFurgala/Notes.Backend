using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

/// <summary>
/// Обработчик запроса для получения детальной информации по заметке.
/// </summary>
public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
    private readonly INotesDbContext _context;
    private readonly IMapper _mapper;

    public GetNoteDetailsQueryHandler(INotesDbContext context, IMapper mapper) =>
        (_context, _mapper) = (context, mapper);

    /// <summary>
    /// Выполнение запроса для получения детальной информации по заметке.
    /// </summary>
    /// <param name="request">запрос</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Notes
            .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        return _mapper.Map<NoteDetailsVm>(entity);
    }
}