using MebExam.Source.Context;
using MebExam.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MebExam.Source.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository()
        {
            _context = new AppDbContext();
        }
        public int Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(string key)
        {
            throw new NotImplementedException();
        }

        public Category Find(string key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetQueryable()
        {
            return _context.Categories;
        }

        public int Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
