using System.ComponentModel.DataAnnotations;

namespace ApiForMignightMotorist.Models
{
    public class Scins
    {
        [Key]
        public int IdScin { get; set; }
        public string NameScin { get; set; }
    }
}
