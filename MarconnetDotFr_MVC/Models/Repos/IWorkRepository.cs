using MarconnetDotFr_MVC.Models.Entities;

namespace MarconnetDotFr_MVC.Models.Repos
{
    public interface IWorkRepository
    {
        WorkModel GetWorkModel(string workModelName);
    }
}