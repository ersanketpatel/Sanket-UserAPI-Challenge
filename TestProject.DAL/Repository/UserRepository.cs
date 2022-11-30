using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Core.Models;
using TestProject.Core.ViewModel;

namespace TestProject.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        ALTIMETRIKContext _context;

        public UserRepository(ALTIMETRIKContext _db)
        {
            _context = _db;
        }

        public async Task<decimal> CreateUser(User user)
        {
            if (_context != null)
            {
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();

                return user.UserId;
            }

            return 0;
        }

        public async Task<UserViewModel> GetUser(decimal? userId)
        {
            if (_context != null)
            {
                return await (from u in _context.User
                              where u.UserId == userId
                              select new UserViewModel
                              {
                                  Name = u.Name,
                                  EmailId = u.EmailId,
                                  MonthlySalary = u.MonthlySalary,
                                  MonthlyExpenses = u.MonthlyExpenses
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        //private ModelValidate ValidateEntityOnInsert(User user)
        //{
        //    ModelValidate modelValidate = new ModelValidate();

        //    if (_context != null)
        //    {

        //        //return await (from u in _context.User
        //        //             where u.EmailId == emailID
        //        //             select new UserViewModel
        //        //             {
        //        //                 Name = u.Name,
        //        //                 EmailId = u.EmailId,
        //        //                 MonthlySalary = u.MonthlySalary,
        //        //                 MonthlyExpenses = u.MonthlyExpenses
        //        //             }).AnyAsync();
        //     }

        //    return modelValidate;
        //}

        public async Task<List<UserViewModel>> ListUsers()
        {
            if (_context != null)
            {
                return await (from u in _context.User
                              select new UserViewModel
                              {
                                  UserId = u.UserId,
                                  Name = u.Name,
                                  EmailId = u.EmailId,
                                  MonthlySalary = u.MonthlySalary,
                                  MonthlyExpenses = u.MonthlyExpenses
                              }).ToListAsync();
            }

            return null;
        }


    }
}
