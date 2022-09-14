using System.Collections.Generic;
using Palathlete.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PalathleteLib.Interfaces;
using PalathleteLib.Models;

namespace Palathlete.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public ItemRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Item> AllItems
        {
            get
            {
                return _appDbContext.Items.Include(c => c.Category);
            }
        }

        public IEnumerable<Item> ItemsOfTheWeek
        {
            get
            {
                return _appDbContext.Items.Include(c => c.Category).Where(p => p.IsItemOfTheWeek);
            }
        }

        public Item GetItemById(int itemId)
        {
            return _appDbContext.Items.FirstOrDefault(p => p.ItemId == itemId);
        }
      
        public void CreateItem(Item item)
        {
            _appDbContext.Items.Add(item);
            _appDbContext.SaveChanges();
        }
        public Item UpdateItem(Item item)
        {
            _appDbContext.Items.Update(item);
            _appDbContext.SaveChanges();
            return item;
        }

        public void DeleteItem(Item item)
        {
            _appDbContext.Items.Remove(item);
            _appDbContext.SaveChanges();
        }
    }
}
