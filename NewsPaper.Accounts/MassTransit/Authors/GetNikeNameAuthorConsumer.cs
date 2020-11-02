using System;
using System.Threading.Tasks;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Author;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Author;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Author;

namespace NewsPaper.Accounts.MassTransit.Authors
{
    public class GetNikeNameAuthorConsumer : IConsumer<NikeNameAuthorRequestDto>
    {
        private readonly OperationAuthorsAccounts _operationAuthors;
        public GetNikeNameAuthorConsumer(OperationAuthorsAccounts operationAuthors)
        {
            _operationAuthors = operationAuthors;
        }

        public async Task Consume(ConsumeContext<NikeNameAuthorRequestDto> context)
        {
            try
            {
                var authorNikeName = await _operationAuthors.GetNikeNameByGuidAuthorAsync(context.Message.AuthorGuid);
                await context.RespondAsync(new NikeNameAuthorResponseDto
                {
                    NikeNameAuthor = authorNikeName
                });
            }
            catch (NoAuthorFoundException e)
            {
                await context.RespondAsync(new NoAuthorFound
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new NoAuthorFound
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}
