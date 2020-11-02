using System;
using System.Threading.Tasks;
using MassTransit;
using NewsPaper.Accounts.BusinessLayer;
using NewsPaper.Accounts.Models.Exceptions;
using NewsPaper.MassTransit.Contracts.DTO.Exception.User;
using NewsPaper.MassTransit.Contracts.DTO.Requests.User;
using NewsPaper.MassTransit.Contracts.DTO.Responses.User;

namespace NewsPaper.Accounts.MassTransit.Users
{
    public class GetNikeNameUserConsumer : IConsumer<NikeNameUserRequestDto>
    {
        private readonly OperationUsersAccounts _operationUsers;
        public GetNikeNameUserConsumer(OperationUsersAccounts operationUsers)
        {
            _operationUsers = operationUsers;
        }

        public async Task Consume(ConsumeContext<NikeNameUserRequestDto> context)
        {
            try
            {
                var userNikeName = await _operationUsers.GetNikeNameByGuidUserAsync(context.Message.UserGuid);
                await context.RespondAsync(new NikeNameUserResponseDto
                {
                    NikeNameUser = userNikeName
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
