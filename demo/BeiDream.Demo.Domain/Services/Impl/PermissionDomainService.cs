using System;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Domain.Services.Contracts;

namespace BeiDream.Demo.Domain.Services.Impl
{
    public class PermissionDomainService : IPermissionDomainService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionDomainService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public void Delete(Guid id)
        {
            var permission = _permissionRepository.Find(id);
            _permissionRepository.Delete(permission);
        }
    }
}