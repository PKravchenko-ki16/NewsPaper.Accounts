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
    public class GetNikeNameEditorConsumer : IConsumer<NikeNameEditorRequestDto>
    {
        private readonly OperationEditorsAccounts _operationEditors;
        public GetNikeNameEditorConsumer(OperationEditorsAccounts operationEditors)
        {
            _operationEditors = operationEditors;
        }

        public async Task Consume(ConsumeContext<NikeNameEditorRequestDto> context)
        {
            try
            {
                var editorNikeName = await _operationEditors.GetNikeNameByGuidEditorAsync(context.Message.EditorGuid);
                await context.RespondAsync(new NikeNameEditorResponseDto()
                {
                    NikeNameEditor = editorNikeName
                });
            }
            catch (NoAuthorFoundException e)
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
