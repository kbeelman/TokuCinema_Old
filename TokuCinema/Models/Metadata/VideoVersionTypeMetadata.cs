using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TokuCinema.Domain;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoVersionType.Metadata))]
    public partial class VideoVersionType : IExposeProperty
    {
        public string ExposePropertyValue(string propertyName)
        {
            string propertyValue = "";

            propertyValue = GetType().GetProperty(propertyName).GetValue(this, null).ToString();

            return propertyValue.ToString();
        }

        class Metadata
        {
            [Key]
            [Display(Name = "Video Version Type")]
            public System.Guid VideoVersionTypeId { get; set; }

            [Required]
            [Display(Name = "Video Version Title")]
            [StringLength(100, ErrorMessage = "Please limit this field to 100 characters.")]
            public string VideoVersionTitle { get; set; }

            [Required]
            [Display(Name = "Video Version Description")]
            [DataType(DataType.MultilineText)]
            public string VideoVersionDescription { get; set; }

            [Required]
            [Display(Name = "Video Media Id")]
            public System.Guid VideoMediaId { get; set; }

            [Required]
            [Display(Name = "Aspect Ratio")]
            public string AspectRatio { get; set; }

            [Required]
            [Display(Name = "Runtime (minutes)")]
            public int Runtime { get; set; }

            [Required]
            [Display(Name = "Chapter Stops")]
            public int ChapterStops { get; set; }


        }
    }
}
