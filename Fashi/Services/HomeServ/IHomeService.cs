using Fashi.ViewModels;

namespace Fashi.Services.HomeServ
{
    public interface IHomeService
    {
        Task<HomeVM> GetHomeDataAsync();
    }
}
