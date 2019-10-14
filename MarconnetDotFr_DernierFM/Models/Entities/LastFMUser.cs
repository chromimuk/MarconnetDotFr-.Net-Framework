using MarconnetDotFr_DernierFM.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarconnetDotFr_DernierFM.Models.Entities
{
    public class LastFMUser
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string ProfileImageURL { get; set; }
        public string ProfileURL { get; set; }
        public string Country { get; set; }
        public long Playcount { get; set; }
        public DateTime Registered { get; set; }
        public IList<LastFMAlbum> FavouriteAlbums_Overall { get; set; }
        public IList<LastFMAlbum> FavouriteAlbums_CurrentYear { get; set; }

        public LastFMAlbum FavouriteAlbum_AllTime {
            get
            {
                long maxPlayCount = FavouriteAlbums_Overall.Max(x => x.Playcount);
                return FavouriteAlbums_Overall.First(x => x.Playcount == maxPlayCount);
            }
        }

        public LastFMUser(ILastFMUserDAO dao)
        {
            Name = dao.GetName();
            RealName = dao.GetRealName();
            ProfileImageURL = dao.GetImage();
            ProfileURL = dao.GetURL();
            Country = dao.GetCountry();
            Playcount = dao.GetPlayCount();
            Registered = dao.GetRegistered();

            FavouriteAlbums_Overall = new List<LastFMAlbum>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
