using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p8_c00227447_c00409618
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column(TypeName = "int                  identity")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; } = null!;
        [Column(TypeName = "int")]
        public long SupplierId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public byte[]? UnitPrice { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? Package { get; set; }
        [Column(TypeName = "bit")]
        public byte[] IsDiscontinued { get; set; } = null!;
    }
}
