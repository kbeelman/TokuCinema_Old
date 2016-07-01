using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Packaging.Metadata))]
    public partial class Packaging
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Packaging Id")]
            public System.Guid PackagingId { get; set; }

            [Required]
            [Display(Name = "Packaging Description")]
            public string PackagingDescription { get; set; }

            [Required]
            [Display(Name = "Packaging Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters")]
            public string PackagingName { get; set; }
        }
    }
}
