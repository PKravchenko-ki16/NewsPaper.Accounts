using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.Models
{
    [Table("Editor")]
    public class Editor : DomainObject
    {
        public Editor() { }

        public Editor(Guid id, Guid identityGuid)
        {
            Id = id;
            IdentityGuid = identityGuid;
        }

        [Column("editor_id")]
        public override Guid Id { get; }

        [Required]
        [Column("identity_guid")]
        public Guid IdentityGuid { get; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Column("nike_name")]
        public string NikeName { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 5)]
        [Column("full_name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string Email { get; set; }

        [Column("count_completed_articles")]
        public int CountСompletedArticles { get; set; }

        [Column("count_under_revision_articles")]
        public int CountUnderRevisionArticles { get; set; }
    }
}