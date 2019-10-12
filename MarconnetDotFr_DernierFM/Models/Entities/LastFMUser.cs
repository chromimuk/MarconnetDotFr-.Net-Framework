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
        public LastFMAlbum FavouriteAlbum { get; set; }

        public LastFMUser(ILastFMUserDAO dao)
        {
            Name = dao.GetName();
            RealName = dao.GetRealName();
            ProfileImageURL = dao.GetImage();
            ProfileURL = dao.GetURL();
            Country = dao.GetCountry();
            Playcount = dao.GetPlayCount();
            Registered = dao.GetRegistered();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
