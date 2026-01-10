using System.ComponentModel.DataAnnotations;

namespace lib_domain.Entities
{
    public class Users
    {
        [Key] public int id { get; set; }
        public string? name { get; set; }
        public string? password { get; set; }
        public bool active { get; set; }
    }
}