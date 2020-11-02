using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.Author;
using NewsPaper.MassTransit.Contracts.DTO.Models.Author;
using NewsPaper.MassTransit.Contracts.DTO.Requests.Author;
using NewsPaper.MassTransit.Contracts.DTO.Responses.Author;

namespace NewsPaper.Accounts.MassTransit.Authors
{
    public class GetAuthorConsumer : IConsumer<AuthorRequestDto>
    {
        private readonly OperationAuthorsAccounts _operationAuthors;
        private readonly IMapper _mapper;
        public GetAuthorConsumer(IMapper mapper, OperationAuthorsAccounts operationAuthors)
        {
            _mapper = mapper;
            _operationAuthors = operationAuthors;
        }

        public async Task Consume(ConsumeContext<AuthorRequestDto> context)
        {
            try
            {
                var result = await _operationAuthors.GetByIdAuthorAsync(context.Message.AuthorGuid);
                var author = _mapper.Map<AuthorDto>(result);
                await context.RespondAsync(new AuthorResponseDto
                {
                    AuthorDto = author
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
