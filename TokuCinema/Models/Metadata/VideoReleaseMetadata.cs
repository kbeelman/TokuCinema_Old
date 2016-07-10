using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TokuCinema.Domain;

namespace TokuCinema.Models
{
    [MetadataType(typeof(VideoRelease.Metadata))]
    public partial class VideoRelease : IExposeProperty
    {
        public string ExposePropertyValue(string propertyName)
        {
            string propertyValue = "";

            propertyValue = GetType().GetProperty(propertyName).GetValue(this, null).ToString();

            return propertyValue;
        }

        [MetadataType(typeof(VideoRelease.Metadata))]
        class Metadata
        {
            [Key]
            [Display(Name = "Video Release Id")]
            public System.Guid VideoReleaseId { get; set; }

            [Required]
            [Display(Name = "Distributor Id")]
            public System.Guid DistributorId { get; set; }

            [Required]
            [Display(Name = "Packaging Id")]
            public System.Guid PackagingId { get; set; }

            [Required]
            [Display(Name = "Catalog Code")]
            public string CatalogCode { get; set; }

            [Required]
            [Display(Name = "UPC")]
            public string UPC { get; set; }

            [Required]
            [Display(Name = "Release Date")]
            public System.DateTime ReleaseDate { get; set; }

            [Required]
            [Display(Name = "Disc Count")]
            public int DiscCount { get; set; }
        }
    }
}
