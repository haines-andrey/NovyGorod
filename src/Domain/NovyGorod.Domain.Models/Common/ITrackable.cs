using System;

namespace NovyGorod.Domain.Models.Common;

public interface ITrackable
{
    string CreatedBy { get; set; }

    DateTime? CreatedAt { get; set; }

    string UpdatedBy { get; set; }

    DateTime? UpdatedAt { get; set; }
}