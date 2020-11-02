using NewsPaper.Accounts.Mappings.Base;
using NewsPaper.Accounts.Models;
using NewsPaper.MassTransit.Contracts.DTO.Models.Author;
using NewsPaper.MassTransit.Contracts.DTO.Models.Editor;
using NewsPaper.MassTransit.Contracts.DTO.Models.User;

namespace NewsPaper.Accounts.Mappings
{
    public class MappingArticles : MapperConfigurationBase
    {
        public MappingArticles()
        {
            CreateMap<Author,AuthorDto>();
            CreateMap<Editor, EditorDto>();
            CreateMap<User, UserDto>();
        }
    }
}
