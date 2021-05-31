using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context) => _context = context;

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
                result = result.Where(_ => _.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(_ => _.Date <= maxDate.Value);

            return await result
                .Include(_ => _.Seller)
                .Include(_ => _.Seller.Department)
                .OrderByDescending(_ => _.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
                result = result.Where(_ => _.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(_ => _.Date <= maxDate.Value);

            return await result
                .Include(_ => _.Seller)
                .Include(_ => _.Seller.Department)
                .OrderByDescending(_ => _.Date)
                .GroupBy(_ => _.Seller.Department)
                .ToListAsync();
        }
    }
}
