using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        public List<Movie> Movies;

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> mapp { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDB { get; set; }

        [BindProperty]
        public float?maxIMDB { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void Onpost()
        {
            Movies = MovieDatabase.All;


            if (search!= null&& mapp.Count!= 0) { 
            Movies = MovieDatabase.SearchAndFilter(search, mapp);
            }
            else if(mapp.Count != 0) { 
            Movies = MovieDatabase.Filter(mapp);
                }

            else if(search != null) {
           Movies = MovieDatabase.Search(Movies, search);
             }


            if(mapp.Count != 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, mapp);
            }

            if(minIMDB != null)
            {
                Movies = MovieDatabase.FilterByBinIMDB(Movies, (float)minIMDB);
            }
            if (maxIMDB != null)
            {
                Movies = MovieDatabase.FilterByMaxIMDB(Movies, (float)maxIMDB);
            }
        }
    }
}
