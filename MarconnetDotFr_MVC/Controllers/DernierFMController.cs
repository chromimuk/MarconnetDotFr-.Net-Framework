using MarconnetDotFr_DernierFM.Models.Entities;
using MarconnetDotFr_DernierFM.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MarconnetDotFr_MVC.Controllers
{
    public class DernierFMController : Controller
    {
        private ILastFMRepository _lastFMRepository;

        public DernierFMController(ILastFMRepository lastFMRepository)
        {
            _lastFMRepository = lastFMRepository;
        }

        public async Task<ActionResult> Index()
        {
            string username = "chromimuk";

            LastFMUser lastFMUser = await _lastFMRepository.GetLastFMUserAsync(username);

            IEnumerable<LastFMAlbum> favouriteAlbums_overall = await _lastFMRepository.GetFavouriteLastFMAlbumsAsync(username, 3, "overall");
            IEnumerable<LastFMAlbum> favouriteAlbums_currentYear = await _lastFMRepository.GetFavouriteLastFMAlbumsAsync(username, 3, "12month");

            lastFMUser.FavouriteAlbums_Overall = favouriteAlbums_overall.OrderByDescending(x => x.Playcount).ToList();
            lastFMUser.FavouriteAlbums_CurrentYear = favouriteAlbums_currentYear.OrderByDescending(x => x.Playcount).ToList();

            return View(lastFMUser);
        }
    }
}