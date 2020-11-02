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
    public class GetGuidUserConsumer : IConsumer<GuidUserRequestDto>
    {
        private readonly OperationUsersAccounts _operationUsers;
        public GetGuidUserConsumer(OperationUsersAccounts operationUsers)
        {
            _operationUsers = operationUsers;
        }

        public async Task Consume(ConsumeContext<GuidUserRequestDto> context)
        {
            try
            {
                var userGuid = await _operationUsers.GetGuidByNikeNameUserAsync(context.Message.NikeNameUser);
                await context.RespondAsync(new GuidUserResponseDto
                {
                    UserGuid = userGuid
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
