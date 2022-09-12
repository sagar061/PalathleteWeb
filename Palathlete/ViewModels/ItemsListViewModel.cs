using PalathleteLib.Models;
using System.Collections.Generic;

namespace Palathlete.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public string CurrentCategory { get; set; }
    }
}
