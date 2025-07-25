using AutoMapper;
using JunBatchCodeFirstApproachImpl.DTO;
using JunBatchCodeFirstApproachImpl.Models;

namespace JunBatchCodeFirstApproachImpl.Mapper
{
    public class MappingData: Profile
    {
        public MappingData()
        {
            CreateMap<Employee, EmpDTO>().ForMember(x=>x.ManagerName,x=>x.MapFrom(x=>x.mans!=null?x.mans.ManagerName:"No"));
            CreateMap<Employee, EmpAddDTO>().ReverseMap();
        }
    }
}
