using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace p8_c00227447_c00409618
{
    [Table("OrderItem")]
    public partial class OrderItem
    {
        [Key]
        [Column(TypeName = "int                  identity")]
        public long Id { get; set; }
        [Column(TypeName = "int")]
        public long OrderId { get; set; }
        [Column(TypeName = "int")]
        public long ProductId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public byte[] UnitPrice { get; set; } = null!;
        [Column(TypeName = "int")]
        public long Quantity { get; set; }
    }
}
