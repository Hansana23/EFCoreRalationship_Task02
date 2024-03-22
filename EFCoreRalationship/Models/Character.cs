using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreRalationship.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string RPGClass { get; set; } = string.Empty;

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } //Character can only have one user.

        public Weapon Weapon { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
