using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Core.Models;
using TestProject.DAL.Repository;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all users list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetUserList()
        {
            try
            {
                var userList = await _unitOfWork.UserRepository.GetAll();
                return Ok(userList);
            }
            catch (System.Exception)
            {
                return BadRequest("Something went wrong.");
            }
        }

        /// <summary>
        /// Get specific user detail by User Id.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetUserByID(long userID)
        {            
            try
            {
                var user = await _unitOfWork.UserRepository.GetByID(userID);

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

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> AddUser([FromBody]User userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.UserRepository.Add(userModel);
                    await _unitOfWork.CompleteAsync();

                    return Ok("User Added successfully");
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
