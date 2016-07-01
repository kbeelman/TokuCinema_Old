using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Region.Metadata))]
    public partial class Region
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Region Id")]
            public System.Guid RegionId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Region Type Id")]
            public System.Guid RegionTypeId { get; set; }
        }
    }
}
