using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_domain.Entities
{
    public class Products
    {
        [Key] public int id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public DateTime? expire { get; set; }
        public bool active { get; set; }
        public int type { get; set; }
        public string? image { get; set; }

        [ForeignKey("type")] public Types? _type { get; set; }
    }
}