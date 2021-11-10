using Microsoft.AspNetCore.Mvc;


namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private BookService bookservice = new BookService();
        // GET: api/<PhoneBookController>
        [HttpGet]
        public Task<List<Book>> Get()
        {
            return Task.Run(() => bookservice.Get());
        }

        // GET api/<PhoneBookController>/Smith
        [HttpGet("{name}")]
        public Task<Book> Get(string name)
        {
            return Task.Run(() => bookservice.Get(name));
        }

        // POST api/<PhoneBookController>
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            Task.Run(() => bookservice.Create(value));
        }

        // PUT api/<PhoneBookController>/Smith
        [HttpPut("{name}")]
        public void Put(string name, [FromBody] Book value)
        {
            Task.Run(() => bookservice.Update(name, value));
        }

        // DELETE api/<PhoneBookController>/Smith
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            Task.Run(() => bookservice.Delete(name));
        }
    }
}
