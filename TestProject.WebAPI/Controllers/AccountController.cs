using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TestProject.Core.Models;
using TestProject.DAL.Repository;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountRepository accountRepository;
        public AccountController(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        [HttpGet]
        [Route("GetAccountList")]
        public async Task<IActionResult> GetAccountList()
        {
            try
            {
                var accountList = await accountRepository.GetAccounts();

                if (accountList == null)
                {
                    return NotFound();
                }

                return Ok(accountList);
            }
            catch (System.Exception)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody] Account accountModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var accountID = await accountRepository.CreateAccount(accountModel);

                    if (accountID > 0)
                    {
                        return Ok(accountID);
                    }
                    else
                    {
                        return NotFound();
                    }
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
