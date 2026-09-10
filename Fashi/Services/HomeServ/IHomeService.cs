using Fashi.ViewModels;

namespace Fashi.Services.HomeServ
{
    public interface IHomeService
    {
        Task<HomeVM> GetHomeDataAsync(int page,
        int pageSize,
        string? search,
        int? categoryId,
        string? sort);
    }
}
