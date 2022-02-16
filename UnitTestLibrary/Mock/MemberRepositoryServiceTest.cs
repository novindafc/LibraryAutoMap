using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;
using LibraryAutoMapper.Service;

namespace UnitTestLibrary.Mock
{
    public class MemberRepositoryServiceTest:IMemberRepositoryService
    {
        public Task<List<MemberDto>> GetMember()
        {
            List<MemberDto> data = GetData();
            return Task.FromResult(data);
        }

        public Task<MemberDto> GetMemberById(int id)
        {
            List<MemberDto> data = GetData();
            MemberDto member = data.SingleOrDefault(x=>x.Id==id);
            return Task.FromResult(member);
        }

        public Task<MemberDto> EditMember(MemberDto memberDto)
        {
            List<MemberDto> data = GetData();
            MemberDto member = data.SingleOrDefault(x=>x.Id == memberDto.Id);
            member.Id = memberDto.Id;
            member.Name = memberDto.Name;
            member.Gender = memberDto.Gender;
            member.Phone = memberDto.Phone;
            member.Occupation = memberDto.Occupation;
            member.Email = memberDto.Email;
            return Task.FromResult(memberDto);
        }

        public Task<MemberDto> AddMember(MemberDto memberDto)
        {
            List<MemberDto> data = GetData();
            data.Add(memberDto);
            return Task.FromResult(memberDto);
        }

        public Task<bool> DeleteMember(int id)
        {
            List<MemberDto> data = GetData();
            MemberDto member = data.SingleOrDefault(x=>x.Id ==id);
            data.Remove(member);
            if (member == null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public bool MemberExists(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<MemberDto> GetData()
        {
            var data = new List<MemberDto>()
            {
                new MemberDto()
                {
                    Id = 1,
                    Name = "Novinda",
                    Gender = "F",
                    Phone = "0819727682",
                    Occupation = "student",
                    Email = "novinda@gmail.com"
                },
                new MemberDto()
                {
                    Id = 2,
                    Name = "Fiqih",
                    Gender = "F",
                    Phone = "08123466682",
                    Occupation = "student",
                    Email = "fiqih@gmail.com"
                },
                new MemberDto()
                {
                    Id = 3,
                    Name = "Caesandria",
                    Gender = "F",
                    Phone = "08197887777",
                    Occupation = "student",
                    Email = "caesandria@gmail.com"
                },

            };
            return data;
        }
    }
}