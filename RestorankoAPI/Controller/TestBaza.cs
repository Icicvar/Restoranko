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
        public  ActionResult<IEnumerable<Item>> GetAllItems()
        {
            try
            {
                var allItems = _dbContext.Items.Select(dbItems => new Item
                {
                    Iditem = dbItems.Iditem,
                    OrderId = dbItems.OrderId,
                    ProductId = dbItems.ProductId,
                    Amount = dbItems.Amount,
                    BarmanId = dbItems.BarmanId,
                    Barman = dbItems.Barman,
                    Order = dbItems.Order,
                    Product = dbItems.Product,
                });
                return Ok(allItems);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }  
        // id je samo parametar ez ekipa iscrpjen sam IIS me ubio 
        [HttpGet("{id}")] 
        public  ActionResult< Item> GetItem(int id)
        {
            try
            {

                var dbItem = _dbContext.Items.FirstOrDefault(x => x.Iditem == id);
                if (dbItem==null)
                {
                    return NotFound();
                }
                return Ok(new Item
                {
                    Iditem = dbItem.Iditem,
                    OrderId = dbItem.OrderId,
                    ProductId = dbItem.ProductId,
                    Amount = dbItem.Amount,
                    BarmanId = dbItem.BarmanId,
                    Barman = dbItem.Barman,
                    Order = dbItem.Order,
                    Product = dbItem.Product,
                });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost()]
        public ActionResult<Item> CreateItem(Item request)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                var dbItem = new Item
                {
                    Iditem = request.Iditem,
                    OrderId = request.OrderId,
                    ProductId = request.ProductId,
                    Amount = request.Amount,
                    BarmanId = request.BarmanId,
                    Barman = request.Barman,
                    Order = request.Order,
                    Product = request.Product,
                };
                _dbContext.Items.Add(dbItem);

                _dbContext.SaveChanges();

                return Ok(new Item
                {
                    Iditem = dbItem.Iditem,
                    OrderId = dbItem.OrderId,
                    ProductId = dbItem.ProductId,
                    Amount = dbItem.Amount,
                    BarmanId = dbItem.BarmanId,
                    Barman = dbItem.Barman,
                    Order = dbItem.Order,
                    Product = dbItem.Product,

                });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
