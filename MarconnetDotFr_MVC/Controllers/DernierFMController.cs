using MarconnetDotFr_DernierFM.Models;
using MarconnetDotFr_DernierFM.Models.Entities;
using MarconnetDotFr_DernierFM.Repository;
using MarconnetDotFr_MVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MarconnetDotFr_MVC.Controllers
{
    public class DernierFMController : Controller
    {
        ILastFMRepository _lastFMRepository;

        public DernierFMController(ILastFMRepository lastFMRepository)
        {
            _lastFMRepository = lastFMRepository;
        }

        public async Task<ActionResult> Index()
        {
            string username = "chromimuk";

            LastFMUser lastFMUser = await _lastFMRepository.GetLastFMUserAsync(username);
            IEnumerable<LastFMAlbum> lastFMAlbums = await _lastFMRepository.GetFavouriteLastFMAlbumsAsync(username, 5, "overall");

            lastFMUser.FavouriteAlbum = lastFMAlbums.First();

            return View(lastFMUser);
        }
    }
}