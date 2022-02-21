using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using K4os.Compression.LZ4.Internal;
using LibraryAutoMapper.DbContext;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;
using LibraryAutoMapper.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibraryAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepositoryService _memberRepository;

        public MemberController(IMemberRepositoryService memberRepository)
        {
            _memberRepository = memberRepository ;
        }

        // GET: api/Member
        [HttpGet]
        [Route("[action]")]
        [Route("api/Member/GetMember")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMember()
        {
            var member = await _memberRepository.GetMember();
            return Ok(new JsonResult(new {
                status = "success",
                data = member
            }));
        }

        // GET: api/Member/5
        [HttpGet]
        [Route("[action]")]
        [Route("api/Member/GetMemberById")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            var member = await _memberRepository.GetMemberById(id);

            if (member == null)
            {
                return Ok(new JsonResult(new {
                    status = "Not Found"
                }));
            }

            return Ok(new JsonResult(new {
                status = "success",
                data = member
            }));;
        }
        [HttpPut("{id}")]
        [Route("[action]")]
        [Route("api/Member/EditMember")]
        public async Task<IActionResult> EditMember(MemberDto memberDto)
        {
            int id = memberDto.Id;
            var member = await _memberRepository.EditMember(memberDto);
            if (member == false)
            {
                // Response.StatusCode = StatusCodes.Status404NotFound;
                return Ok(new JsonResult(new
                {
                    status = "Not Found",
                }));
            }

            return Ok(new JsonResult(new
            {
                status = "success",
                data = memberDto
            }));
        }

        
        // POST: api/Member
        [HttpPost]
        [Route("[action]")]
        [Route("api/Member/AddMember")]
        public async Task<ActionResult<Member>> AddMember(MemberDto memberDto)
        {
            var member = await _memberRepository.AddMember(memberDto);
            return Ok(new JsonResult(new {
                status = "success",
                data = memberDto
            }));
        }

        // DELETE: api/Member/5
        [HttpDelete]
        [Route("[action]")]
        [Route("api/Member/DeleteMember")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            bool member = await _memberRepository.DeleteMember(id);
            if (member == false)
            {
                return Ok(new JsonResult(new {
                    status = "Not Found"
                }));
            }
            return Ok(new JsonResult(new {
                status = "delete success",
               
            }));
        }
        
    }
}
