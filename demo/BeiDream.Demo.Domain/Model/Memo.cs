
using System;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Demo.Domain.Model
{
    public partial class Memo : AggregateRoot
	{
		public virtual string Title
		{
			get;
			set;
		}

		public virtual string Content
		{
			get;
			set;
		}

		public virtual DateTime DateAdded
		{
			get;
			set;
		}

		public virtual DateTime? DateModified
		{
			get;
			set;
		}

	}
}

