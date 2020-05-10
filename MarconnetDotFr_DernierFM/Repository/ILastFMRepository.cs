using MarconnetDotFr_DernierFM.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarconnetDotFr_DernierFM.Repository
{
    public interface ILastFMRepository
    {
        Task<LastFMUser> GetLastFMUserAsync(string username);

        Task<IEnumerable<LastFMAlbum>> GetFavouriteLastFMAlbumsAsync(string username, int limit, string period);
    }
}