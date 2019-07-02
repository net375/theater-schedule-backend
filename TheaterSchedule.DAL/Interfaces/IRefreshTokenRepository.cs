using Entities.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IRefreshTokenRepository
    {
        RefreshTokens Insert(RefreshTokens token);
        Task<RefreshTokens> InsertAsync(RefreshTokens token);
        RefreshTokens Update(RefreshTokens token);
        Task<RefreshTokens> UpdateAsync(RefreshTokens token);
        Task<RefreshTokens> GetAsync(Expression<Func<RefreshTokens, bool>> predicate);
        RefreshTokens Delete(RefreshTokens token);
        Task<RefreshTokens> DeleteAsync(RefreshTokens token);
    }
}
