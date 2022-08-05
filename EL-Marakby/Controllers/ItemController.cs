using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System;
using EL_Marakby.Models;
using EL_Marakby.Reprositries;

namespace EL_Marakby.Controllers
{
    public class ItemController : Controller
    {
        ItemRepo ItemRepository;

        public ItemController(ItemRepo itemRepo)
        {
            ItemRepository = itemRepo;
        }

        public IActionResult Index()
        {
            List<Item> items = ItemRepository.GetAll();
            return View("Index", items);
        }
        public IActionResult New()
        {
            Item item = new Item();
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Item items)
        {
            if (ModelState.IsValid == true)
            {
                try
                {

                    Item item = new Item();

                    item.Name = items.Name;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Item_ID", "Select Item_ID");
                }

            }
            return View("New", items);


        }

    }
}
