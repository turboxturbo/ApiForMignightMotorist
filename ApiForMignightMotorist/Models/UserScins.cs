using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiForMignightMotorist.Models
{
    public class UserScins
    {
        [Key]
        public int IdUserScins {  get; set; }
        [Required]
        [ForeignKey("Users")]
        public int IdUser {  get; set; }
        public Users Users { get; set; }
        [Required]
        [ForeignKey("Scins")]
        public int IdScin   { get; set; }
        public Scins Scins { get; set; }
    }
}
