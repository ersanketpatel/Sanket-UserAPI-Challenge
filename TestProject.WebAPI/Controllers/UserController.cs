using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Repository;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet]
        [Route("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                var userList = await userRepository.ListUsers();

                if(userList == null)
                {
                    return NotFound();
                }

                return Ok(userList);
            }
            catch (System.Exception)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpGet]
        [Route("GetUserByID")]
        public async Task<IActionResult> GetUserByID(decimal? userID)
        {
            if (userID == null)
            {
                return BadRequest("User ID mandatory to fetch details.");
            }

            try
            {
                var user = await userRepository.GetUser(userID);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (System.Exception)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]User userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userID = await userRepository.CreateUser(userModel);

                    if(userID > 0)
                    {
                        return Ok(userID);
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
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
