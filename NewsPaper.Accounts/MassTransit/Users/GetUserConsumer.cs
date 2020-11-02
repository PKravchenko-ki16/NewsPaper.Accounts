using System;
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
    public class GetUserConsumer : IConsumer<UserRequestDto>
    {
        private readonly OperationUsersAccounts _operationUsers;
        private readonly IMapper _mapper;
        public GetUserConsumer(IMapper mapper, OperationUsersAccounts operationUsers)
        {
            _mapper = mapper;
            _operationUsers = operationUsers;
        }

        public async Task Consume(ConsumeContext<UserRequestDto> context)
        {
            try
            {
                var result = await _operationUsers.GetByIdUserAsync(context.Message.UserGuid);
                var user = _mapper.Map<UserDto>(result);
                await context.RespondAsync(new UserResponseDto
                {
                    UserDto = user
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
