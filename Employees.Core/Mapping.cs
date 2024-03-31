﻿using AutoMapper;
using Employees.Core.DTOs;
using Employees.Core.Models;
using Employees.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<EmpRoleDTO, EmpRole>().ReverseMap();
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<EmpRoleDTO, EmpRole>().ReverseMap();
        }
    }
}
