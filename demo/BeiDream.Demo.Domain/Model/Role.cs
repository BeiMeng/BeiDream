using System.Collections.Generic;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Demo.Domain.Model
{


	public class Role : AggregateRoot
	{
		public virtual string Description
		{
			get;
			set;
		}

		public virtual string Name
		{
			get;
			set;
		}
        public virtual List<Permission> Permissions
        {
            get;
            set;
        }

        public virtual List<Account> Accounts
        {
            get;
            set;
        }
	}
}

