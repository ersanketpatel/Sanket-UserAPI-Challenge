using System;
using System.Collections.Generic;

namespace TestProject.Core.Models
{
    public partial class Account
    {
        public decimal AccountId { get; set; }
        public decimal? UserId { get; set; }
        public string AccountType { get; set; }

        public virtual User User { get; set; }
    }
}
