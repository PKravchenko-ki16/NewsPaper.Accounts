using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Operation;
using NewsPaper.MassTransit.Contracts.DTO.Models.Author;
using NewsPaper.MassTransit.Contracts.DTO.Models.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Operation;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Operation;

namespace NewsPaper.Accounts.MassTransit.Operation
{
    public class AccountsForCreateArticleConsumer : IConsumer<AccountsForCreateArticleRequestDto>
    {
        private readonly OperationEditorsAccounts _operationEditors;
        private readonly OperationAuthorsAccounts _operationAuthors;
        private readonly IMapper _mapper;
        public AccountsForCreateArticleConsumer(IMapper mapper, OperationEditorsAccounts operationEditors, OperationAuthorsAccounts operationAuthors)
        {
            _mapper = mapper;
            _operationEditors = operationEditors;
            _operationAuthors = operationAuthors;
        }

        public async Task Consume(ConsumeContext<AccountsForCreateArticleRequestDto> context)
        {
            try
            {
                var resultAuthor = await _operationAuthors.GetAuthorByIdentityIdAsync(context.Message.AuthorIdentityId);
                var resultEditor = await _operationEditors.GetFreeEditorAsync();
                var author = _mapper.Map<AuthorDto>(resultAuthor);
                var editor = _mapper.Map<EditorDto>(resultEditor);
                await context.RespondAsync(new AccountsForCreateArticleResponseDto
                {
                    Author = author,
                    Editor = editor
                });
            }
            catch (FailedGetAccountsToCreateArticleException e)
            {
                await context.RespondAsync(new FailedGetAccountsToCreateArticle
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new FailedGetAccountsToCreateArticle
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}