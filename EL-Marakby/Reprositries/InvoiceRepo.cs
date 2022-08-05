using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EL_Marakby.Models;
using EL_Marakby.ViewModel;
namespace EL_Marakby.Reprositries
{
    public class InvoiceRepo : IInvoiceRepo
    {
        Context db;
        public InvoiceRepo(Context _context)
        {
            db = _context;
        }
        public List<Invoice> GetAll()
        {
            return db.Invoice.ToList();
        }
        public Invoice GetInvoice(int id)
        {
            return db.Invoice.FirstOrDefault(i => i.Id == id);
        }
        public Invoice FindById(int id)
        {
            return db.Invoice.FirstOrDefault(s => s.Id == id);
        }

        public List<Invoice> FindByDeptId(int invoiceid)
        {
            return db.Invoice.Where(s => s.Id == invoiceid).ToList();
        }

        public int Insert(InvoiceDTO invoice)
        {
            db.Invoice.Add(invoice.Invoice);
            db.SaveChanges();
            int id = invoice.Invoice.Id;
            foreach (var item in invoice.InvoiceDetails)
            {
                item.Invoice_ID = id;
                db.InvoiceDetails.Add(item);
            }
            db.SaveChanges();
            return id;

        }
        public int Edit(int id, Invoice invoice)
        {
            Invoice oldInvoice = FindById(id);
            if (oldInvoice == null)
            {
                oldInvoice.Serial = invoice.Serial;
                oldInvoice.Date = invoice.Date;
                oldInvoice.Customer = invoice.Customer;
                return db.SaveChanges();
            }
            return 0;
        }
        public int Savenew(int id, Invoice invoice)
        {
            Invoice oldInvoice = FindById(id);
            if (oldInvoice != null)
            {
                oldInvoice.Serial = invoice.Serial;
                oldInvoice.Date = invoice.Date;
                oldInvoice.Customer = invoice.Customer;
                return db.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Invoice oldInvoice = FindById(id);
            db.Invoice.Remove(oldInvoice);
            return db.SaveChanges();
        }
    }
}
