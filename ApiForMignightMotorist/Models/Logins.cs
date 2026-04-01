using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiForMignightMotorist.Models
{
    public class Logins
    {
        [Key]
        public int IdLogin { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int IdUser { get; set; }
        public Users Users { get; set; }
    }
}
