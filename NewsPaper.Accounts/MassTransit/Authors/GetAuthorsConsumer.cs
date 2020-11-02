using System;
using System.Collections.Generic;
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
    public class GetAuthorsConsumer : IConsumer<AuthorsRequestDto>
    {
        private readonly OperationAuthorsAccounts _operationAuthors;
        private readonly IMapper _mapper;
        public GetAuthorsConsumer(IMapper mapper, OperationAuthorsAccounts operationAuthors)
        {
            _mapper = mapper;
            _operationAuthors = operationAuthors;
        }

        public async Task Consume(ConsumeContext<AuthorsRequestDto> context)
        {
            try
            {
                var result = await _operationAuthors.GetAllAuthorsAsync();
                var authors = _mapper.Map<IEnumerable<AuthorDto>>(result);
                await context.RespondAsync(new AuthorsResponseDto
                {
                    AuthorsDto = authors
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
