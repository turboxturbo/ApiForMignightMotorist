using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiForMignightMotorist.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public int Coins { get; set; }
        public string SelectedScin {  get; set; }
    }
}
