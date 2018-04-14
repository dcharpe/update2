using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class CategoryServices
    {
        private readonly cyjdatabaseEntities _dbContext;

        public CategoryServices()
        {
            _dbContext = new cyjdatabaseEntities();
        }

        public List<CATEGORy> GetAllCategories()
        {

            return _dbContext.CATEGORIES.ToList();
        }
        public CATEGORy GetCategoryById(int id)
        {
            return _dbContext.CATEGORIES.SingleOrDefault(t => t.categoryID == id);
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }

    }
}