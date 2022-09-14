using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalathleteLib.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
