using System.Collections.Generic;
using System;
using Palathlete.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PalathleteLib.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

    }
}
