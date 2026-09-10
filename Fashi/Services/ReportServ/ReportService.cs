
using Fashi.Repositories.SaleRepo;
using Fashi.ViewModels.ReportVm;

namespace Fashi.Services.ReportServ
{
    public class ReportService : IReportService
    {
        private readonly ISaleRepository _saleRepository;
        public ReportService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<MonthlyRevenueReportVM>> GetMonthlyRevenueReportAsync()
        {
           return await _saleRepository.GetMonthlyRevenueReportAsync();
        }

        public async Task<List<ProductSalesReportVM>> GetProductSalesReportAsync()
        {
            return await _saleRepository.GetProductSalesReportAsync();
        }
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _saleRepository.GetTotalRevenueAsync();
        }
    }
}
