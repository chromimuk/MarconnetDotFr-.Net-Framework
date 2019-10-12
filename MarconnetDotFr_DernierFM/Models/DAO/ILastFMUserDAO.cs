using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarconnetDotFr_DernierFM.Models.DAO
{
    public interface ILastFMUserDAO
    {
        string GetName();

        string GetRealName();

        string GetImage();

        string GetURL();

        string GetCountry();

        long GetPlayCount();

        DateTime GetRegistered();
    }
}
