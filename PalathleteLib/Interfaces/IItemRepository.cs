using PalathleteLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalathleteLib.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> AllItems { get; }
        IEnumerable<Item> ItemsOfTheWeek { get; }
        Item GetItemById(int itemId);
        void CreateItem(Item item);
        Item UpdateItem(Item item);
        void DeleteItem(Item item);
    }
}
