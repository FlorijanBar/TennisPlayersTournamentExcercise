using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tennis.Data;
using Tennis.Models;

namespace Tennis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly AppDbContext db;

        public CoachController(AppDbContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Coach coach)
        {
            var post = db.Coachs.Add(coach);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Coach coach)
        {
            var coachs = db.Coachs.FirstOrDefault(c => c.Id == id);
            if (coachs == null)
            {
                return NotFound();
            }
            coachs.Name = coach.Name;
            coachs.Players = coach.Players;
            db.SaveChanges();
            return Ok("Succesfuly updated");



        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] Coach coach)
        {
            var coachs= db.Coachs.FirstOrDefault(c=>c.Id==id);
            if(coachs == null)
            {
                return NotFound();
            }
            db.Remove(coachs);
            db.SaveChanges();
            return Ok("Succesfuly deleted");

        }

        [HttpGet("Getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var coachs=db.Coachs.FirstOrDefault(c=>c.Id==id);
            if(coachs==null)
            { return NotFound(); }
            return Ok(coachs);
        }

        [HttpGet("Getname/{name}")]
        public IActionResult GetByName(string name)
        {
            var coachs=db.Coachs.Where(c=>c.Name==name).ToList();
            if (coachs.Count==0) { return NotFound(); }
            return Ok(coachs);
        }

        [HttpGet]
        public IActionResult GetAllCoaches()
        {
            return Ok(db.Coachs);
        }

        [HttpGet("coach/{coach_name}")]
        public IActionResult GetCoachPlayerName(string coach_name) 
        {
            var coach = db.Coachs.FirstOrDefault(c => c.Name == coach_name);
            if(coach==null) { return NotFound(); }
            var players = coach.Players;
            if (players == null || !players.Any())
            {
                return NotFound($"Coach {coach_name} dont have a player");
            }
            return Ok(players.Select(c => new
            {
                Name = c.Name,
                Surname=c.Surname,
                Age = c.Age,
                Country = c.Country
            }).ToList());
        
        }


    }
}

