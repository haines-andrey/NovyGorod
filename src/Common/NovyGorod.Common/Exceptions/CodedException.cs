using NovyGorod.Common.Extensions;

namespace NovyGorod.Common.Exceptions;

public class CodedException : Exception
{
    public CodedException(ErrorCode code)
        : this(code, Array.Empty<string>())
    {
    }

    public CodedException(ErrorCode code, string error)
        : this(code, new[] { error })
    {
    }

    public CodedException(ErrorCode code, IEnumerable<string> errors)
    {
        Code = code;
        Errors = errors?.Where(x => !x.IsNullOrEmpty()).ToArray() ?? Array.Empty<string>();
    }

    public ErrorCode Code { get; }

    public IReadOnlyCollection<string> Errors { get; }
}