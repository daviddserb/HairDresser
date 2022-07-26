﻿using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Users.Commands.AddHairServicesToEmployee
{
    public class AddHairServicesToEmployeeCommand : IRequest<User>
    {
        public string EmployeeId { get; set; }
        public List<int> HairServicesIds { get; set; }
    }
}
