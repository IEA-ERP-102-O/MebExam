using MebExam.Source.Context;
using MebExam.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MebExam.Source.Repositories
{
    public class ProductRepository
    {

        private readonly AppDbContext _context;
        public ProductRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string key)
        {
            var product = Find(key);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product Find(string key)
        {
            return _context.Products.Find(key);
        }

        public IQueryable<Product> GetQueryable()
        {
            return _context.Products;
        }

        public void Update(Product entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
