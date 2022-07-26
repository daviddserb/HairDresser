﻿//using AutoMapper;
//using hairDresser.Application.Employees.Commands.AddEmployeeHairServices;
//using hairDresser.Application.Employees.Commands.CreateEmployee;
//using hairDresser.Application.Employees.Commands.DeleteEmployee;
//using hairDresser.Application.Employees.Commands.DeleteEmployeeHairService;
//using hairDresser.Application.Employees.Commands.UpdateEmployee;
//using hairDresser.Application.Employees.Queries.GetAllEmployees;
//using hairDresser.Application.Employees.Queries.GetEmployeeById;
//using hairDresser.Application.Employees.Queries.GetEmployeeFreeIntervalsForAppointmentByDate;
//using hairDresser.Application.Employees.Queries.GetEmployeesByServices;
//using hairDresser.Presentation.Dto.EmployeeDtos;
//using hairDresser.Presentation.Dto.EmployeeFreeIntervalsDtos;
//using hairDresser.Presentation.Dto.EmployeeHairServiceDtos;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace hairDresser.Presentation.Controllers
//{
//    [ApiController]
//    [Route("api/employee")]
//    public class EmployeeController : ControllerBase
//    {
//        public readonly IMapper _mapper;
//        public readonly IMediator _mediator;

//        public EmployeeController(IMapper mapper, IMediator mediator)
//        {
//            _mediator = mediator;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeePostPutDto employeeInput)
//        {
//            var command = _mapper.Map<CreateEmployeeComand>(employeeInput);

//            var employee = await _mediator.Send(command);

//            var mappedEmployee = _mapper.Map<EmployeeGetDto>(employee);

//            return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = mappedEmployee.Id }, mappedEmployee);
//        }

//        [HttpGet]
//        [Route("all")]
//        public async Task<IActionResult> GetAllEmployees()
//        {
//            var query = new GetAllEmployeesQuery();

//            var allEmployees = await _mediator.Send(query);

//            if (!allEmployees.Any()) return NotFound();

//            var mappedEmployees = _mapper.Map<List<EmployeeGetDto>>(allEmployees);

//            return Ok(mappedEmployees);
//        }

//        [HttpGet]
//        [Route("{employeeId}")]
//        public async Task<IActionResult> GetEmployeeById(int employeeId)
//        {
//            var query = new GetEmployeeByIdQuery { Id = employeeId };

//            var employee = await _mediator.Send(query);

//            if (employee == null) return NotFound();

//            var mappedEmployee = _mapper.Map<EmployeeGetDto>(employee);

//            return Ok(mappedEmployee);
//        }

//        [HttpGet]
//        [Route("all/by-services")]
//        public async Task<IActionResult> GetEmployeesByHairServices([FromQuery] List<int> hairServicesIds)
//        {
//            var query = new GetEmployeesByServicesQuery(hairServicesIds);

//            var validEmployees = await _mediator.Send(query);

//            if (!validEmployees.Any()) return NotFound();

//            var mappedValidEmployees = _mapper.Map<List<EmployeeGetDto>>(validEmployees);

//            return Ok(mappedValidEmployees);
//        }

//        [HttpGet]
//        [Route("free-intervals")]
//        public async Task<IActionResult> GetEmployeeFreeIntervalsByDate([FromQuery] EmployeeFreeIntervalDto employeeFreeInterval)
//        {
//            var query = new GetEmployeeFreeIntervalsForAppointmentByDateQuery
//            {
//                EmployeeId = employeeFreeInterval.EmployeeId,
//                Year = employeeFreeInterval.Year,
//                Month = employeeFreeInterval.Month,
//                Date = employeeFreeInterval.Date,
//                DurationInMinutes = employeeFreeInterval.DurationInMinutes,
//                CustomerId = employeeFreeInterval.CustomerId
//            };

//            var freeIntervals = await _mediator.Send(query);

//            if (!freeIntervals.Any()) return NotFound();

//            var mappedFreeIntervals = _mapper.Map<List<EmployeeFreeIntervalsGetDto>>(freeIntervals);

//            return Ok(mappedFreeIntervals);
//        }

//        [HttpPut]
//        [Route("{employeeId}")]
//        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeePostPutDto editedEmployee)
//        {
//            var command = new UpdateEmployeeCommand
//            {
//                Id = employeeId,
//                Name = editedEmployee.Name,
//                HairServicesIds = editedEmployee.HairServicesIds
//            };

//            var result = await _mediator.Send(command);

//            if (result == null) return NotFound();

//            return NoContent();
//        }

//        [HttpDelete]
//        [Route("{employeeId}")]
//        public async Task<IActionResult> DeleteEmployee(int employeeId)
//        {
//            var command = new DeleteEmployeeCommand { Id = employeeId };

//            var handlerResult = await _mediator.Send(command);

//            if (handlerResult == null) return NotFound();

//            return NoContent();
//        }

//        EmployeesHairServices:
//        [HttpPost]
//        [Route("hair-service")]
//        public async Task<IActionResult> AddHairServicesToEmployee([FromBody] EmployeeHairServicePostDto employeeHairService)
//        {
//            var command = new AddEmployeeHairServicesCommand { EmployeeId = employeeHairService.EmployeeId, HairServicesIds = employeeHairService.HairServicesIds };

//            var result = await _mediator.Send(command);

//            if (result == null) return NotFound();

//            return NoContent();
//        }

//        [HttpDelete]
//        [Route("hair-service/{employeeHairServiceId}")]
//        public async Task<IActionResult> DeleteHairServiceFromEmployee(int employeeHairServiceId)
//        {
//            var command = new DeleteEmployeeHairServiceCommand { EmployeeHairServiceId = employeeHairServiceId };

//            var handlerResult = await _mediator.Send(command);

//            return NoContent();
//        }
//    }
//}
