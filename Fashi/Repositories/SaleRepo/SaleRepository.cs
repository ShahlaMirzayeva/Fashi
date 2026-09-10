using Fashi.Data;
using Fashi.Models;
using Fashi.ViewModels.ReportVm;
using Microsoft.EntityFrameworkCore;

namespace Fashi.Repositories.SaleRepo
{
    public class SaleRepository:Repository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context):base(context)
        {
            
        }
        public async Task<List<ProductSalesReportVM>> GetProductSalesReportAsync()
        {
            return await _context.SaleProducts
                .GroupBy(x => new
                {
                    x.ProductId,
                    x.Product.Name
                })
                .Select(g => new ProductSalesReportVM
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.Name,
                    TotalQuantity = g.Sum(x => x.Quantity),
                    TotalAmount = g.Sum(x => x.Quantity * x.Price)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .ToListAsync();
        }
        public async Task<List<MonthlyRevenueReportVM>> GetMonthlyRevenueReportAsync()
        {
            return await _context.Sales
                .GroupBy(x => new
                {
                    x.SaleTime.Year,
                    x.SaleTime.Month
                })
                .Select(g => new MonthlyRevenueReportVM
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(x => x.Total)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();
        }
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Sales
         .Select(x => x.Total)
         .SumAsync();
        }
    }
}
