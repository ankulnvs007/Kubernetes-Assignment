using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Product.API.Models;
using Product.API.Data.DbContexts;
using Product.API.Repositories.IRepositories;

namespace Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _context.Products.ToList();
        }

        public ProductModel GetProductById(int productId)
        {
            return _context.Products
                .SingleOrDefault(p => p.ProductId == productId);
        }

        public ProductModel CreateProduct(ProductModel product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool UpdateProduct(ProductModel product)
        {
            var existingProduct = _context.Products
                .SingleOrDefault(p => p.ProductId == product.ProductId);

            if (existingProduct == null)
            {
                return false;
            }

            // Update properties
            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;

            _context.Products.Update(existingProduct);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int productId)
        {
            var product = _context.Products
                .SingleOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return true;
        }
    }
}
