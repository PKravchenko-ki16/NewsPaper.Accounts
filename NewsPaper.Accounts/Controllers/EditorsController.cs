using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;

namespace NewsPaper.Accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorsController : ControllerBase
    {
        private OperationEditorsAccounts _operationEditors;

        public EditorsController(OperationEditorsAccounts operationEditors)
        {
            _operationEditors = operationEditors;
        }

        [HttpGet("geteditorbyid")]
        public async Task<IActionResult> GetEditorById(Guid editorGuid)
        {
            try
            {
                var result = await _operationEditors.GetByIdEditorAsync(editorGuid);
                return Ok(result);
            }
            catch (NoEditorFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getguideditorbynikename")]
        public async Task<IActionResult> GetGuidByNikeNameEditorAsync(string editorNikeName)
        {
            try
            {
                var result = await _operationEditors.GetGuidByNikeNameEditorAsync(editorNikeName);
                return Ok(result);
            }
            catch (NoEditorFoundException exception)
            {
                return Ok(exception);
            }
        }

        [HttpGet("getnikenameuserbyguid")]
        public async Task<IActionResult> GetNikeNameByGuidEditorAsync(Guid editorGuid)
        {
            try
            {
                var result = await _operationEditors.GetNikeNameByGuidEditorAsync(editorGuid);
                return Ok(result);
            }
            catch (NoEditorFoundException exception)
            {
                return Ok(exception);
            }
        }
    }
}
