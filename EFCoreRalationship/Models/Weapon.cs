using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreRalationship.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }

    }
}
