using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

/// <summary>
/// Запрос для получения детальной информации по заметке.
/// </summary>
public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}