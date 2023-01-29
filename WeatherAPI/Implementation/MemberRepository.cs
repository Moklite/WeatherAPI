using Microsoft.EntityFrameworkCore;
using WeatherAPI.Context;
using WeatherAPI.Entities;
using WeatherAPI.Interface;

namespace WeatherAPI.Implementation
{
    public class MemberRepository : IMemberRepository
    {
        private readonly WeatherDbContext _context;

        public MemberRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<PmeMember> GetByIdAsync(int id)
        {
            return await _context.PmeMembers.SingleOrDefaultAsync(a=>a.MemberId==id);
        }

        public async Task<IEnumerable<PmeMember>> GetAllAsync()
        {
            return await _context.PmeMembers.ToListAsync();
        }

        public async Task<PmeMember> AddAsync(PmeMember entity)
        {
            await _context.PmeMembers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PmeMember> UpdateAsync(PmeMember entity)
        {
            _context.PmeMembers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PmeMember> DeleteAsync(int id)
        {
            var entity = await _context.PmeMembers.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}
