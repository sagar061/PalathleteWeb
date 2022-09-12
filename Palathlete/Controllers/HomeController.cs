using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalathleteLib.Models;
using Palathlete.ViewModels;
using PalathleteLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Palathlete.Controllers
{
    public class HomeController : Controller
    {     
        private readonly IItemRepository _itemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ItemsOfTheWeek = _itemRepository.ItemsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
