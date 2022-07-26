﻿using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQuery : IRequest<IQueryable<Appointment>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
