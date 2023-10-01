using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.Models.Attachments;
using AttachmentModel = NovyGorod.Domain.Models.Attachments.Attachment;

namespace NovyGorod.Domain.ModelAccess.Filters;

public static class Attachment
{
    public static QueryFilter<AttachmentModel> IdIs(int id) => Common.IdIs<AttachmentModel>(id);

    public static QueryFilter<AttachmentModel> IdIsIn(IEnumerable<int> ids) => Common.IdIsIn<AttachmentModel>(ids);

    public static QueryFilter<AttachmentModel> IsTranslatedInto(int languageId) =>
        Common.IsTranslatedInto<AttachmentModel, int, AttachmentTranslation>(languageId);

    public static QueryFilter<AttachmentModel> IsTranslatedInto(IEnumerable<int> languageIds) =>
        Common.IsTranslatedInto<AttachmentModel, int, AttachmentTranslation>(languageIds);

    public static QueryFilter<AttachmentModel> BlockIdIs(int blockId) =>
        Create(attachment => attachment.BlockId == blockId);

    private static QueryFilter<AttachmentModel> Create(Expression<Func<AttachmentModel, bool>> expression) =>
        QueryFilter<AttachmentModel>.Create(expression);
}