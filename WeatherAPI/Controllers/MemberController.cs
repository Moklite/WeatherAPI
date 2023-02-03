using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.DTO;
using WeatherAPI.Entities;
using WeatherAPI.Interface;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateMember([FromBody]PmeMemberDTO pmeMember)
        {
            var createModel = _mapper.Map<PmeMember>(pmeMember);

            try
            {
                var entity = await _memberRepository.AddAsync(createModel);
                 return Ok(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody]PmeMemberDTO pmeMember)
        {
            var createModel = _mapper.Map<PmeMember>(pmeMember);
            try
            {

                var entity = await _memberRepository.UpdateAsync(createModel);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
