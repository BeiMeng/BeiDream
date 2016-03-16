using System;
using BeiDream.Demo.Service.Users.Dtos;

namespace BeiDream.Demo.Web.Areas.Systems.Models.User
{
    public class VmUserGrid
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string CreationTime { get; set; }
        public bool? Enabled { get; set; }
    }

    public static class VmUserGridExtension
    {
        public static VmUserGrid ToGridVm(this UserDto dto)
        {
            return new VmUserGrid
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled,
                CreationTime = dto.CreationTime
            };
        }
    }
}