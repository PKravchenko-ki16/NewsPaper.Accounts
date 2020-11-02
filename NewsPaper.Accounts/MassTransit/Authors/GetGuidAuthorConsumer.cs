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
    public class GetGuidAuthorConsumer : IConsumer<GuidAuthorRequestDto>
    {
        private readonly OperationAuthorsAccounts _operationAuthors;
        public GetGuidAuthorConsumer(OperationAuthorsAccounts operationAuthors)
        {
            _operationAuthors = operationAuthors;
        }

        public async Task Consume(ConsumeContext<GuidAuthorRequestDto> context)
        {
            try
            {
                var authorGuid = await _operationAuthors.GetGuidByNikeNameAuthorAsync(context.Message.NikeNameAuthor);
                await context.RespondAsync(new GuidAuthorResponseDto
                {
                    AuthorGuid = authorGuid
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
