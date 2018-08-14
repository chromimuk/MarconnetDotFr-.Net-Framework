namespace MarconnetDotFr_2018.Models.DAO
{
    public interface IResumeItemModelDAO
    {
        string GetImage();
        string GetTitle();
        string GetShortTitle();
        string GetLocation();
        string GetShortLocation();
        string GetDescription();
        string GetTech();
    }
}
