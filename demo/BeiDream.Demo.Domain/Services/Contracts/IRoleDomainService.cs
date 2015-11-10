using BeiDream.Core.Domain.Services;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Utils.PagerHelper;
using System;

namespace BeiDream.Demo.Domain.Services.Contracts
{
    public interface IRoleDomainService : IDomainService
    {
        PagerList<Role> Query(RoleQuery query);

        void AddorUpdate(Role entity);

        Role Find(Guid id);

        void Delete(Guid id);
    }
}