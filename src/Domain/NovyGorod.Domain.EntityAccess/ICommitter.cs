namespace NovyGorod.Domain.EntityAccess;

public interface ICommitter
{
    /// <summary>
    ///     Asynchronously saves all changes made in this transaction to the database.
    /// </summary>
    /// <returns>
    ///     A <see cref="Task{TResult}" /> that represents the asynchronous save operation. The task result contains the
    ///     number of state entities written to database.
    /// </returns>
    Task<int> Commit();
}