﻿using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IQueryable<Customer>>
    {
    }
}