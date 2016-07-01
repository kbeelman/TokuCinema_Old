using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Company.Metadata))]
    public partial class Company
    {
        class Metadata
        {
            [Key]
            [Display(Name = "Company Id")]
            public System.Guid CompanyId { get; set; }

            [Required]
            [Display(Name = "Company Name")]
            [StringLength(25, ErrorMessage = "Please limit this field to 25 characters.")]
            public string CompanyName { get; set; }

            [Display(Name = "Image")]
            public byte[] Image { get; set; }
        }
    }
}
