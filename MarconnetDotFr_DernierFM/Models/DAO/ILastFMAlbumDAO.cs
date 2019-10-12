using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
