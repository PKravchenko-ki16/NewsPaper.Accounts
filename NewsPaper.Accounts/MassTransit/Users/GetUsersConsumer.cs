using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.User;
using NewsPaper.MassTransit.Contracts.DTO.Models.User;
using NewsPaper.MassTransit.Contracts.DTO.Requests.User;
using NewsPaper.MassTransit.Contracts.DTO.Responses.User;

namespace NewsPaper.Accounts.MassTransit.Users
{
    public class GetUsersConsumer : IConsumer<UsersRequestDto>
    {
        private readonly OperationUsersAccounts _operationUsers;
        private readonly IMapper _mapper;
        public GetUsersConsumer(IMapper mapper, OperationUsersAccounts operationUsers)
        {
            _mapper = mapper;
            _operationUsers = operationUsers;
        }

        public async Task Consume(ConsumeContext<UsersRequestDto> context)
        {
            try
            {
                var result = await _operationUsers.GetAllUsersAsync();
                var users = _mapper.Map<IEnumerable<UserDto>>(result);
                await context.RespondAsync(new UsersResponseDto
                {
                    UsersDto = users
                });
            }
            catch (NoUserFoundException e)
            {
                await context.RespondAsync(new NoUserFound
                {
                    CodeException = e.CodeException,
                    MassageException = $"{e.Message}"
                });
            }
            catch (Exception e)
            {
                await context.RespondAsync(new NoUserFound
                {
                    MassageException = $"{e.Message}"
                });
            }
        }
    }
}
