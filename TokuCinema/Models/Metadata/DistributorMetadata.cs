using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Distributor.Metadata))]
    public partial class Distributor
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Distributor Id")]
            public System.Guid DistributorId { get; set; }

            [Required]
            [Display(Name = "Distributor Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters")]
            public string DistributorName { get; set; }

            [Required]
            [Display(Name = "Distributor Description")]
            [DataType(DataType.MultilineText)]
            public string DistributorDescription { get; set; }
        }
    }
}
