using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System;
using EL_Marakby.Models;
using EL_Marakby.Reprositries;

namespace EL_Marakby.Controllers
{
    public class InvoiceDetailsController : Controller
    {

        InvoiceDetailsRepo InvoiceRepository;

        public InvoiceDetailsController(InvoiceDetailsRepo invoicerepo)
        {
            InvoiceRepository = invoicerepo;
        }

        public IActionResult Index()
        {
            List<InvoiceDetails> invoices = InvoiceRepository.GetAll();
            return View("Index", invoices);
        }
        public IActionResult New()
        {
            InvoiceDetails invoice = new InvoiceDetails();
            return View(invoice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(InvoiceDetails Invoices)
        {
            if (ModelState.IsValid == true)
            {
                try
                {

                    InvoiceDetails Invoice = new InvoiceDetails();

                    Invoice.Price = Invoices.Price;
                    Invoice.Qnty = Invoices.Qnty;
                    Invoice.Invoice_ID = Invoices.Invoice_ID;
                    Invoice.Item_ID = Invoices.Item_ID;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("InvoiceDetail_ID", "Select InvoiceDetail_ID");
                }

            }
            return View("New", Invoices);


        }
    }
}
