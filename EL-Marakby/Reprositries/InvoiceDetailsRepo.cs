using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EL_Marakby.Models;
using EL_Marakby.ViewModel;

namespace EL_Marakby.Reprositries
{
    public class InvoiceDetailsRepo : IInvoiceDetailsRepo
    {
        Context db;
        public InvoiceDetailsRepo(Context _context)
        {
            db = _context;
        }
        public List<InvoiceDetails> GetAll()
        {
            return db.InvoiceDetails.ToList();
        }
        public InvoiceDetails GetInvoiceDetails(int id)
        {
            return db.InvoiceDetails.FirstOrDefault(i => i.Invoice_ID == id);
        }
        public InvoiceDetails FindById(int id)
        {
            return db.InvoiceDetails.FirstOrDefault(s => s.Invoice_ID == id);
        }

        public List<InvoiceDetails> FindByDeptId(int invoicedetailsid)
        {
            return db.InvoiceDetails.Where(s => s.Invoice_ID == invoicedetailsid).ToList();
        }

        public int Insert(InvoiceDetails invoice)
        {
            db.InvoiceDetails.Add(invoice);
            return db.SaveChanges();
        }
        public int Edit(int id, InvoiceDetails invoice)
        {
            InvoiceDetails oldInvoiceDetails = FindById(id);
            if (oldInvoiceDetails == null)
            {
                oldInvoiceDetails.Item = invoice.Item;
                oldInvoiceDetails.Qnty = invoice.Qnty;
                oldInvoiceDetails.Price = invoice.Price;
                return db.SaveChanges();
            }
            return 0;
        }
        public int Savenew(int id, InvoiceDetails invoice)
        {
            InvoiceDetails oldInvoiceDetails = FindById(id);
            if (oldInvoiceDetails != null)
            {
                oldInvoiceDetails.Item = invoice.Item;
                oldInvoiceDetails.Qnty = invoice.Qnty;
                oldInvoiceDetails.Price = invoice.Price;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            InvoiceDetails oldInvoiceDetails = FindById(id);
            db.InvoiceDetails.Remove(oldInvoiceDetails);
            return db.SaveChanges();
        }
    }
}