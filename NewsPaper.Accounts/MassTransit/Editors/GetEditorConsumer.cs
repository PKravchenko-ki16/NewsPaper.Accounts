using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Models.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Editor;

namespace NewsPaper.Accounts.MassTransit.Editors
{
    public class GetEditorConsumer : IConsumer<EditorRequestDto>
    {
        private readonly OperationEditorsAccounts _operationEditors;
        private readonly IMapper _mapper;
        public GetEditorConsumer(IMapper mapper, OperationEditorsAccounts operationEditors)
        {
            _mapper = mapper;
            _operationEditors = operationEditors;
        }

        public async Task Consume(ConsumeContext<EditorRequestDto> context)
        {
            try
            {
                var result = await _operationEditors.GetByIdEditorAsync(context.Message.EditorGuid);
                var editor = _mapper.Map<EditorDto>(result);
                await context.RespondAsync(new EditorResponseDto
                {
                    EditorDto = editor
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
