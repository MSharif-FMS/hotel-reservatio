csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingSystem.Infrastructure.Repositories
{
    public class RefundRepository : GenericRepository<Refund>, IRefundRepository
    {
        private readonly HotelBookingSystemDbContext _dbContext;

        public RefundRepository(HotelBookingSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Refund>> GetRefundsByPaymentIdAsync(long paymentId)
        {
            return await _dbContext.Refunds
                                   .Where(r => r.PaymentId == paymentId)
                                   .ToListAsync();
        }
    }
}