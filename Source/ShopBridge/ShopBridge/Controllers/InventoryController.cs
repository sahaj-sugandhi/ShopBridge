using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Model;
using ShopBridge.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridge.Controllers
{
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        /// <summary>
        /// GET: <controller>
        /// To Get List of all the Items present in Inventory
        /// </summary>
        /// <returns>List of Products present in Inventory Table</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_inventoryService.GetProducts());
        }

        /// <summary>
        /// POST: <controller>
        /// To Insert a Product into Inventory Table
        /// </summary>
        /// <param name="product">product that needs to be added to database</param>
        /// <returns>201 created status code for success, otherwise internal server error 500</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody]Product product)
        {
            bool flag = _inventoryService.AddProduct(product);
            if (flag)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// PUT: {id} 
        /// Replace the product with specified id to the passed product in body
        /// </summary>
        /// <param name="id">Product that needs to be updated.</param>
        /// <param name="product">New Values for Product.</param>
        /// <returns>200 with updated product, otherwise 500 for error and 400 if id is not present.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            var products = _inventoryService.GetProducts();
            Product temp = products.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                product.Id = id;
                bool flag = _inventoryService.UpdateProduct(product);
                if (flag)
                {
                    return Ok(product);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// DELETE: {id} 
        /// Delete the product with specified id to the passed product in body
        /// </summary>
        /// <param name="id">Product that needs to be updated.</param>
        /// <returns>200 with deleted product, otherwise 500 for error and 400 if id is not present.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            var products = _inventoryService.GetProducts();
            Product product = products.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                product.Id = id;
                bool flag = _inventoryService.DeleteProduct(id);
                if (flag)
                {
                    return Ok(product);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
