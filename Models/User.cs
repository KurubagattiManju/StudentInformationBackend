using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInfoApp.Models
{

    public class User
    {
        [Key]

        public int UserIdnew { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email_Id { get; set; }
    }
}
