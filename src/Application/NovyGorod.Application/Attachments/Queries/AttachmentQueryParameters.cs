using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Builders;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.Application.Attachments.Queries;

internal class AttachmentQueryParameters : TranslatedEntityQueryParameters<Attachment, AttachmentTranslation>
{
    public int? PostBlockId { get; set; }

    protected override void AddFilters()
    {
        base.AddFilters();
        
        FilterIf(PostBlockId.HasValue, attachment => attachment.BlockId == PostBlockId);
    }

    protected override void AddSorting()
    {
        base.AddSorting();
        
        Sort(OrderType.Asc, attachment => attachment.Index);
    }
}