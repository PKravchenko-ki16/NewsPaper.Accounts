using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewsPaper.Accounts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        public AccountsController()
        {
        }

        [HttpGet("getaccounts")]
        public async Task<IActionResult> GetAccounts()
        {

            return Ok();
        }
    }
}
