using EL_Marakby.Models;
using EL_Marakby.ViewModel;
using System.Collections.Generic;

namespace EL_Marakby.Reprositries
{
    public interface IInvoiceRepo
    {
        int Delete(int id);
        int Edit(int id, Invoice invoice);
        List<Invoice> FindByDeptId(int invoiceid);
        Invoice FindById(int id);
        List<Invoice> GetAll();
        Invoice GetInvoice(int id);
        int Insert(InvoiceDTO invoice);
        int Savenew(int id, Invoice invoice);
    }
}