using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class ModelsFactory
    {
        public CartProductDto CreateProductrCartDto(CartProduct cartProduct)
        {
            return new CartProductDto()
            {
                ID = cartProduct.ID,
                productId = cartProduct.ProductID,
                cartId = cartProduct.Cart.ID,
                ProductName = cartProduct.Product.ProductName,
                ProductPrice = cartProduct.Product.Price,
                ProductDiscount = cartProduct.Product.Discount,
                ProductImage = cartProduct.Product.Image,
                ProductQuantity = cartProduct.Product.Quantity
            };
        }
        public WishListProductDto CreateProductrWhishlistDto(ProductWishList WishProduct)
        {
            return new WishListProductDto()
            {
                ID = WishProduct.ID,
                productId = WishProduct.ProductID,
                whishlistId = WishProduct.WishList.ID,
                ProductName = WishProduct.Product.ProductName,
                ProductPrice = WishProduct.Product.Price,
                ProductDiscount = WishProduct.Product.Discount,
                ProductImage = WishProduct.Product.Image,
                ProductQuantity = WishProduct.Product.Quantity
            };
        }

        public ProductDto Create(Product product)
        {
            return new ProductDto()
            {
                ID = product.ID,
                ProductName = product.ProductName,
                Price = product.Price,
                Image = product.Image,
                Description = product.Description,
                CategoryName = product.category.CategoryName,
                Quantity = product.Quantity,
                Discount = product.Discount,
                CategoryID = product.CategoryID
            };
        }
        public CategoryDto CreateCategory(Category category)
        {
            return new CategoryDto()
            {
                ID = category.ID,
                CategoryName = category.CategoryName
            };
        }
        public BrandsDto CreateBrand(Brands brand)
        {
            return new BrandsDto()
            {
                ID = brand.ID,
                BrandName = brand.BrandName
            };
        }
    }
}