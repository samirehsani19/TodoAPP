namespace ToDoApp.Application.Exceptions
{
    public class TodoAlreadyExistsException : Exception
    {
        public TodoAlreadyExistsException(Guid id)
            : base($"Todo with id {id} already exists.") { }
    }

    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException(Guid id)
            : base($"Todo with id {id} was not found.") { }
    }
}
