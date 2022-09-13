using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Palathlete.ViewModels;
using Palathlete.Data;
using PalathleteLib.Interfaces;
using PalathleteLib.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Palathlete.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;

        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Item> items;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                items = _itemRepository.AllItems.OrderBy(p => p.ItemId);
                currentCategory = "All items";
            }
            else
            {
                items = _itemRepository.AllItems.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.ItemId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new ItemsListViewModel
            {
                Items = items,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Categories = new SelectList(_categoryRepository.AllCategories.ToList(), "Id", "Categories");
            //var dropdownsData = await _service.GetDropdownsValues();
            var dropdownData = _categoryRepository.AllCategories;
            ViewBag.Categories = new SelectList(dropdownData, "Id", "Categories");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Item item)
        {
            //ViewBag.Categories = new SelectList(_categoryRepository.AllCategories.ToList(), "Id", "Categories");
            var dropdownData = _categoryRepository.AllCategories;
            ViewBag.Categories = new SelectList(dropdownData, "Id", "Categories");
            _itemRepository.CreateItem(item);
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _itemRepository.GetItemById(id);
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            _itemRepository.UpdateItem(item);
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _itemRepository.GetItemById(id);
            return View(item);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Item item)
        {
            _itemRepository.DeleteItem(item);
            return View();
        }
    }
}

