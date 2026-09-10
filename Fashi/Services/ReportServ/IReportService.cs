using Fashi.ViewModels.ReportVm;

namespace Fashi.Services.ReportServ
{
    public interface IReportService
    {
        Task<List<ProductSalesReportVM>> GetProductSalesReportAsync();
        Task<List<MonthlyRevenueReportVM>> GetMonthlyRevenueReportAsync();
        Task<decimal> GetTotalRevenueAsync();
    }
}
