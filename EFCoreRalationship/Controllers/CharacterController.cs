using EFCoreRalationship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRalationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly UserCharacterDbContext _context;

        public CharacterController(UserCharacterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(c => c.UserId == userId)
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .ToListAsync();

            return characters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> PostCharacter(CharacterCreateDTO character)
        {
            var user = await _context.Users.FindAsync(character.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var newCharacter = new Character
            {
                Name = character.Name,
                RPGClass = character.RPGClass,
                User = user
            };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }

        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> PostWeapon(PostWeaponDTO weapon)
        {
            var character = await _context.Characters.FindAsync(weapon.CharacterId);
            if (character == null)
            {
                return NotFound();
            }

            var newWeapon = new Weapon
            {
                Name = weapon.Name,
                Damage = weapon.Damage,
                Character = character
            };
            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return character;
        }

        [HttpPost("skills")]
        public async Task<ActionResult<Character>> PostSkill(PostSkillDTO skill)
        {
            var character = await _context.Characters.Where(c => c.Id == skill.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();
            if (character == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills.FindAsync(skill.SkillId);
            if (skills == null)
            {
                return NotFound();
            }

            character.Skills.Add(skills);
            await _context.SaveChangesAsync();

            return character;
        }

    }
}

