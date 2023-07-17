using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPIEFCore.Repository;
using ProductAPIEFCore.Model;
using log4net.Config;
using log4net.Core;
using log4net;
using System.Reflection;

namespace ProductAPIEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProdRepo<Product> prodrepo;

        private void LogError(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Info(message);
        }

        public ProductController(IProdRepo<Product> prepo)
        {
            prodrepo = prepo;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            LogError("Get All products is called");
            List<Product> products = prodrepo.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            prodrepo.AddNewProduct(p);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Edit(int id,Product p)
        {
            LogError($"Product #{id}: {p.Pname},{p.Price}");   
            prodrepo.UpdateProduct(id,p);
            return Ok();
            }
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
           
                if (id == null)
                {
                    return BadRequest("Please enter the ID");
                }
                Product p = prodrepo.DeleteProduct(id);
                if (p == null)
                    return NotFound();
                else
                    return Ok();
            
           
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<ActionResult> GetProdbyID(int id)
        {
            LogError(id + " is retrieved");
            Product p= prodrepo.GetProductById(id).Result;
            return Ok(p);
        }

    }
}
