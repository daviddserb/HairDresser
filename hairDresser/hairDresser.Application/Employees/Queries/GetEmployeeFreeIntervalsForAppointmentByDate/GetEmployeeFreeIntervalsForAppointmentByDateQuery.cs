﻿using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Employees.Queries.GetEmployeeFreeIntervalsForAppointmentByDate
{
    public class GetEmployeeFreeIntervalsForAppointmentByDateQuery : IRequest<List<EmployeeFreeInterval>>
    {
        public string EmployeeId { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        // Date = nr. zilei din luna (1, 15, ..., 29, ..., 31).
        public int Date { get; set; }

        public int DurationInMinutes { get; set; }

        public string CustomerId { get; set; }
    }
}
