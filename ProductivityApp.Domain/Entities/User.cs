using ProductivityApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityApp.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        
        public byte[] PasswordHash { get; set; } = new byte[] { };
        
        public byte[] PasswordSalt { get; set; } = new byte[] { };

        public RoleEnum Role { get; set; } = RoleEnum.User;

        public List<Session> Sessions { get; set; } = new List<Session>() { };

        public List<Reminder> Reminders { get; set; } = new List<Reminder>() { };


    }
}
