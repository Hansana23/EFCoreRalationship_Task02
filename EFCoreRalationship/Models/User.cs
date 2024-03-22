using System.ComponentModel.DataAnnotations;

namespace EFCoreRalationship.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public List<Character> Characters { get; set; }  // One user can have many characters
    }
}
