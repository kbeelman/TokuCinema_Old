using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokuCinema.Models
{
    public class Movie
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();
        
        public Movie ()
        { }

        public Movie (Guid? id)
        {
            VideoMedia = db.VideoMedias.Find(id);
            Media = db.Media.Find(VideoMedia.MediaId);
        }

        public Medium Media { get; set; }
        public VideoMedia VideoMedia { get; set; }
    }
}