using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;

namespace NewsPaper.Accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private OperationAuthorsAccounts _operationAuthors;

        public AuthorsController(OperationAuthorsAccounts operationAuthors)
        {
            _operationAuthors = operationAuthors;
        }

        [HttpGet("getauthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var result = await _operationAuthors.GetAllAuthorsAsync();
                return Ok(result);
            }
            catch (NoAuthorFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getauthorbyid")]
        public async Task<IActionResult> GetAuthorById(Guid authorGuid)
        {
            try
            {
                var result = await _operationAuthors.GetByIdAuthorAsync(authorGuid);
                return Ok(result);
            }
            catch (NoAuthorFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getguidauthorbynikename")]
        public async Task<IActionResult> GetGuidByNikeNameAuthorAsync(string authorNikeName)
        {
            try
            {
                var result = await _operationAuthors.GetGuidByNikeNameAuthorAsync(authorNikeName);
                return Ok(result);
            }
            catch (NoAuthorFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getnikenameauthorbyguid")]
        public async Task<IActionResult> GetNikeNameByGuidAuthorAsync(Guid authorGuid)
        {
            try
            {
                var result = await _operationAuthors.GetNikeNameByGuidAuthorAsync(authorGuid);
                return Ok(result);
            }
            catch (NoAuthorFoundException exception)
            {
                return Ok(exception);
            }
        }
    }
}
