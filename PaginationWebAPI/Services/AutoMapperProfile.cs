using AutoMapper;
using PaginationWebAPI.Model;


namespace PaginationWebAPI.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           
            CreateMap<EmployeeDetails, EmployeeDetailsDto>();
        }
    }
}
