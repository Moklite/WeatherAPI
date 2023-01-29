using WeatherAPI.Entities;

namespace WeatherAPI.Interface
{
    public interface IMemberRepository
    {
        Task<PmeMember> GetByIdAsync(int id);
        Task<IEnumerable<PmeMember>> GetAllAsync();
        Task<PmeMember> AddAsync(PmeMember entity);
        Task<PmeMember> UpdateAsync(PmeMember entity);
        Task<PmeMember> DeleteAsync(int id);
    }

}
