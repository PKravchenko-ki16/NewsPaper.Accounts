# NewsPaper.Accounts

It is an ASP.NET Core 3.1 based microservice using RabbitMQ with MassTransit, EntityFramework Core with MS SQL Server as well as Bogus, AutoMapper, etc.

## Project structure

- BusinessLayer

The business layer is responsible for performing operations on data coming from the DAL (Data Access Layer).
- DAL

The Data Access Layer is responsible for providing simplified and data access. Uses Models to access the database.
- Models

The Model Layer is responsible for storing data models for accessing the database.
- Accounts (directly the web project itself)

## Consumer 

Uses `Multiple Response Types` technique

```C#
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
```

## ConfigureServices MassTransit for RabbitMq

Consumer is added to MassTransit in ConfigureServicesMassTransitRabbitMq

```C#
public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
{
    var section = configuration.GetSection("MassTransit");
    ConfigureServicesMassTransit.ConfigureServices(services, configuration, new MassTransitConfiguration()
    {
    IsDebug = section.GetValue<bool>("IsDebug"),
    ServiceName = "Accounts",
    Configurator = busMassTransit => {
            busMassTransit.AddConsumer<GetEditorConsumer>();
            busMassTransit.AddConsumer<GetEditorsConsumer>();
            busMassTransit.AddConsumer<GetGuidEditorConsumer>();
            busMassTransit.AddConsumer<GetNikeNameEditorConsumer>();

            busMassTransit.AddConsumer<GetAuthorConsumer>();
            busMassTransit.AddConsumer<GetAuthorsConsumer>();
            busMassTransit.AddConsumer<GetNikeNameAuthorConsumer>();
            busMassTransit.AddConsumer<GetGuidAuthorConsumer>();

            busMassTransit.AddConsumer<GetUserConsumer>();
            busMassTransit.AddConsumer<GetUsersConsumer>();
            busMassTransit.AddConsumer<GetGuidUserConsumer>();
            busMassTransit.AddConsumer<GetNikeNameUserConsumer>();

            busMassTransit.AddConsumer<AccountsForCreateArticleConsumer>(); }
    });
}
```

## Links to project repositories
- :white_check_mark:[NewsPaper Review](https://github.com/PKravchenko-ki16/NewsPaper)
- :white_check_mark:[NewsPaper.MassTransit.Configuration](https://github.com/PKravchenko-ki16/NewsPaper.MassTransit.Configuration)
- :white_check_mark:[NewsPaper.MassTransit.Contracts](https://github.com/PKravchenko-ki16/NewsPaper.MassTransit.Contracts)
- :white_check_mark:[NewsPaper.IdentityServer](https://github.com/PKravchenko-ki16/NewsPaper.IdentityServer)
- :white_check_mark:[Newspaper.GateWay](https://github.com/PKravchenko-ki16/Newspaper.GateWay)
- :white_check_mark:NewsPaper.Accounts
- :white_check_mark:[NewsPaper.Articles](https://github.com/PKravchenko-ki16/NewsPaper.Articles)
- :white_check_mark:[NewsPaper.GatewayClientApi](https://github.com/PKravchenko-ki16/NewsPaper.GatewayClientApi)
- :white_check_mark:[NewsPaper.Client.Mvc](https://github.com/PKravchenko-ki16/NewsPaper.Client.Mvc)
