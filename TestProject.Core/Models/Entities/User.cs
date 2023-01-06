using System;
using System.Collections.Generic;

namespace TestProject.Core.Models
{
    public partial class User
    {
        public User()
        {
            Account = new HashSet<Account>();
        }

        public long UserId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public decimal? MonthlySalary { get; set; }
        public decimal? MonthlyExpenses { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
