﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.Models
{
    [Table("Author")]
    public class Author : IDomainObject
    {
        [Key]
        [Column("author_id")]
        public Guid Id { get; }

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
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }
    }
}