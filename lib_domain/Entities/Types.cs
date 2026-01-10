using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_domain.Entities
{
    public class Types
    {
        [Key] public int id { get; set; }
        public string? name { get; set; }

        [NotMapped] public virtual ICollection<Products>? products { get; set; }
    }
}