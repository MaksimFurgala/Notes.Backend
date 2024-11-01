namespace Notes.Persistence
{
    public abstract class DbInitializer
    {
        /// <summary>
        /// Инициализация контекста БД.
        /// </summary>
        /// <param name="context">контекст</param>
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}