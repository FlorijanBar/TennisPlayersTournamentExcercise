using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tennis.Data;
using Tennis.Models;

namespace Tennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext db;

        public PlayerController(AppDbContext context)
        {
            db=context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Player player) 
        {
            if (player == null)
            {
                return BadRequest("Podaci o igraču nisu ispravno poslani.");
            }
            var players = db.Players.Add(player);
            db.SaveChanges();
            return Ok(StatusCodes.Status201Created);
        
        }
    }
}
