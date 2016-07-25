using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TokuCinema.Models;
using TokuCinema.Domain;
using System.Text.RegularExpressions;

namespace TokuCinema.Services
{
    public static class SearchingService
    {
        // Returns a list of Video Version Types that have titles containing a desired string from a list of Video Version Types
        public static List<VideoVersionType> MovieSearch(List<VideoVersionType> searchableList, string queryString)
        {
            // return object
            List<VideoVersionType> results = new List<VideoVersionType>();

            try
            {
                // Grab all versions types where the title contains the text entered by the user
                foreach (VideoVersionType item in searchableList)
                {
                    // Regex to filter non-alpha numeric characters
                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    
                    // Get alpha numeric characters of title
                    string videoVersionTitle = item.VideoVersionTitle.ToLower();
                    videoVersionTitle = rgx.Replace(videoVersionTitle, "");

                    // don't bother searching if the query string is empty
                    if(queryString.Length > 0)
                    {
                        if (videoVersionTitle.Contains(queryString.ToLower().Trim()))
                        {
                            results.Add(item);
                        }
                    }
                }

                // Grab all versions related to the versions already in the results list 
                // (this is so if you search "Mothra" you will also see a result for Godzilla vs. The Thing.)
                List<VideoVersionType> relatedRecords = new List<VideoVersionType>();
                foreach (VideoVersionType item in results)
                {
                    // add all other version of its video media
                    relatedRecords.AddRange(item.VideoMedia.VideoVersionTypes.Where(id => id.VideoVersionTypeId != item.VideoVersionTypeId));
                }
                // add related records to search results
                results.AddRange(relatedRecords);
                   
            }
            catch (ArgumentNullException)
            {
                // Allow operation to continue and return an empty list.
            }

            // return the distinct results
            return results.Distinct().ToList();
            
        }
    }
}