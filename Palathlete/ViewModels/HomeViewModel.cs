using PalathleteLib.Models;
using System.Collections.Generic;

namespace Palathlete.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Item> ItemsOfTheWeek { get; set; }
    }
}
