using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System;
using EL_Marakby.Models;
using EL_Marakby.Reprositries;
using EL_Marakby.ViewModel;

namespace EL_Marakby.Controllers
{
    public class InvoiceController : Controller
    {
        IInvoiceRepo InvoiceRepository;
        IItemRepo ItemRepository;


        public InvoiceController(IInvoiceRepo invoicerepo, IItemRepo itemRepository)
        {
            InvoiceRepository = invoicerepo;
            ItemRepository = itemRepository;
        }

        public IActionResult Index()
        {

            ViewBag.items = ItemRepository.GetAll();
            return View("Index");
        }
        public IActionResult New()
        {
            Invoice invoice = new Invoice();
            return View(invoice);
        }
        [HttpPost]
        public IActionResult SaveNew([FromBody]InvoiceDTO invoice)
        {
            if(ModelState.IsValid == true)
            {
                InvoiceRepository.Insert(invoice);
                return Ok();
            }
            return View("Index", invoice);

        }
    }
}
