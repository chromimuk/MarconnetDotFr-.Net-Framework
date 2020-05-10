namespace MarconnetDotFr_DernierFM.Models.DAO
{
    public interface ILastFMAlbumDAO
    {
        string GetMBID();

        string GetName();

        string GetArtist();

        long GetPlaycount();

        string GetAlbumImageURL();
    }
}