using NovyGorod.Common.Exceptions;

namespace NovyGorod.Domain.ModelAccess.Exceptions;

internal class ModelQueryBuildException : CodedException
{
    public ModelQueryBuildException(string error)
        : base(ErrorCode.UnhandledException, error)
    {
    }
}