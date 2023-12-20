using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services.Changes;
using Umbraco.Extensions;

namespace Umbraco.Cms.Core.Cache;


/// <inheritdoc />
public sealed class MemberTypeChangedDistributedCacheNotificationHandler : ContentTypeChangedDistributedCacheNotificationHandlerBase<IMemberType, MemberTypeChangedNotification>
{
    private readonly DistributedCache _distributedCache;

    /// <summary>
    /// Initializes a new instance of the <see cref="MemberTypeChangedDistributedCacheNotificationHandler" /> class.
    /// </summary>
    /// <param name="distributedCache">The distributed cache.</param>
    public MemberTypeChangedDistributedCacheNotificationHandler(DistributedCache distributedCache)
        => _distributedCache = distributedCache;

    /// <inheritdoc />
    protected override void Handle(IEnumerable<ContentTypeChange<IMemberType>> entities)
        => _distributedCache.RefreshContentTypeCache(entities);
}
