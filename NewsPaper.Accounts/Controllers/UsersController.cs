using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;

namespace NewsPaper.Accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private OperationUsersAccounts _operationUsers;

        public UsersController(OperationUsersAccounts operationUsers)
        {
            _operationUsers = operationUsers;
        }

        [HttpGet("getuserbyid")]
        public async Task<IActionResult> GetUserAccountById(Guid userGuid)
        {
            try
            {
                var result = await _operationUsers.GetByIdUserAsync(userGuid);
                return Ok(result);
            }
            catch (NoUserFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getguiduserbynikename")]
        public async Task<IActionResult> GetGuidByNikeNameAuthorAsync(string userNikeName)
        {
            try
            {
                var result = await _operationUsers.GetGuidByNikeNameUserAsync(userNikeName);
                return Ok(result);
            }
            catch (NoUserFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getnikenameuserbyguid")]
        public async Task<IActionResult> GetNikeNameByGuidUserAsync(Guid userGuid)
        {
            try
            {
                var result = await _operationUsers.GetNikeNameByGuidUserAsync(userGuid);
                return Ok(result);
            }
            catch (NoUserFoundException exception)
            {
                return Ok(exception);
            }
        }
    }
}
