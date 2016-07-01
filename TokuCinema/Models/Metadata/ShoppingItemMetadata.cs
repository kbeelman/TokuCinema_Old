using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(ShoppingItem.Metadata))]
    public partial class ShoppingItem
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Shopping Item Id")]
            public System.Guid ShoppingItemId { get; set; }

            [Required]
            [Display(Name = "Company Id")]
            public System.Guid CompanyId { get; set; }

            [Required]
            [Display(Name = "Purchase Link")]
            public string PurchaseLink { get; set; }
        }
    }
}
