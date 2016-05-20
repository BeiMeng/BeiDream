using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Demo.Domain.Model
{
    public class Product : AggregateRoot<int>, ISoftDelete
    {
        [StringLength(50, ErrorMessage = "产品名称输入过长，不能超过50位")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}