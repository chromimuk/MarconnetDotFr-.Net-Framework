using MarconnetDotFr_DernierFM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarconnetDotFr_DernierFM.Repository
{
    public interface ILastFMRepository
    {
        Task<LastFMUser> GetLastFMUserAsync(string username);

        Task<IEnumerable<LastFMAlbum>> GetFavouriteLastFMAlbumsAsync(string username, int limit, string period);
    }
}
