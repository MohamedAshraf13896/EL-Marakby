using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL_Marakby.Models
{
    public class InvoiceDetails
    {
        [Required]
        public int Qnty { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey("Invoice")]
        public int Invoice_ID { get; set; }
        public Invoice Invoice { get; set; }
        [ForeignKey("Item")]
        public int  Item_ID { get; set; }
        public Item Item { get; set; }
    }
}
