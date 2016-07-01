using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(FormatType.Metadata))]
    public partial class FormatType
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Format Type Id")]
            public System.Guid FormatTypeId { get; set; }

            [Required]
            [Display(Name = "Format Name")]
            [StringLength(10, ErrorMessage = "Please limit this field to 10 characters")]
            public string FormatName { get; set; }

            [Required]
            [Display(Name = "Format Description")]
            public string FormatDescription { get; set; }
        }
    }
}
