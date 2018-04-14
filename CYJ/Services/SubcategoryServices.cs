using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class SubcategoryServices
    {
        private readonly cyjdatabaseEntities _dbContext;

        public SubcategoryServices()
        {
            _dbContext = new cyjdatabaseEntities();
        }

        public List<SUBCATEGORy> GetAllSubCategories()
        {

            return _dbContext.SUBCATEGORIES.ToList();
        }

        public SUBCATEGORy GetSubCategoryById(int id)
        {
            return _dbContext.SUBCATEGORIES.SingleOrDefault(t => t.subcategoryID == id);
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }

    }
}