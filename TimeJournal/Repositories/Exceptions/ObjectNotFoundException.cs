namespace TimeJournal.Repositories.Exceptions;

public class ObjectNotFoundException : Exception
{
	public ObjectNotFoundException(string message) : base(message)
	{
	}
}
