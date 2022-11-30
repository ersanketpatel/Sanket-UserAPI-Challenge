﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject.WebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Account = new HashSet<Account>();
        }

        public decimal UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public decimal? MonthlySalary { get; set; }
        public decimal? MonthlyExpenses { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}