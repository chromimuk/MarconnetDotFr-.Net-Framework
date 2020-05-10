using MarconnetDotFr_DernierFM.Models.DAO;

namespace MarconnetDotFr_DernierFM.Models.Entities
{
    public class LastFMAlbum
    {
        public string MBID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public long Playcount { get; set; }
        public string AlbumImageURL { get; set; }

        public LastFMAlbum(ILastFMAlbumDAO dao)
        {
            MBID = dao.GetMBID();
            Name = dao.GetName();
            Artist = dao.GetArtist();
            Playcount = dao.GetPlaycount();
            AlbumImageURL = dao.GetAlbumImageURL();
        }
    }
}