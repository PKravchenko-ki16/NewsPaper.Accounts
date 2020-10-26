using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.Models
{
    [Table("User")]
    public class User : IDomainObject
    {
        [Key]
        [Column("user_id")]
        public Guid Id { get; }

        [Required]
        [Column("identity_guid")]
        public Guid IdentityGuid { get; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Column("nike_name")]
        public string NikeName { get; set; }
    }
}