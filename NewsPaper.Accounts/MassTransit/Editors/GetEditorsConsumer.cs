using System;
using System.Collections.Generic;
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
    public class GetEditorsConsumer : IConsumer<EditorsRequestDto>
    {
        private readonly OperationEditorsAccounts _operationEditors;
        private readonly IMapper _mapper;
        public GetEditorsConsumer(IMapper mapper, OperationEditorsAccounts operationEditors)
        {
            _mapper = mapper;
            _operationEditors = operationEditors;
        }

        public async Task Consume(ConsumeContext<EditorsRequestDto> context)
        {
            try
            {
                var result = await _operationEditors.GetAllEditorsAsync();
                var editors = _mapper.Map<IEnumerable<EditorDto>>(result);
                await context.RespondAsync(new EditorsResponseDto
                {
                    EditorsDto = editors
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
