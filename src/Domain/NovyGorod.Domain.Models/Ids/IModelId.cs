using System;

namespace NovyGorod.Domain.Models.Ids;

//ToDo: should be used when EF core will support keys for complex types
public interface IModelId : IEquatable<IModelId>
{
    object[] ConvertToValuesArray();
}