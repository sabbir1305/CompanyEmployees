﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Employees;
using Entities.DataTransferObjects.UserManagement;
using Entities.Models;

namespace CompanyEmployees.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 

            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress, 
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
