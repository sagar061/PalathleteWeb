using System.Collections.Generic;

namespace PalathleteLib.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
