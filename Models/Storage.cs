using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Class for local storage. No longer used.

namespace MovieCollection.Models
{
    public static class Storage
    {
        private static List<Movie> applications = new List<Movie>();

        public static IEnumerable<Movie> Applications => applications;

        public static void AddApplication(Movie application)
        {
            applications.Add(application);
        }
    }
}