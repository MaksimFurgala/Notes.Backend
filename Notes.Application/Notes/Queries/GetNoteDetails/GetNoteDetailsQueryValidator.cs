using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
{
    /// <summary>
    /// Валидация запроса на получение дополнительной информации по заметке.
    /// </summary>
    public GetNoteDetailsQueryValidator()
    {
        RuleFor(note => note.Id).NotEqual(Guid.Empty);
        RuleFor(note => note.UserId).NotEqual(Guid.Empty);
    }
}