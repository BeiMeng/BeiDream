using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Validations;

namespace BeiDream.Demo.Service.Dtos
{
    public class RoleDto:IValidate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}