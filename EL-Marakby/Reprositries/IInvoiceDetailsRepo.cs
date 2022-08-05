using EL_Marakby.Models;
using System.Collections.Generic;

namespace EL_Marakby.Reprositries
{
    public interface IInvoiceDetailsRepo
    {
        int Delete(int id);
        int Edit(int id, InvoiceDetails invoice);
        List<InvoiceDetails> FindByDeptId(int invoicedetailsid);
        InvoiceDetails FindById(int id);
        List<InvoiceDetails> GetAll();
        InvoiceDetails GetInvoiceDetails(int id);
        int Insert(InvoiceDetails invoice);
        int Savenew(int id, InvoiceDetails invoice);
    }
}