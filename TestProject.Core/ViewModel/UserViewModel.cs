using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.ViewModel
{
    public class UserViewModel
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public decimal? MonthlySalary { get; set; }
        public decimal? MonthlyExpenses { get; set; }
    }
}
