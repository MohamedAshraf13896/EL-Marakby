using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EL_Marakby.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }

    }
}
