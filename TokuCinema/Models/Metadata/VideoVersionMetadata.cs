using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TokuCinema.Domain;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoVersion.Metadata))]
    public partial class VideoVersion : IExposeProperty
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
            [Display(Name = "Video Version Id")]
            public System.Guid VideoVersionId { get; set; }

            [Required]
            [Display(Name = "Video Version Type Id")]
            public System.Guid VideoVersionTypeId { get; set; }

            [Required]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }
            
        }
    }
}
