using EL_Marakby.Models;
using System.Collections.Generic;

namespace EL_Marakby.ViewModel
{
    public class InvoiceDTO
    {
        public Invoice Invoice { get; set; }

        public  List<InvoiceDetails> InvoiceDetails { get; set; }

    }
}
