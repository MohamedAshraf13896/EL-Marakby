using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EL_Marakby.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Serial Is Required")]
        [StringLength(14, ErrorMessage = "Serial length can't be more than 14.")]

        public string Serial { get; set; }
        [Required(ErrorMessage ="Customer Is Required")]
        [RegularExpression("^([A-Z]|[a-z]){3,10}$", ErrorMessage = "Customer Name Must Be Characters Only And Max Lenght 10 Char")]
        public string Customer { get; set; }
        [Required(ErrorMessage = "Date Is Required")]
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }

    }
}
