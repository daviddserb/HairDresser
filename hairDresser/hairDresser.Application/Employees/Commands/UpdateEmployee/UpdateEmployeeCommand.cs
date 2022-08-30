﻿using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> HairServicesIds { get; set; }
    }
}
