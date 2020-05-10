using System;

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