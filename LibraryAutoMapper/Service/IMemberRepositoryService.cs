using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Service
{
    public interface IMemberRepositoryService
    {
        public Task<List<MemberDto>> GetMember();
        public Task<MemberDto> GetMemberById(int id);
        public Task<bool> EditMember(MemberDto memberDto);
        public Task<MemberDto> AddMember(MemberDto memberDto);
        public Task<bool> DeleteMember(int id);
        public bool MemberExists(int id);
        
    }
}