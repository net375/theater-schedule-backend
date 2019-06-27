using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private TheaterDatabaseContext _context;

        public RefreshTokenRepository(TheaterDatabaseContext context)
        {
            _context = context;
        }

        public RefreshTokens Insert(RefreshTokens entity)
        {
            _context.RefreshTokens.Add(entity);

            return entity;
        }

        public async Task<RefreshTokens> InsertAsync(RefreshTokens entity)
        {
            await _context.RefreshTokens.AddAsync(entity);

            return entity;
        }

        public RefreshTokens Update(RefreshTokens entity)
        {
            _context.RefreshTokens.Update(entity);

            return entity;
        }

        public async Task<RefreshTokens> UpdateAsync(RefreshTokens entity)
        {
            _context.RefreshTokens.Update(entity);

            return entity;
        }

        public async Task<RefreshTokens> GetAsync(Expression<Func<RefreshTokens, bool>> predicate)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(predicate);
        }

        public RefreshTokens Delete(RefreshTokens entity)
        {
            _context.RefreshTokens.Remove(entity);

            return entity;
        }

        public async Task<RefreshTokens> DeleteAsync(RefreshTokens entity)
        {
            _context.RefreshTokens.Remove(entity);

            return entity;
        }
    }
}