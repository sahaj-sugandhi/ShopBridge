using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Model
{
    public class Product
    {
        /// <summary>
        /// Id of the product
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// name of the product
        /// </summary>
        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        /// <summary>
        /// description of the product
        /// </summary>
        [Required]
        [StringLength(200)]
        public string ProductDescription { get; set; }

        /// <summary>
        /// price of the product
        /// </summary>
        [Required]
        [Range(0,9_999_999_999.99)]
        public decimal Price { get; set; }
    }
}
