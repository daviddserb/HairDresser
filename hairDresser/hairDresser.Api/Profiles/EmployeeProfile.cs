﻿using AutoMapper;
using hairDresser.Application.Employees.Commands.CreateEmployee;
using hairDresser.Application.Employees.Commands.UpdateEmployee;
using hairDresser.Domain.Models;
using hairDresser.Presentation.Dto.EmployeeDtos;
using hairDresser.Presentation.Dto.EmployeeHairServiceDtos;

namespace hairDresser.Presentation.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeePostPutDto, CreateEmployeeComand>().ReverseMap();

            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
            CreateMap<EmployeeHairService, EmployeeHairServiceDto>().ReverseMap();

            CreateMap<EmployeePostPutDto, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
