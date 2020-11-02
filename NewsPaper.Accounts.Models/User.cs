using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.Models
{
    [Table("User")]
    public class User : DomainObject
    {
        public User() { }

        public User(Guid id, Guid identityGuid)
        {
            Id = id;
            IdentityGuid = identityGuid;
        }

        public User(string nikeName)
        {
            NikeName = nikeName;
        }

        [Column("user_id")]
        public override Guid Id { get; }

        [Required]
        [Column("identity_guid")]
        public Guid IdentityGuid { get; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Column("nike_name")]
        public string NikeName { get; set; }
    }
}