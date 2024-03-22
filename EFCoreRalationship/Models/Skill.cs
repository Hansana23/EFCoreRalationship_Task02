using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreRalationship.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Damage { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}
