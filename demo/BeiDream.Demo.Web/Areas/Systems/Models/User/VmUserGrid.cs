using System;

namespace BeiDream.Demo.Web.Areas.Systems.Models.User
{
    public class VmUserGrid
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public  string Email{ get; set; }
        public string DisplayName{ get; set; }
        public string DateCreated{ get; set; }
        public bool? Enabled { get; set; } 
    }
}