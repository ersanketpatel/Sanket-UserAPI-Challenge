using System;
using System.Collections.Generic;

namespace TestProject.Core.Models
{
    public partial class Account
    {
        public long AccountId { get; set; }
        public long UserId { get; set; }
        public string AccountType { get; set; }

        public virtual User User { get; set; }
    }
}
