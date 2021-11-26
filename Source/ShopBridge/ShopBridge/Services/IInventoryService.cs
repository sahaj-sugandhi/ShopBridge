using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Services
{
    public interface IInventoryService
    {
        IEnumerable<Product> GetProducts();

        bool AddProduct(Product product);

        bool DeleteProduct(int id);

        bool UpdateProduct(Product product);
    }
}
