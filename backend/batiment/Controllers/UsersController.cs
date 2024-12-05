using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BatimentsApi.Models;
using batiment.Models;
using batiment.models;

namespace batiment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BatimentContext _context;

        public UsersController(BatimentContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
            public async Task<ActionResult<IEnumerable<user>>> GetUsers()

        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, user user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user>> PostUser(user user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using BatimentsApi.Models;
//using batiment.Models;
//using BatimentsApi.Services;

//namespace Batiment.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly BatimentContext _context;
//        private readonly AuthService _authService; // Déclarez le service d'authentification

//        public UsersController(BatimentContext context, AuthService authService) // Injectez le service
//        {
//            _context = context;
//            _authService = authService;
//        }

//        GET: api/Users
//       [HttpGet]
//        public async Task<ActionResult<IEnumerable<user>>> GetUsers()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        GET: api/Users/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<user>> GetUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            return user;
//        }

//        PUT: api/Users/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutUser(int id, user user)
//        {
//            if (id != user.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(user).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        POST: api/Users
//       [HttpPost]
//        public async Task<ActionResult<user>> PostUser(user user)
//        {
//            Hachage du mot de passe avant d'ajouter l'utilisateur
//            user.MotDePasse = _authService.HashPassword(user.MotDePasse);
//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
//        }

//        DELETE: api/Users/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            _context.Users.Remove(user);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool UserExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }
//    }
//}

