using System;
using System.ComponentModel.DataAnnotations;

namespace lib_domain.Entities
{
    public class Audits
    {
        [Key] public int id { get; set; }
        public string? action { get; set; }
        public string? description { get; set; }
        public DateTime? date { get; set; } = DateTime.Now;
    }
}