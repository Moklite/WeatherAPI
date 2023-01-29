using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Entities;
using WeatherAPI.Interface;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet("GetMembers")]
        public async Task<ActionResult<IEnumerable<PmeMember>>> GetAllMembers()
        {
            var entities = await _memberRepository.GetAllAsync();
            if (entities is not null)  return Ok(entities); 
            return BadRequest(entities);
        }

        [HttpGet("{id}", Name = "MemberById")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var entity = await _memberRepository.GetByIdAsync(id);
            if (entity is not null)  return Ok(entity); 
            return BadRequest(entity);
        }

        [HttpPost("CreateMember")]
        public async Task<IActionResult> CreateMember([FromBody]PmeMember pmeMember)
        {
            var entity = await _memberRepository.AddAsync(pmeMember);
            if (entity is not null) return Ok(entity);
            return BadRequest(entity);
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody]PmeMember pmeMember)
        {
            var entity = await _memberRepository.UpdateAsync(pmeMember);
            if (entity is not null) return Ok(entity);
            return BadRequest(entity);
        }

        [HttpDelete("{id}",Name ="DeleteMember")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var entity = await _memberRepository.DeleteAsync(id);
            if (entity is not null) return Ok(entity);
            return BadRequest(entity);
        }
    }
}
