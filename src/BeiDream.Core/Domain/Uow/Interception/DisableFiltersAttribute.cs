using System;
using System.Collections.Generic;
using BeiDream.Core.Domain.Datas;
using BeiDream.Utils.Extensions;

namespace BeiDream.Core.Domain.Uow.Interception
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DisableFiltersAttribute : Attribute
    {
        public List<FiltersEnum> FilterNames { get; private set; }

        public DisableFiltersAttribute(params FiltersEnum[] filterNames)
        {
            filterNames.CheckNotNull("filterNames");
            FilterNames = new List<FiltersEnum>(filterNames);
        }
    }
}