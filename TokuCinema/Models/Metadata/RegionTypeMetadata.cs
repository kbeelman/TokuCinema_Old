using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TokuCinema.Models
{
    [MetadataType(typeof(RegionType))]
    public partial class RegionType
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Region Type Id")]
            public System.Guid RegionTypeId { get; set; }

            [Required]
            [Display(Name = "Region Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters")]
            public string RegionName { get; set; }

            [Required]
            [Display(Name = "Region Description")]
            public string RegionDescription { get; set; }
        }
    }
}
