using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class CategoryDto
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public List<ProductDto> products { get; set; }
    }
    public class ProductDto
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int CategoryID { get; set; }
    }
    public class BrandsDto
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
    }
    public class CartProductDto
    {
        public int ID { get; set; }
        public int productId { get; set; }
        public int  cartId { get; set; }

        public string ProductImage { get; set; }
        public double ProductPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductDiscount { get; set; }
        public int ProductQuantity { get; set; }
        public double NetPrice {
            get {
                return ProductPrice-(ProductQuantity * ProductDiscount/100);
            }
        }
    }

    public class WishListProductDto
    {
        public int ID { get; set; }
        public int productId { get; set; }
        public int whishlistId { get; set; }
        public string ProductImage { get; set; }
        public double ProductPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductDiscount { get; set; }
        public int ProductQuantity { get; set; }
    }
}
