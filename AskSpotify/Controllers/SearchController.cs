using AskSpotify.BusinessLayer.Extensions;
using AskSpotify.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AskSpotify.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View("Search");
        }
        
        /// <summary>
        /// Searches Spotify for the top 50 tracks
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult> Search(SearchViewModel model)
        {
            if (model == null || model.SearchString.IsNullOrEmpty())
            {
                ViewBag.Message = "Text to search for cannot be null or empty.";
                return View();
            }

            // create request to send to Spotify
            var request = new BusinessLayer.Request.SpotifyRequest();
            request.Query = model.SearchString;
            request.ItemType = BusinessLayer.Models.ItemType.Track;
            request.Limit = 50;

            // retrive the response from Spotify
            var response = await BusinessLayer.Spotify.SearchAsync(request);

            // create a resultsviewmodel that will display the results in the view
            var resultsViewModel = new ResultsViewModel();

            resultsViewModel.SearchString = model.SearchString;
            resultsViewModel.Tracks = response.Tracks; // Set to Tracks, as it's the only thing we search for right now.

            return View("Result", resultsViewModel );
        }


        public ActionResult Result(ResultsViewModel viewModel)
        {
            return View("Result", viewModel);
        }

    }
}
