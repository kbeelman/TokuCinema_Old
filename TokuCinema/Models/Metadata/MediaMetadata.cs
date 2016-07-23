using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokuCinema.Domain;

namespace TokuCinema.Models
{
    [MetadataType(typeof(Medium.Metadata))]
    public partial class Medium : IExposeProperty
    {
        public string ExposePropertyValue(string propertyName)
        {
            string propertyValue = "";

            propertyValue = GetType().GetProperty(propertyName).GetValue(this, null).ToString();

            return propertyValue;
        }

        class Metadata
        {
            [Key]
            [Display(Name = "Media Id")]
            public System.Guid MediaId { get; set; }

            [Required]
            [Display(Name = "Offical Title")]
            [StringLength(50, ErrorMessage = "Please limit this field to 100 characters.")]
            public string MediaOfficialTitle { get; set; }

            [Required]
            [Display(Name = "Media Description")]
            [DataType(DataType.MultilineText)]
            public string MediaDescription { get; set; }

            [Display(Name = "Wikipedia Link")]
            public string WikipediaLink { get; set; }

            [Display(Name = "Image Link")]
            public string MediaImageLink { get; set; }
        }
    }
}
