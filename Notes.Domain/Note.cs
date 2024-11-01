namespace Notes.Domain
{
    /// <summary>
    /// Заметка.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Id заметки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Титул.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Детали (доп. информация).
        /// </summary>
        public string? Details { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата редактирования.
        /// </summary>
        public DateTime? EditDate { get; set; }
    }
}