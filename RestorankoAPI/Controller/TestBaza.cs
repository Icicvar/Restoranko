using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestorankoAPI.Models;

namespace RestorankoAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestBazaController : ControllerBase
    {
        private readonly RestoranMenagmentContext _dbContext;
        public TestBazaController(RestoranMenagmentContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("[action]")] 
        public bool TestConnection()
        {
            return _dbContext.Database.CanConnect();
        }   
        [HttpGet("[action]")] 
        public IEnumerable<Item> GetAll()
        {
            return _dbContext.Items;
        }
    }
}
