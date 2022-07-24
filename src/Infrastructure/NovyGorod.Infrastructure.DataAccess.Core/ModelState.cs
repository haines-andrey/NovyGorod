namespace NovyGorod.Infrastructure.DataAccess.Core;

[Flags]
public enum ModelState : byte
{
    Added = 1,
    Modified = 2,
    Deleted = 4,
}