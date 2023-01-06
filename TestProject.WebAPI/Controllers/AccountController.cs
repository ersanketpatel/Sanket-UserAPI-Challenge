using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Core.Models;
using TestProject.DAL.Repository;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all list of accounts detail.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAccountList()
        {
            try
            {
                var accountList = await _unitOfWork.AccountRepository.GetAll();
                return Ok(accountList);
            }
            catch (System.Exception)
            {
                return BadRequest("Something went wrong.");
            }
        }

        /// <summary>
        /// To Add new Account
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> AddAccount([FromBody] Account accountModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.AccountRepository.Add(accountModel);
                    await _unitOfWork.CompleteAsync();

                    return Ok("Account Added successfully");
                }
                catch
                {
                    return BadRequest("Somthing went wrong.");
                }
            }

            return BadRequest("Invalid data model.");
        }
    }
}
