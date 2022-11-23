﻿using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ApplicationUser>
    {
        public string UserId { get; set; }
    }
}
