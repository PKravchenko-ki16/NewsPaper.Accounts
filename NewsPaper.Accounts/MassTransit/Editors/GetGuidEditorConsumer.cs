using System;
using System.Threading.Tasks;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Editor;

namespace NewsPaper.Accounts.MassTransit.Editors
{
    public class GetGuidEditorConsumer : IConsumer<GuidEditorRequestDto>
    {
        private readonly OperationEditorsAccounts _operationEditors;
        public GetGuidEditorConsumer(OperationEditorsAccounts operationEditors)
        {
            _operationEditors = operationEditors;
        }

        public async Task Consume(ConsumeContext<GuidEditorRequestDto> context)
        {
            try
            {
                var editorGuid = await _operationEditors.GetGuidByNikeNameEditorAsync(context.Message.NikeNameEditor);
                await context.RespondAsync(new GuidEditorResponseDto
                {
                    EditorGuid = editorGuid
                });
            }
            catch (NoEditorFoundException e)
            {
                await context.RespondAsync(new NoEditorFound
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new NoEditorFound
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}
