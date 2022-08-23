﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Days.Commands.CreateDay
{
    public class CreateDayCommand : IRequest
    {
        public string Name { get; set; }
    }
}
