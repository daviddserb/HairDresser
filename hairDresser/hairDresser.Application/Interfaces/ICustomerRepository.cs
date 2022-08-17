﻿using hairDresser.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(string customerUsername);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}
