using FluentValidation;

namespace Notes.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
{
    /// <summary>
    /// Валидация команды удаления заметки.
    /// </summary>
    public DeleteNoteCommandValidator()
    {
        RuleFor(deleteNoteCommand => deleteNoteCommand.Id).NotEqual(Guid.Empty);
        RuleFor(deleteNoteCommand => deleteNoteCommand.UserId).NotEqual(Guid.Empty);
    }
}