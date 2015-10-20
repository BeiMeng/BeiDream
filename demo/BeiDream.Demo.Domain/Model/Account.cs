using System;
using System.Collections.Generic;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Demo.Domain.Model
{
    public class Account : AggregateRoot, ISoftDelete
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Password
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string DisplayName
        {
            get;
            set;
        }

        public virtual DateTime DateCreated
        {
            get;
            set;
        }

        public virtual DateTime? DateLastLogon
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public virtual List<Role> Roles
        {
            get;
            set;
        }

        public virtual List<Memo> Memos
        {
            get;
            set;
        }
    }
}