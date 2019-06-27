using Entities.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IRefreshTokenRepository
    {
        RefreshTokens Insert(RefreshTokens entity);
        Task<RefreshTokens> InsertAsync(RefreshTokens entity);
        RefreshTokens Update(RefreshTokens entity);
        Task<RefreshTokens> UpdateAsync(RefreshTokens entity);
        Task<RefreshTokens> GetAsync(Expression<Func<RefreshTokens, bool>> predicate);
        RefreshTokens Delete(RefreshTokens entity);
        Task<RefreshTokens> DeleteAsync(RefreshTokens entity);
    }
}
