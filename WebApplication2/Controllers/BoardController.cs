using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        public readonly IDb db;

        public BoardController(IDb db)
        {
            this.db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Board> Get() => db.Boards;

        // GET api/values/5
        [HttpGet("{id}")]
        public Board Get(Guid id) => db.Boards.AsParallel().FirstOrDefault(d => d.Id == id);


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Board value) => db.Boards.Add(value);

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Board value)
        {
            var board = db.Boards.FirstOrDefault(d => d.Id == id);
            if (board != null)
            {
                db.Boards.Remove(board);
                value.Id = id;
                db.Boards.Add(value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var board = db.Boards.FirstOrDefault(d => d.Id == id);
            db.Boards.Remove(board);
        }
    }
}
