using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Standard.Metadata))]
    public partial class Standard
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Standard Id")]
            public System.Guid StandardId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Standard Type Id")]
            public System.Guid StandardTypeID { get; set; }
        }
    }
}
