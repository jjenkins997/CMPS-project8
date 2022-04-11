using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p8_c00227447_c00409618
{
    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [Column(TypeName = "int                  identity")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "nvarchar(40)")]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "nvarchar(40)")]
        public string? City { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string? Country { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Phone { get; set; }
    }
}
