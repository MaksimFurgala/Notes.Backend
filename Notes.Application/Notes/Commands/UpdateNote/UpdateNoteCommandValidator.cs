using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
{
    /// <summary>
    /// Валидация команды обновления заметки.
    /// </summary>
    public UpdateNoteCommandValidator()
    {
        RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty);
        RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
        RuleFor(updateNoteCommand => updateNoteCommand.Title).NotEmpty().MaximumLength(250);
    }
}